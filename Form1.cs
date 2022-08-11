﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Modbus.Device;


/// <summary>
/// инфа  по работе с СОМ портом
/// https://qna.habr.com/q/199341
/// https://microtechnics.ru/protokol-modbus-obzor-opisanie-i-primery-ispolzovaniya/
/// </summary>
/// 
namespace Read_Modbus_UsbCDC_stm32G4
{

    public partial class Form1 : Form
    {
        int data_temp =11082022;
        public int count_list_box=0;

        private ListBox[] listbox_arr_data_graf = new ListBox[6];
        private Label[]   label_chart_mouse     = new Label[6];
        private float[,] array_data_freq = new float[8,28500]; // столбец 7-флаг присутствия данных на этой точке

        struct Set_Generator_struct
        {
            //	Reg_CMD_Buf[0] - регистр флагов-команд, приходящих для исполнения
            public bool flag_ON_generation;        //	Reg_CMD_Buf[0].0 - флаг-команда Включить Генерацию
            public bool flag_ON_scan_freq;         //	Reg_CMD_Buf[0].1 - флаг-команда Вкл. Скольжение по диапазону, в соответствии с задаными регистрами
            public bool flag_ON_TxData_cicle;      //	Reg_CMD_Buf[0].2 - флаг-команда Вкл. долбежку передачи данных по кругу, прием при этом прекратиться, стоповать можно будет только синей кнопкой
            public bool flag_ON_autoTuning_freq;   //	Reg_CMD_Buf[0].3 - флаг-команда при включеной генерации автоподстройка частоты будет работать, если включен флаг скольжения, этот флаг игнорится

            public UInt16 Power_proc;  //	Reg_CMD_Buf[1] - регистр мощности,  2-98% заполнения
            public UInt16 Freq_start;  //	Reg_CMD_Buf[2] - регистр стартовой частоты, 14500-43000
            public UInt16 F_Step;      //	Reg_CMD_Buf[3] - регистр step(1-25гц) перемещения частоты, при сканировании диапазона, при сканировании старт будет Reg_CMD_Buf[2], максимум = (Reg_CMD_Buf[2] + step*_N-количество_)
            public UInt16 Time_Step;   //	Reg_CMD_Buf[4] - регистр время милисекунд, между степами (10-1000мс)
            public UInt16 N_step;      //	Reg_CMD_Buf[5] - регистр N-количество степов при сканировании 0-1000
        }

        private Set_Generator_struct Set_Generator = new Set_Generator_struct();
        public Form1()
        {
            InitializeComponent();

            // !!!!!  причесать
            listbox_arr_data_graf[0] = listBox1;
            listbox_arr_data_graf[1] = listBox2;
            listbox_arr_data_graf[2] = listBox3;
            listbox_arr_data_graf[3] = listBox4;
            listbox_arr_data_graf[4] = listBox5;
            listbox_arr_data_graf[5] = listBox6;

            label_chart_mouse[0] = label_chart1;
            label_chart_mouse[1] = label_chart2;
            label_chart_mouse[2] = label_chart3;
            label_chart_mouse[3] = label_chart4;
            label_chart_mouse[4] = label_chart5;
            label_chart_mouse[5] = label_chart6;

            // чтение портов доступных в системе
            // и сформировать listBox_ComPort - на выбор
            add_text_ComPort();  // при работе, во время наведения мыши, тоже будет отрабатывать

            init_Set_Generator();

            // вначале, чтобы не тыкать лишний раз
            init_COM_port();

            init_chart();// при старте - вид на полную, потом по ходу жизни - масштабировать
        }

        private void button_read_ONE_Click(object sender, EventArgs e)
        {
            read_ONE(); // прочитатать состояние регистров генератора
        } // private void button_read_ONE_Click(object sender, EventArgs e)

        private void listBox_BaudRate_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort_MB.BaudRate = Convert.ToInt32(listBox_BaudRate.SelectedItem.ToString());
            label_baudrate.Text = serialPort_MB.BaudRate.ToString();
        }
        private void listBox_ComPort_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort_MB.PortName = listBox_ComPort.SelectedItem.ToString();
            label_ComPort.Text = serialPort_MB.PortName;
        }
        private void button_on_gen_scan_Click(object sender, EventArgs e)
        {
            start_gen_scan(); // после старта , приемник на генераторе отключается, стоповать только синей кнопкой
        }



        private void listBox_ComPort_MouseEnter(object sender, EventArgs e)
        {
            add_text_ComPort();
            // чтение портов доступных в системе
            //string[] ports = SerialPort.GetPortNames();
            // Очистка содержимого бокса
            //listBox_ComPort.Items.Clear();
            // Добавление найденных портов в бокс
            //listBox_ComPort.Items.AddRange(ports);
            //label_ComPort.Text = serialPort_MB.PortName;
        }
        private void textBox_Fstart_Leave(object sender, EventArgs e)
        {
            textBox_Fstart.Text = Freq_TextBox(textBox_Fstart.Text);
        }

        private void textBox_Power_Leave(object sender, EventArgs e)
        {
            textBox_Power.Text = Power_TextBox(textBox_Power.Text);
        }

        private void textBox_Step_Leave(object sender, EventArgs e)
        {
            textBox_Step.Text = Step_TextBox(textBox_Step.Text);
        }

        private void textBox_NumPoint_Leave(object sender, EventArgs e)
        {
            textBox_NumPoint.Text =  NumPoint_TextBox(textBox_NumPoint.Text);
        }

        private void textBox_Tstep_Leave(object sender, EventArgs e)
        {
            textBox_Tstep.Text = Time_step_TextBox(textBox_Tstep.Text);
        }

        private void textBox_Fstart_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                { textBox_Step.Focus(); }
        }

        private void textBox_Power_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                { textBox_Fstart.Focus(); }
        }

        private void textBox_Step_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                { textBox_NumPoint.Focus(); }
        }

        private void textBox_NumPoint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                { textBox_Tstep.Focus(); }
        }

        private void textBox_Tstep_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                { textBox_Power.Focus(); }
        }

        private void checkBox_ON_gen_CheckedChanged(object sender, EventArgs e)
        {
            Set_Generator.flag_ON_generation = checkBox_ON_gen.Checked;
        }

        private void checkBox_Tx_Data_cicle_CheckedChanged(object sender, EventArgs e)
        {
            Set_Generator.flag_ON_TxData_cicle = checkBox_Tx_Data_cicle.Checked;
        }

        private void checkBox_ON_scan_CheckedChanged(object sender, EventArgs e)
        {
            Set_Generator.flag_ON_scan_freq = checkBox_ON_scan.Checked;
        }

        private  void button_cicle_read_Click(object sender, EventArgs e)
        {
            init_COM_port();
            if (serialPort_MB.IsOpen == false)
            { serialPort_MB.Open(); }
            byte[] cmd_read_1 = { 7, 4, 0, 64, 0, 0 }; // для совместимости
            _ = Read_cicle_scan_freq(cmd_read_1);
        }

        private void numericUpDown_mouse_ValueChanged(object sender, EventArgs e)
        {
            numeric_Up_Down_change();
        }
    }
}
