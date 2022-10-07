using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Drawing;
using Modbus.Device;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Read_Modbus_UsbCDC_stm32G4
{


    public partial class Form1
    {
        RegistryKey registr_user;
        void init_start_data_registry()
        {
            // подгрузить стартовые данные, от после последней работы
            num_point_freq_zamer = 28500;
            freq_begin_band = 14500;
            Set_Generator.Freq_start = 14500;
            Set_Generator.F_Step = 10;
            Set_Generator.Power_proc = 2;
            Set_Generator.N_step = 1000;
            Set_Generator.Time_Step = 25;
            Set_Generator.flag_ON_autoTuning_freq = false;
            Set_Generator.flag_ON_generation = false;
            Set_Generator.flag_ON_scan_freq = false;
            Set_Generator.flag_ON_autoTuning_freq = false;
            path_directory = @"C:\Users\" + Environment.UserName + @"\source\repos\Read_Modbus_stm32G4\файлы_замеров_АЧХ";
            default_com_port = "COM1";
            default_baudrate = 921600;

            // а теперь читаем, если там есть что осмысленное, переназначить
             registr_user = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + GetType().Namespace, true);
            if (registr_user == null)
            {
                MessageBox.Show(" не удалось создать в реестре папку " + registr_user.Name?.ToString() + "\nпоэтому данные будут по-умолчанию");
            }
            else
            {   
                if(registr_user.GetValue("num_point_freq_zamer") != null)
                { num_point_freq_zamer = Convert.ToInt32(registr_user.GetValue("num_point_freq_zamer")); }

                if (registr_user.GetValue("freq_begin_band") != null)
                { freq_begin_band = Convert.ToInt32(registr_user.GetValue("freq_begin_band")); }

                if (registr_user.GetValue("Set_Generator.Freq_start") != null)
                { Set_Generator.Freq_start = (ushort)Convert.ToInt32(registr_user.GetValue("Set_Generator.Freq_start")); }

                if (registr_user.GetValue("Set_Generator.F_Step") != null)
                { Set_Generator.F_Step = (ushort)Convert.ToInt32(registr_user.GetValue("Set_Generator.F_Step")); }

                if (registr_user.GetValue("Set_Generator.Power_proc") != null)
                { Set_Generator.Power_proc = (ushort)Convert.ToInt32(registr_user.GetValue("Set_Generator.Power_proc")); }

                if (registr_user.GetValue("Set_Generator.N_step") != null)
                { Set_Generator.N_step = (ushort)Convert.ToInt32(registr_user.GetValue("Set_Generator.N_step")); }

                if (registr_user.GetValue("Set_Generator.Time_Step") != null)
                { Set_Generator.Time_Step = (ushort)Convert.ToInt32(registr_user.GetValue("Set_Generator.Time_Step")); }

                if (registr_user.GetValue("Set_Generator.flag_ON_autoTuning_freq") != null)
                    Set_Generator.flag_ON_autoTuning_freq = (0 < (int)registr_user.GetValue("Set_Generator.flag_ON_autoTuning_freq"))? true: false;

                if (registr_user.GetValue("Set_Generator.flag_ON_generation") != null)
                    Set_Generator.flag_ON_generation = (0 < (int)registr_user.GetValue("Set_Generator.flag_ON_generation")) ? true : false;

                if (registr_user.GetValue("Set_Generator.flag_ON_scan_freq") != null)
                    Set_Generator.flag_ON_scan_freq = (0 < (int)registr_user.GetValue("Set_Generator.flag_ON_scan_freq")) ? true : false; ;

                if (registr_user.GetValue("Set_Generator.flag_ON_autoTuning_freq") != null)
                    Set_Generator.flag_ON_autoTuning_freq = (0 < (int)registr_user.GetValue("Set_Generator.flag_ON_autoTuning_freq")) ? true : false; ;

                if (registr_user.GetValue("path_directory") != null)
                { path_directory = registr_user.GetValue("path_directory").ToString(); }

                if (registr_user.GetValue("default_com_port") != null)
                { default_com_port = registr_user.GetValue("default_com_port").ToString(); }

                if (registr_user.GetValue("default_baudrate") != null)
                { default_baudrate = Convert.ToInt32(registr_user.GetValue("default_baudrate")); }
            }
        }

        public void add_text_ComPort()
        {
            // чтение портов доступных в системе
            string[] ports = SerialPort.GetPortNames();
            // Очистка содержимого бокса
            listBox_ComPort.Items.Clear();
            // Добавление найденных портов в бокс
            listBox_ComPort.Items.AddRange(ports);
            label_ComPort.Text = serialPort_MB.PortName;
        } // public void add_text_ComPort()
        private void init_COM_port()
        {
            if (listBox_ComPort.Text == "")
            { serialPort_MB.PortName = default_com_port; }
            else
            { serialPort_MB.PortName = listBox_ComPort.Text; }

            if (listBox_BaudRate.Text == "")
            { serialPort_MB.BaudRate = default_baudrate; }
            else
            { serialPort_MB.BaudRate = Convert.ToInt32(listBox_BaudRate.Text); }

            serialPort_MB.DataBits = 8;
            serialPort_MB.ReadTimeout = 1000;
            serialPort_MB.WriteTimeout = 500;
            serialPort_MB.Parity = Parity.None;
            serialPort_MB.StopBits = StopBits.One;
            serialPort_MB.RtsEnable = true;
            label_baudrate.Text = serialPort_MB.BaudRate.ToString();
        } // private void init_COM_port()

        private void init_Set_Generator()
        {
            // эти данные будут подсасываться из реестра, здесь их надо отрисовать по форме
            checkBox_ON_gen.Checked = Set_Generator.flag_ON_generation;
            checkBox_Tx_Data_cicle.Checked = Set_Generator.flag_ON_TxData_cicle;
            checkBox_ON_scan.Checked = Set_Generator.flag_ON_scan_freq;
            // todo ==> checkBox_ON_autoTuning_freq.Checked = Set_Generator.flag_ON_autoTuning_freq;
            textBox_Fstart.Text =  Set_Generator.Freq_start.ToString();
            textBox_Power.Text =  Set_Generator.Power_proc.ToString();
            textBox_Step.Text = Set_Generator.F_Step.ToString();
            textBox_Tstep.Text = Set_Generator.Time_Step.ToString();
            textBox_NumPoint.Text = Set_Generator.N_step.ToString();
            Calculate_Fend(); // не храним, вычисляем по месту
        }// private void init_Set_Generator()

        void init_chart()
        {
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                chart1.Series[i].Points.Clear(); // очистка   array_data_freq
                chart1.ChartAreas[i].AxisX.Maximum = freq_begin_band + num_point_freq_zamer;
                chart1.ChartAreas[i].AxisX.Minimum = freq_begin_band;
                chart1.ChartAreas[i].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[i].CursorX.LineWidth = 1;
                chart1.ChartAreas[i].CursorX.LineColor = Color.Blue;
                chart1.ChartAreas[i].CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            }
            numericUpDown_mouse.Maximum = freq_begin_band + num_point_freq_zamer;
            numericUpDown_mouse.Minimum = freq_begin_band;
            if ((Set_Generator.Freq_start < freq_begin_band) || (Set_Generator.Freq_start > freq_begin_band + num_point_freq_zamer))
                { numericUpDown_mouse.Value = freq_begin_band; }
            else
                { numericUpDown_mouse.Value = Set_Generator.Freq_start; }

            // добавим накладные графики
            //ChartArea chartArea107 = chart1.ChartAreas[0];// new ChartArea();
            //chartArea107.Name = "ChartArea107";
            //chart1.ChartAreas.Add(chartArea107);
            //ChartArea chartArea108 = chart1.ChartAreas[1];
            //chartArea108.Name = "ChartArea108";
            //chart1.ChartAreas.Add(chartArea108);
            //ChartArea chartArea109 = chart1.ChartAreas[2];
            //chartArea109.Name = "ChartArea109";
            //chart1.ChartAreas.Add(chartArea109);
            //ChartArea chartArea110 = chart1.ChartAreas[3];
            //chartArea110.Name = "ChartArea110";
            //chart1.ChartAreas.Add(chartArea110);

            //Series series107 = chart1.Series[0];
            //series107.BorderWidth =1;
            //series107.ChartArea = "ChartArea107";
            //chart1.Series.Add(series107);

            //Series series108 = chart1.Series[1];
            //series108.BorderWidth = 1;
            //series108.ChartArea = "ChartArea108";
            //chart1.Series.Add(series108);

            //Series series109 = chart1.Series[2];
            //series109.BorderWidth = 1;
            //series109.ChartArea = "ChartArea109";
            //chart1.Series.Add(series109);

            //Series series110 = chart1.Series[3];
            //series110.BorderWidth = 1;
            //series110.ChartArea = "ChartArea110";
            //chart1.Series.Add(series110);
        }

        void init_info_data_chart()
        {
            for (int i = 0; i < 6; i++)
            { info_data_chart.Add(new info_data_chart_class()); }

            info_data_chart[0].listbox_data_graf = listBox1;
            info_data_chart[1].listbox_data_graf = listBox2;
            info_data_chart[2].listbox_data_graf = listBox3;
            info_data_chart[3].listbox_data_graf = listBox4;
            info_data_chart[4].listbox_data_graf = listBox5;
            info_data_chart[5].listbox_data_graf = listBox6;
            info_data_chart[0].checkBox_phase = checkBox1;
            info_data_chart[1].checkBox_phase = checkBox2;
            info_data_chart[2].checkBox_phase = checkBox3;
            info_data_chart[3].checkBox_phase = checkBox4;
            info_data_chart[4].checkBox_phase = checkBox5;
            info_data_chart[5].checkBox_phase = checkBox6;
            for (int i=3; i<6; i++)
            {
                info_data_chart[i].label_name_file = new System.Windows.Forms.Label();
                info_data_chart[i].label_name_file.Text = i.ToString();
                info_data_chart[i].label_name_file.AutoSize = true;
                info_data_chart[i].label_name_file.Size = new System.Drawing.Size(75, 14);
                info_data_chart[i].label_name_file.Location = new System.Drawing.Point(5, info_data_chart[i].listbox_data_graf.Location.Y);
                Controls.Add(info_data_chart[i].label_name_file);

                info_data_chart[i].Button_download = new System.Windows.Forms.Button();
                info_data_chart[i].Button_download.Name = "b" + i.ToString();
                info_data_chart[i].Button_download.Location = new Point(16, info_data_chart[i].listbox_data_graf.Location.Y+ info_data_chart[i].label_name_file.Size.Height +2);
                info_data_chart[i].Button_download.Size = new Size(75, 58);
                info_data_chart[i].Button_download.Text = "загрузка данных из SpLab";
                info_data_chart[i].Button_download.UseVisualStyleBackColor = true;
                info_data_chart[i].Button_download.Click += new System.EventHandler(this.button_Click);
                Controls.Add(info_data_chart[i].Button_download);
            }
        }



    } // public partial class Form1

} // namespace Read_Modbus_UsbCDC_stm32G4
