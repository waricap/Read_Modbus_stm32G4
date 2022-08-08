﻿
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
            int index_X = (int)numericUpDown_mouse.Value;

            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            { chart1.ChartAreas[i].CursorX.Position = index_X; }

            // chart1.ChartAreas[i].AxisX.Maximum

            int x_Coord = (int)chart1.ChartAreas[0].CursorX.Position;
            int width_chart = Convert.ToInt32(chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].AxisX.Minimum);
            int label_X = (index_X - (int)chart1.ChartAreas[0].AxisX.Minimum) * chart1.Width / width_chart + chart1.Location.X;
            // e.X координата мыши по шкале от 0 до chart1.Width
            numericUpDown_mouse.Value = x_Coord;
            int koord_Y;
            for (int i = 0; i < 6; i++)
            {
                label_chart_mouse[i].Text = array_data_freq[i, x_Coord - 14500].ToString();
                koord_Y = chart1.Location.Y + chart1.Height * ((int)chart1.ChartAreas[i].Position.Y) / 100;
                label_chart_mouse[i].Location = new Point(label_X, koord_Y);
            }

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

            int x_Coord = (int)chart1.ChartAreas[0].CursorX.Position;
            // если н аэтой точке нет замера, надо перейти на следующую, искать будем ближайшую
            if (array_data_freq[7, x_Coord - 14500] == 0) 
            {
                for (int i = 0; i < 500; i++)
                {
                    if (array_data_freq[7, x_Coord - 14500 +i] > 0) // значит нашли то что надо
                    {
                        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
                    }

                }
            }
            int label_X = e.X + chart1.Location.X;
            // e.X координата мыши по шкале от 0 до chart1.Width
            // chart1.ChartAreas[0].AxisX.Maximum
            //
            numericUpDown_mouse.Value = x_Coord;
            int koord_Y;
            for (int i = 0; i < 6; i++)
            {
                label_chart_mouse[i].Text = array_data_freq[i+1, x_Coord- 14500].ToString();
                koord_Y = chart1.Location.Y + chart1.Height * ((int)chart1.ChartAreas[i].Position.Y) / 100;
                label_chart_mouse[i].Location = new Point(label_X, koord_Y);
            }
        }

    }
}