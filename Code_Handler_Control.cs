using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Modbus.Device;

namespace Read_Modbus_UsbCDC_stm32G4
{

    public partial class Form1
    {
        int v_43000 = freq_begin_band + num_point_freq_zamer;
        private void Calculate_Fend()
        {
            label_Fend.Text = "F_end= " + (Set_Generator.Freq_start + Set_Generator.F_Step * Set_Generator.N_step).ToString() +" hz";
        }
        private string Freq_TextBox(string manual_input)
        {
            ushort freq_int;
            try
            {
                freq_int = Convert.ToUInt16(manual_input);
                if (freq_int < freq_begin_band) { freq_int = (ushort)freq_begin_band; }
                if (freq_int > v_43000) { freq_int = (ushort)v_43000; }
            }
            catch
            { freq_int = 25000; }

            Set_Generator.Freq_start = freq_int;
            textBox_NumPoint.Text = NumPoint_TextBox(textBox_NumPoint.Text);
            Calculate_Fend();
            return freq_int.ToString();
        } // private string Freq_TextBox(string manual_input)

        private string Power_TextBox(string manual_input)
        {
            UInt16 power_int;
            try
            {
                power_int = Convert.ToUInt16(manual_input);
                if (power_int < 2) { power_int = 2; }
                if (power_int > 98) { power_int = 98; }
            }
            catch
            { power_int = 2; }

            Set_Generator.Power_proc = power_int;
            return power_int.ToString();
        } // private string Power_TextBox(string manual_input)

        private string Step_TextBox(string manual_input)
        {
            UInt16 Step_int;
            try
            {
                Step_int = Convert.ToUInt16(manual_input);
                if (Step_int < 1) { Step_int = 1; }
                if (Step_int > 25) { Step_int = 25; }
            }
            catch
            { Step_int = 1; }

            Set_Generator.F_Step = Step_int;
            textBox_NumPoint.Text = NumPoint_TextBox(textBox_NumPoint.Text);
            Calculate_Fend();
            return Step_int.ToString();
        } // private string Step_TextBox(string manual_input)

        private string Time_step_TextBox(string manual_input)
        {
            UInt16 Time_step_int;
            try
            {
                Time_step_int = Convert.ToUInt16(manual_input);
                if (Time_step_int < 10) { Time_step_int = 10; }
                if (Time_step_int > 1000) { Time_step_int = 1000; }
            }
            catch
            { Time_step_int = 10; }

            Set_Generator.Time_Step = Time_step_int;
            return Time_step_int.ToString();
        } //  private string Time_step_TextBox(string manual_input)

        private string NumPoint_TextBox(string manual_input)
        {
            UInt16 NumPoint_int;
            try
            {
                NumPoint_int = Convert.ToUInt16(manual_input);
                if (NumPoint_int < 0) { NumPoint_int = 0; }
                if (NumPoint_int > 1000) { NumPoint_int = 1000; }
                if ((Set_Generator.Freq_start + NumPoint_int * Set_Generator.F_Step) > v_43000)
                { NumPoint_int = (ushort)((v_43000 - Set_Generator.Freq_start) / Set_Generator.F_Step); }
            }
            catch
            { NumPoint_int = 0; }

            Set_Generator.N_step = NumPoint_int;
            Calculate_Fend();
            return NumPoint_int.ToString();
        } // private string NumPoint_TextBox(string manual_input)

    } // public partial class Form1

} // namespace Read_Modbus_UsbCDC_stm32G4