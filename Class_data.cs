using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Read_Modbus_UsbCDC_stm32G4
{
    struct Set_Generator_struct
    {
        //	Reg_CMD_Buf[0] - регистр флагов-команд, приходящих для исполнения
        public bool flag_ON_generation;        //	Reg_CMD_Buf[0].0 - флаг-команда Включить Генерацию
        public bool flag_ON_scan_freq;         //	Reg_CMD_Buf[0].1 - флаг-команда Вкл. Скольжение по диапазону, в соответствии с задаными регистрами
        public bool flag_ON_TxData_cicle;      //	Reg_CMD_Buf[0].2 - флаг-команда Вкл. долбежку передачи данных по кругу, прием при этом прекратиться, стоповать можно будет только синей кнопкой
        public bool flag_ON_autoTuning_freq;   //	Reg_CMD_Buf[0].3 - флаг-команда при включеной генерации автоподстройка частоты будет работать, если включен флаг скольжения, этот флаг игнорится
        public bool flag_ON_scan_time;         //	Reg_CMD_Buf[0].4 - флаг-команда на вкл генерации на одной частоте, и циклическую передачу двух сигналов ТОК и НАПРЯЖЕНИЕ в реале, как есть из замера 

        public UInt16 Power_proc;  //	Reg_CMD_Buf[1] - регистр мощности,  2-98% заполнения
        public UInt16 Freq_start;  //	Reg_CMD_Buf[2] - регистр стартовой частоты, 14500-43000
        public UInt16 F_Step;      //	Reg_CMD_Buf[3] - регистр step(1-25гц) перемещения частоты, при сканировании диапазона, при сканировании старт будет Reg_CMD_Buf[2], максимум = (Reg_CMD_Buf[2] + step*_N-количество_)
        public UInt16 Time_Step;   //	Reg_CMD_Buf[4] - регистр время милисекунд, между степами (10-1000мс)
        public UInt16 N_step;      //	Reg_CMD_Buf[5] - регистр N-количество степов при сканировании 0-1000
    }

    class info_data_chart_class
    {
        public Button Button_download;
        public ListBox listbox_data_graf;
        public Label label_name_file;
        public CheckBox checkBox_phase;
        public info_data_chart_class()
        {
            Button Button_download = new Button();
            ListBox listBox = new ListBox();
            Label label = new Label();
            CheckBox checkBox_phase = new CheckBox();
        }
    }

    class Class_data_read_time
    {
        public struct pin_data_struct
        {
            public float[] y_float ;
            public float[] y_float_old;
            public int width;
        }

        public pin_data_struct[] pin_Data_1000 = new pin_data_struct[1024];

        public Class_data_read_time()
        {
            for(int i = 0; i < 1024; i++)
            { 
                pin_Data_1000[i].y_float = new float[12];
                pin_Data_1000[i].y_float_old = new float[12];
            }
        }

        public int start_index_paket;
        public int end_index_paket;
        public int count_index_paket;
        private int t;
        private int t_old =1025;
        public void Decode_string_to_data(byte[] data, int len) // data == входной считаный массив
        {
            int start_index_paket ;
            if (len > 84)
            {
                count_index_paket = len / 85;
                for (int n=0; n< count_index_paket; n++)
                {
                    for(int i=0; i<82; i++ )
                    {
                        int n85i = n * 85 + i;
                        // (array_read[0] == 7)     // adr_slave) // адрес устройства, которое отвечает
                        // (array_read[1] == 4)     // num_cmd) // код команды, от устройства, как там понято
                        // (array_read[2] == 80)    // в этом байте длина пакета данных
                        if ((data[n85i] == 7) & (data[n85i + 1] == 4) & (data[n85i + 2] == 80)) // нашли начало пакета, раскидать надо
                        {
                            // пакет 80 байт словили, теперь проверка CRC // пакет 80 байт словили, теперь проверка CRC // пакет 80 байт словили, теперь проверка CRC
                            byte[] data_temp_crc = new byte[83];
                            for (int m = 0; m < 83; m++)
                                { data_temp_crc[m] = data[n85i + m]; }
                            byte[] data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(data_temp_crc);
                            byte crc_0 = data[n85i + 83];
                            byte crc_1 = data[n85i + 84];

                            if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1)) // CRC совпал - удача
                            {
                                t = (int)(BitConverter.ToSingle(data_temp_crc, 3)); // это есть индекс пришедшего пакета, по времени
                                //if (t_old > t)  // значит пошел новый пакет, старый надо прорисовать тоненько
                                //{
                                //    for (int x = 0; x < 1024; x++)
                                //    {
                                //        for (int g = 0; g < 6; g++)
                                //        { 
                                //            pin_Data_1000[x].y_float_old[g] = pin_Data_1000[x].y_float[g];
                                //            pin_Data_1000[x].y_float[g] = 0;
                                //        }
                                //    }
                                //}
                                t_old = t;

                                pin_Data_1000[t + 0].y_float[0] = BitConverter.ToSingle(data_temp_crc, 7);
                                pin_Data_1000[t + 1].y_float[0] = BitConverter.ToSingle(data_temp_crc, 11);
                                pin_Data_1000[t + 2].y_float[0] = BitConverter.ToSingle(data_temp_crc, 15);
                                pin_Data_1000[t + 0].y_float[1] = BitConverter.ToSingle(data_temp_crc, 19);
                                pin_Data_1000[t + 1].y_float[1] = BitConverter.ToSingle(data_temp_crc, 23);
                                pin_Data_1000[t + 2].y_float[1] = BitConverter.ToSingle(data_temp_crc, 27);
                                pin_Data_1000[t + 0].y_float[2] = BitConverter.ToSingle(data_temp_crc, 31);
                                pin_Data_1000[t + 1].y_float[2] = BitConverter.ToSingle(data_temp_crc, 35);
                                pin_Data_1000[t + 2].y_float[2] = BitConverter.ToSingle(data_temp_crc, 39);
                                pin_Data_1000[t + 0].y_float[3] = BitConverter.ToSingle(data_temp_crc, 43);
                                pin_Data_1000[t + 1].y_float[3] = BitConverter.ToSingle(data_temp_crc, 47);
                                pin_Data_1000[t + 2].y_float[3] = BitConverter.ToSingle(data_temp_crc, 51);
                                pin_Data_1000[t + 0].y_float[4] = BitConverter.ToSingle(data_temp_crc, 55);
                                pin_Data_1000[t + 1].y_float[4] = BitConverter.ToSingle(data_temp_crc, 59);
                                pin_Data_1000[t + 2].y_float[4] = BitConverter.ToSingle(data_temp_crc, 63);
                                pin_Data_1000[t + 0].y_float[5] = BitConverter.ToSingle(data_temp_crc, 67);
                                pin_Data_1000[t + 1].y_float[5] = BitConverter.ToSingle(data_temp_crc, 71);
                                pin_Data_1000[t + 2].y_float[5] = BitConverter.ToSingle(data_temp_crc, 75);
                                i +=  84; // весь обработаный пакет, если все совпало, прокинуть и перейти к следующему
                            }
                        }
                    }
                }
            }
        }
    }
    class Class_data :  IComparable  
    {
        public UInt16 Fmin = 14500; // минимальная частота,  freq - не должен выходить за эти пределы
        public UInt16 Fmax = 43000; // максимальная частота,  freq - не должен выходить за эти пределы

        private static UInt16 max_chanel_zamer = 16;
        private UInt16 freq; // если будут приходить значения не вписывающиеся в пределы, то ставить их на концы диапазонов
        public UInt16 Freq
        {
            get
            {  return freq; }
            set
            {
                if (value < Fmin) 
                { freq = Fmin; }
                else
                {
                    if  (Freq > Fmax) 
                    { freq = Fmax; }
                    else
                    { freq = value; }
                }
            }
        }

        public UInt16 Max_Chanel_Zamer // сколько каналов замера будет гнать STM по modbus
        {
            get
            { return max_chanel_zamer; }
            set
            { max_chanel_zamer = Max_Chanel_Zamer; }
        }

        public float[] val = new float[max_chanel_zamer]; // тут собственно и будут валяться пришедшие данные
        public bool flag_yes; // ==true значит данные по этой частоте пришли,  == false -нет

        public string form_one_string_ListBox(UInt16 F_num , float val_num)
        {
            string stroka_ListBox ="";
            //if ((num < max_chanel_zamer) && (flag_yes == true)) 
            //    { stroka_ListBox = Freq.ToString("D5") + "= " + val[num].ToString() + "\n"; }
            stroka_ListBox = F_num.ToString("D5") + "= " + val_num.ToString() + Environment.NewLine;
            return stroka_ListBox;
        }
        public string form_one_string_file()
        {
            string stroka_file = "";
            if (flag_yes == true)
            {
                stroka_file = "#D\t" + Freq.ToString() + "\t";
                for (int i = 0; i < max_chanel_zamer; i++)
                 { stroka_file += val[i].ToString() + "\t"; }
                stroka_file += "\n";
            }
            return stroka_file;
        }

        public void clear_data()
        {
            Array.Clear(val, 0, val.Length);
            freq = 0;
            flag_yes = false;
        }

        public int CompareTo(object obj)
        {
            return Freq.CompareTo(((Class_data)obj).Freq);
        }

        public Class_data()
        {; }
        public Class_data(ushort KFreq, float[] Kval, bool Kflag)
        {
            Freq = KFreq;
            Array.Copy(Kval, val, val.Length);
            flag_yes = Kflag;
        }
        public Class_data(Class_data g)
        {
            Freq = g.Freq;
            Array.Copy(g.val, val, g.val.Length);
            flag_yes = g.flag_yes;
        }

    }
}
