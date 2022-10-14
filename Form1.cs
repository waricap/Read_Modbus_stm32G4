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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Microsoft.Win32;

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
        public int count_list_box=0;

        private ListBox[] listbox_arr_data_graf = new ListBox[6];
        private Label[]   label_chart_marker     = new Label[6];
        private static int num_point_freq_zamer ;
        private static int freq_begin_band ;
        private List< Class_data> data_freq = new List<Class_data>();
        private Set_Generator_struct Set_Generator = new Set_Generator_struct();
        private List<info_data_chart_class> info_data_chart = new List<info_data_chart_class>();
        private string path_directory = "";
        private string default_com_port_MB = "";
        private string default_com_port_read_data = "";
        private int default_baudrate_MB;
        private int v_43000;
        public Form1()
        {
            InitializeComponent();
            init_start_data_registry();
            v_43000 = freq_begin_band + num_point_freq_zamer;
            label_name_file_zamer.Text = path_directory;
            data_freq.Capacity = num_point_freq_zamer; // 28500 - придет из реестра
            // !!!!!  причесать
            listbox_arr_data_graf[0] = listBox1;
            listbox_arr_data_graf[1] = listBox2;
            listbox_arr_data_graf[2] = listBox3;
            listbox_arr_data_graf[3] = listBox4;
            listbox_arr_data_graf[4] = listBox5;
            listbox_arr_data_graf[5] = listBox6;

            init_info_data_chart();

            label_chart_marker[0] = label_chart1;
            label_chart_marker[1] = label_chart2;
            label_chart_marker[2] = label_chart3;
            label_chart_marker[3] = label_chart4;
            label_chart_marker[4] = label_chart5;
            label_chart_marker[5] = label_chart6;


            init_Set_Generator();

            // вначале, чтобы не тыкать лишний раз
            init_COM_port_MB();
            // чтение портов доступных в системе
            // и сформировать listBox_ComPort - на выбор
            add_text_ComPort();  // при работе, во время наведения мыши, тоже будет отрабатывать
            init_chart();// при старте - вид на полную, потом по ходу жизни - масштабировать
            chart1.Legends[0].Position = new ElementPosition(90,0,20,9);

            // добавить  к обработчику клавиш ещё и обработку двух стрелок лево-право
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.windows.forms.form.keypreview?view=netframework-4.8
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        //-------------------------------------------------------------------------------------------
        // By default, KeyDown does not fire for the ARROW keys
        // По умолчанию нажатие клавиш не срабатывает для клавиш со стрелками. Но если   this.KeyPreview = true;
        // Форма будет обрабатывать все кнопочные события до того, как элемент управления с фокусом обработает их.
        // Обработать нажатые клавиши по свойству keyCode.
        // установив KeyEventArg.Handled - свойство = false.  - кнопки управления остальные работали чтобы
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    numeric_Up_Down(-1, (double)numericUpDown_mouse.Value - 1);
                    break;
                case Keys.Right:
                    numeric_Up_Down( 1, (double)numericUpDown_mouse.Value + 1);
                    break;
            }
            e.Handled = false;
        }
        //-------------------------------------------------------------------------------------------

        private void button_read_ONE_Click(object sender, EventArgs e)
        {
            read_ONE(); // прочитатать состояние регистров генератора
        } // private void button_read_ONE_Click(object sender, EventArgs e)

        private void button_on_gen_scan_Click(object sender, EventArgs e)
        {
            start_gen_scan(); // после старта , приемник на генераторе отключается, стоповать только синей кнопкой
        }

        private void listBox_BaudRate_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort_MB.BaudRate = Convert.ToInt32(listBox_BaudRate.SelectedItem.ToString());
            registr_user.SetValue("default_baudrate", serialPort_MB.BaudRate);
            label_baudrate.Text = serialPort_MB.BaudRate.ToString();
        }
        private void listBox_ComPort_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort_MB.PortName = listBox_ComPort.SelectedItem.ToString();
            registr_user.SetValue("default_com_port", serialPort_MB.PortName);
            label_ComPort.Text = serialPort_MB.PortName;
        }


        private void listBox_COM_read_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort_read_data.PortName = listBox_COM_read.SelectedItem.ToString();
            registr_user.SetValue("default_com_port_read_data", serialPort_read_data.PortName);
            label_COM_read.Text = serialPort_read_data.PortName;
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
            registr_user.SetValue("Set_Generator.Freq_start", Convert.ToUInt16(textBox_Fstart.Text));
        }

        private void textBox_Power_Leave(object sender, EventArgs e)
        {
            textBox_Power.Text = Power_TextBox(textBox_Power.Text);
            registr_user.SetValue("Set_Generator.Power_proc", Convert.ToUInt16(textBox_Power.Text));
        }

        private void textBox_Step_Leave(object sender, EventArgs e)
        {
            textBox_Step.Text = Step_TextBox(textBox_Step.Text);
            registr_user.SetValue("Set_Generator.F_Step", Convert.ToUInt16(textBox_Step.Text));
        }

        private void textBox_NumPoint_Leave(object sender, EventArgs e)
        {
            textBox_NumPoint.Text =  NumPoint_TextBox(textBox_NumPoint.Text);
            registr_user.SetValue("Set_Generator.N_step", Convert.ToUInt16(textBox_NumPoint.Text));
        }

        private void textBox_Tstep_Leave(object sender, EventArgs e)
        {
            textBox_Tstep.Text = Time_step_TextBox(textBox_Tstep.Text);
            registr_user.SetValue("Set_Generator.Time_Step", Convert.ToUInt16(textBox_Tstep.Text));
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
            if(checkBox_ON_gen.Checked)
            { registr_user.SetValue("Set_Generator.flag_ON_generation", 1); }
            else
            { registr_user.SetValue("Set_Generator.flag_ON_generation", 0); }
        }

        private void checkBox_Tx_Data_cicle_CheckedChanged(object sender, EventArgs e)
        {
            Set_Generator.flag_ON_TxData_cicle = checkBox_Tx_Data_cicle.Checked;
            if (checkBox_Tx_Data_cicle.Checked)
            { registr_user.SetValue("Set_Generator.flag_ON_TxData_cicle", 1); }
            else
            { registr_user.SetValue("Set_Generator.flag_ON_TxData_cicle", 0); }
        }

        private void checkBox_ON_scan_CheckedChanged(object sender, EventArgs e)
        {
            Set_Generator.flag_ON_scan_freq = checkBox_ON_scan.Checked;
            if (checkBox_ON_scan.Checked) 
                { checkBox_scan_time.Checked = false; }
            if (checkBox_ON_scan.Checked)
            { registr_user.SetValue("Set_Generator.flag_ON_scan_freq", 1); }
            else
            { registr_user.SetValue("Set_Generator.flag_ON_scan_freq", 0); }
        }
        private void checkBox_scan_time_CheckedChanged(object sender, EventArgs e)
        {
            Set_Generator.flag_ON_scan_time = checkBox_scan_time.Checked;
            if (checkBox_scan_time.Checked) 
                { checkBox_ON_scan.Checked = false; }
        }

        private  void button_cicle_read_Click(object sender, EventArgs e)
        {
            init_COM_port_MB();
            button_stop_read.Enabled = true;
            button_cicle_read.Enabled = false;
            if (serialPort_read_data.IsOpen == false)
            { serialPort_read_data.Open(); }
            byte[] cmd_read_1 = { 7, 4, 0, 64, 0, 0 }; // для совместимости
            if(checkBox_ON_scan.Checked)
                { _ = Read_cicle_scan_freq(cmd_read_1);}
 //           if (checkBox_scan_time.Checked)
 //               { _ = Read_cicle_scan_time(cmd_read_1); }
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

        private void button_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(((Button)sender).Name.Substring(1));
            open_data_SpLab(n);
        }

        private void button_stop_read_Click(object sender, EventArgs e)
        {
            button_stop_read.Enabled=false;
            button_cicle_read.Enabled =true;
            serialPort_read_data.Close();
        }


        private void button_sender(object sender)
        {
            button_stop_read.Enabled = false;
            button_cicle_read.Enabled = true;
        }

        private void button_EventArgs(object sender, EventArgs e)
        {
            button_stop_read.Enabled = false;
            button_cicle_read.Enabled = true;
        }

        private void button_all(object sender, EventArgs e)
        {
            button_stop_read.Enabled = false;
            button_cicle_read.Enabled = true;
        }

        private void checkBox_Phase_CheckedChanged(object sender, EventArgs e)
        {
            otrisovka_graf_listbox(data_freq[0].Fmin, data_freq[0].Fmax); 
        }







        // =============== вариант с переопределением при наследовании класса, кнопка ТАВ не работает при этом
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        // // private bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.Left)) { numeric_Up_Down(-1, (double)numericUpDown_mouse.Value - 1); }
        //    if (keyData == (Keys.Right)) { numeric_Up_Down(1, (double)numericUpDown_mouse.Value + 1); }
        //    return true;// base.ProcessCmdKey(ref msg, keyData);
        //}

    }
}
