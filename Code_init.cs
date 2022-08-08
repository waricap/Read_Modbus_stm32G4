using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Drawing;
using Modbus.Device;

namespace Read_Modbus_UsbCDC_stm32G4
{


    public partial class Form1
    {
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
            { serialPort_MB.PortName = "COM8"; }
            else
            { serialPort_MB.PortName = listBox_ComPort.Text; }

            if (listBox_BaudRate.Text == "")
            { serialPort_MB.BaudRate = 921600; }
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
            Set_Generator.flag_ON_generation = false;
            Set_Generator.flag_ON_scan_freq = false;
            Set_Generator.flag_ON_autoTuning_freq = false;
            Set_Generator.flag_ON_TxData_cicle = false;
            Set_Generator.Freq_start = Convert.ToUInt16(textBox_Fstart.Text);
            Set_Generator.Power_proc = Convert.ToUInt16(textBox_Power.Text);
            Set_Generator.F_Step = Convert.ToUInt16(textBox_Step.Text);
            Set_Generator.Time_Step = Convert.ToUInt16(textBox_Tstep.Text);
            Set_Generator.N_step = Convert.ToUInt16(textBox_NumPoint.Text);
            Calculate_Fend();
        }// private void init_Set_Generator()

        void init_chart()
        {
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                chart1.ChartAreas[i].AxisX.Maximum = 28500;
                chart1.ChartAreas[i].AxisX.Minimum = 0;
                chart1.ChartAreas[i].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[i].CursorX.LineWidth = 1;
                chart1.ChartAreas[i].CursorX.LineColor = Color.Blue;
                chart1.ChartAreas[i].CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            }
        }



    } // public partial class Form1

} // namespace Read_Modbus_UsbCDC_stm32G4
