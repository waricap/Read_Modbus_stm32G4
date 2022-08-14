using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Modbus_UsbCDC_stm32G4
{
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
    class Class_data : IComparable
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
                if (Freq < Fmin) { freq = Fmin; }
                if  (Freq > Fmax) { freq = Fmax; }
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

        public string form_one_string_ListBox(UInt16 num)
        {
            string stroka_ListBox ="";
            if ((num < max_chanel_zamer) && (flag_yes == true)) 
                { stroka_ListBox = Freq.ToString("D5") + "= " + val[num].ToString() + "\n"; }
            return stroka_ListBox;
        }
        public string form_one_string_file(UInt16 num)
        {
            string stroka_file = "";
            if ((num < max_chanel_zamer) && (flag_yes == true))
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
            Array.Copy(g.val, val, val.Length);
            flag_yes = g.flag_yes;
        }

    }
}
