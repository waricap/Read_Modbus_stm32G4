
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Modbus.Device;
using System.Drawing;
using System.Windows.Forms;

namespace Read_Modbus_UsbCDC_stm32G4
{

    public partial class Form1
    {
        void numeric_Up_Down_change()
        {
            ushort index_X = (ushort)numericUpDown_mouse.Value;
            Class_data data_freq_point= new Class_data(); // заданую точку частоты
            if (data_freq.Count >0)
            {
                ushort index_find = index_X;
                for(int i = 0; i < data_freq.Count; i++)
                {
                    for (ushort step = 0; step < 16; step++)
                    {
                        if (data_freq[i].Freq == (index_X + step))
                        {
                            index_find = data_freq[i].Freq;
                            i = data_freq.Count + 1;
                            break;
                        }
                        else
                        {
                            if (data_freq[i].Freq == (index_X - step))
                            {
                                index_find = data_freq[i].Freq;
                                i = data_freq.Count + 1;
                                break;
                            }
                        }
                    }// for (ushort step = 0; step < 16; step++)
                }
                index_X = index_find ;
                numericUpDown_mouse.Value = index_X;
            }
 

            for (int i = 0; i < chart1.ChartAreas.Count; i++)
                { chart1.ChartAreas[i].CursorX.Position = index_X; }

            int width_chart = Convert.ToInt32(chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].AxisX.Minimum);
            int label_X = (index_X - (int)chart1.ChartAreas[0].AxisX.Minimum) * chart1.Width / width_chart + chart1.Location.X;
            int koord_Y; // координата по вертикали label_chart_mouse[] для каждого графика
            for (int i = 0; i < 6; i++)
            {
                label_chart_marker[i].Text = data_freq_point.val[i].ToString() ; //  в каждый лейбл впишем значение этого графика
                // найти положение каждого лейбла по высоте, ну чтоб красиво было
                koord_Y = chart1.Location.Y + chart1.Height * ((int)chart1.ChartAreas[i].Position.Y) / 100;
                label_chart_marker[i].Location = new Point(label_X, koord_Y);
                // тут же пока все ясно, выделим строку в listbox соответствующего графика
                string  temp_str = "";
                for (int j = 0; j < listbox_arr_data_graf[i].Items.Count; j++)
                {
                    temp_str = listbox_arr_data_graf[i].Items[j].ToString();
                    if (temp_str.Length > 7)
                    {
                        temp_str = temp_str.Remove(5, (temp_str.Length - 5));
                        if (int.Parse(temp_str) == index_X)
                        {
                            listbox_arr_data_graf[i].SelectedIndex = j;
                            break;
                        }
                    }
                } // for (int j = 0; j < listbox_arr_data_graf[i].Items.Count; j++)
            } // for (int i = 0; i < 6; i++)

            numericUpDown_mouse.Location = new Point(label_X + 2, chart1.Location.Y + chart1.Height - numericUpDown_mouse.Size.Height - 4);
        }

        private void prorisovka_line_mouse_code(object sender, MouseEventArgs e)
        {
            int index_Chart = 0;
            switch (e.Y * 100 / chart1.Height) // коорд внутри chart1 переводится в проценты положения области графика
            {
                case int proc when (proc >= 0 & proc < chart1.ChartAreas[1].Position.Y):
                    index_Chart = 0;
                    break;

                case int proc when (proc >= chart1.ChartAreas[1].Position.Y & proc < chart1.ChartAreas[2].Position.Y):
                    index_Chart = 1;
                    break;

                case int proc when (proc >= chart1.ChartAreas[2].Position.Y & proc < chart1.ChartAreas[3].Position.Y):
                    index_Chart = 2;
                    break;

                case int proc when (proc >= chart1.ChartAreas[3].Position.Y & proc < chart1.ChartAreas[4].Position.Y):
                    index_Chart = 3;
                    break;

                case int proc when (proc >= chart1.ChartAreas[4].Position.Y & proc < chart1.ChartAreas[5].Position.Y):
                    index_Chart = 4;
                    break;

                case int proc when (proc >= chart1.ChartAreas[5].Position.Y):
                    index_Chart = 5;
                    break;
            }

            for (int i = 0; i < 6; i++)
                { chart1.ChartAreas[i].CursorX.Position = chart1.ChartAreas[index_Chart].CursorX.Position;  }

            numericUpDown_mouse.Value = (int)chart1.ChartAreas[0].CursorX.Position;
            // а потом щёлкнет событие   numeric_Up_Down_change,  и будут разрисованы label_chart_mouse[] и все их данные
        }

        private void otrisovka_graf_listbox(int f_min, int f_max )
        {
            string s;
            for (ushort i = 0; i < 6; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.ChartAreas[i].AxisX.Maximum = f_max;
                chart1.ChartAreas[i].AxisX.Minimum = f_min;
                listbox_arr_data_graf[i].Items.Clear();

                for(int j = 0; j < data_freq.Count; j++)
                {
                    if (data_freq[j].flag_yes)
                    {
                        chart1.Series[i].Points.AddXY(data_freq[j].Freq, data_freq[j].val[i]);
                        s = data_freq[j].form_one_string_ListBox(data_freq[j].Freq, data_freq[j].val[i]);
                        listbox_arr_data_graf[i].Items.Add(s);
                    }
                }
            }
            numericUpDown_mouse.Maximum = f_max;
            numericUpDown_mouse.Minimum = f_min;
        }
    }
}