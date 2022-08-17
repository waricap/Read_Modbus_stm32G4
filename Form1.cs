using System;
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
        int data_temp =12082022;
        public int count_list_box=0;

        private ListBox[] listbox_arr_data_graf = new ListBox[6];
        private Label[]   label_chart_marker     = new Label[6];
        private static int num_point_freq_zamer = 28500;
        private static int freq_begin_band = 14500;
        private List< Class_data> data_freq = new List<Class_data>();
        private Set_Generator_struct Set_Generator = new Set_Generator_struct();

        public Form1()
        {
            InitializeComponent();
            data_freq.Capacity = num_point_freq_zamer; // 28500
            // !!!!!  причесать
            listbox_arr_data_graf[0] = listBox1;
            listbox_arr_data_graf[1] = listBox2;
            listbox_arr_data_graf[2] = listBox3;
            listbox_arr_data_graf[3] = listBox4;
            listbox_arr_data_graf[4] = listBox5;
            listbox_arr_data_graf[5] = listBox6;

            label_chart_marker[0] = label_chart1;
            label_chart_marker[1] = label_chart2;
            label_chart_marker[2] = label_chart3;
            label_chart_marker[3] = label_chart4;
            label_chart_marker[4] = label_chart5;
            label_chart_marker[5] = label_chart6;

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

        private void button_Save_Click(object sender, EventArgs e)
        {
            save_data_in_file();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            open_file_extract_data();
        }

        private void numericUpDown_mouse_MouseUp(object sender, MouseEventArgs e)
        {
            numeric_Up_Down_change(((NumericUpDown)sender).Height, e);
        }

    }
}
