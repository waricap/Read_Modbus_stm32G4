using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Modbus.Device;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using Read_Modbus_UsbCDC_stm32G4;

namespace Read_Modbus_UsbCDC_stm32G4
{


    public partial class Form1
    {
        public string answer_status_cicles = "OK";

        public void start_gen_scan()
        {
            byte[] cmd_write_16 = Write_Cmd_scan_freq();
            string message_status = "";
            byte[] array_read = new byte[255]; // 255 -это максимальный размер, по мере приема будет обрезан
            string status_answer = Read_answer_cmd_scan(ref array_read, // массив полученых данных
                                                            ref message_status, // сообщения отсюда на форму, чё и как, человечьим языком
                                                                cmd_write_16); // массив-команда, которая ушла по модбусу
            byte[] cmd_read_1 = { 7, 4, 0, 64, 0, 0 }; // для совместимости

            serialPort_MB.Close();
        }
        public void read_ONE()
        {
            byte[] cmd_read_1 = Write_CmdRead_one_point_freq(25000);
            string message_status = "";
            byte[] array_read = new byte[255]; // 255 -это максимальный размер, по мере приема будет обрезан
            Class_data temp_data = new Class_data();
            string status_answer = Answer_Read_Register(ref array_read, ref message_status, cmd_read_1);
            serialPort_MB.Close();

            if (status_answer == "OK")
            {
                temp_data.Freq = Convert.ToUInt16(BitConverter.ToSingle(array_read, 3)) ;
                for (int i = 0; i < 16; i++)
                { temp_data.val[i] = BitConverter.ToSingle(array_read, 3 + 4 * i); }
                temp_data.flag_yes = true;
                data_freq[0] = temp_data;
            }

            if (array_read.Length == 0)
            { label_out.Text = " а буфер-то совсем совсем пустой"; }
            else
            {
                listBox_answer_one.Items.Clear();
                for (int ir = 0; ir < array_read.Length; ir++) // CRC 2 байта здесь уже нет
                { listBox_answer_one.Items.Add(ir.ToString() + " " + array_read[ir].ToString()); }
            }
        }
        private byte[] Write_CmdRead_one_point_freq(UInt16 freq)
        {
            if (freq > (ushort)v_43000) { freq = (ushort)v_43000; }
            if (freq < freq_begin_band) { freq = (ushort)freq_begin_band; }
            freq = 1;
            byte Hi = Convert.ToByte(freq >> 8);
            byte Low = Convert.ToByte(freq & 0xff);
            byte[] cmd_read_1 = { 7, 4, 0, 64, Hi, Low };
            byte[] data_CRC = { 0, 0 };
            data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(cmd_read_1);
            Array.Resize(ref cmd_read_1, cmd_read_1.Length + 2);
            Array.Copy(data_CRC, 0, cmd_read_1, (cmd_read_1.Length - 2), data_CRC.Length);

            byte[] read_data = new byte[256];
            init_COM_port_MB();
            if (serialPort_MB.IsOpen == false)
            { serialPort_MB.Open(); }

            serialPort_MB.Write(cmd_read_1, 0, cmd_read_1.Length);
            return cmd_read_1;
        } //  private byte[] Write_CmdRead_one_point_freq(UInt16 freq)

        private string Answer_Read_Register(ref byte[] array_read, ref string message_status, byte[] cmd_arr)
        {
            // byte[] array_read = new byte[255]; // 255 -это максимальный размер, по мере приема будет обрезан
            string answer_status = "OK";
            int count_byte_read = 0;

            try
            {
                int read_int = serialPort_MB.ReadByte();
                uint index_end_recieve = 255;
                while (count_byte_read < index_end_recieve)
                {
                    array_read[count_byte_read] = (byte)read_int;
                    if (array_read[0] == cmd_arr[0])
                    {
                        if (count_byte_read == 0)
                        {
                            count_byte_read++;
                            read_int = serialPort_MB.ReadByte();
                        }
                        else
                        {
                            if (array_read[1] == cmd_arr[1])
                            {
                                if (count_byte_read == 1)
                                {
                                    count_byte_read++;
                                    read_int = serialPort_MB.ReadByte();
                                }
                                else
                                {
                                    index_end_recieve = Convert.ToUInt32(array_read[2]) + 5;
                                    if (count_byte_read < (index_end_recieve - 1))
                                    {
                                        count_byte_read++;
                                        read_int = serialPort_MB.ReadByte();
                                    }
                                    else
                                    {
                                        count_byte_read++;
                                    } //  if (count_byte_read < (index_end_recieve-1))
                                } // if (count_byte_read == 1)
                            } // if (massiv_answer[1] == data_PDU[1])
                        } // if (count_byte_read == 0)
                    } // if (massiv_answer[0] == data_PDU[0]) 
                } // while(read_int >= 0)
                // проверка CRC
                byte crc_0 = array_read[count_byte_read - 2];
                byte crc_1 = array_read[count_byte_read - 1];
                Array.Resize(ref array_read, (count_byte_read - 2));
                byte[] data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(array_read);
                if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                {
                    message_status = " проверка CRC - НОРМ ";
                }
                else
                {
                    message_status = " проверка CRC - ОШИБКА ";
                    answer_status = "ERROR_CRC";
                }
                // перекидос данных
                message_status = message_status + "перекидос данных";
            } // try
            catch (Exception ex)
            {
                label_error.Text = ex.Message;
                message_status = message_status + ex.Message;
                answer_status = "ERROR_TIMEOUT";
            }

            return answer_status;
        } // private string Answer_Read_Register(ref byte[] array_read, ref string message_status, byte[] cmd_arr)

        private byte[] Write_Cmd_scan_freq()
        {
            byte[] cmd_write_16 = { 0x07, 0x10, 0, 0, 0, 0x06, 0x0C, 0, 0x07, 0, 0x02, 0x4E, 0x20, 0, 0x0A, 0, 0x14, 0x03, 0xE8 }; // это пока по дефолту
            cmd_write_16[7] = Convert.ToByte(0);        // Reg_CMD_Buf[0].Hi   пока не используется
            cmd_write_16[8] = Convert.ToByte(0);        //	Reg_CMD_Buf[0] - регистр флагов-команд, приходящих для исполнения
            if (Set_Generator.flag_ON_generation) { cmd_write_16[8] +=      (1<<0); }//	Reg_CMD_Buf[0].0 - флаг-команда Включить Генерацию
            if (Set_Generator.flag_ON_scan_freq) { cmd_write_16[8] +=       (1<<1); }//	Reg_CMD_Buf[0].1 - флаг-команда Вкл. Скольжение по диапазону, в соответствии с задаными регистрами
            if (Set_Generator.flag_ON_TxData_cicle) { cmd_write_16[8] +=    (1<<2); }//	Reg_CMD_Buf[0].2 - флаг-команда Вкл. долбежку передачи данных по кругу, прием при этом прекратиться, стоповать можно будет только синей кнопкой
            if (Set_Generator.flag_ON_autoTuning_freq) { cmd_write_16[8] += (1<<3); }//	Reg_CMD_Buf[0].3 - флаг-команда при включеной генерации автоподстройка частоты будет работать, если включен флаг скольжения, этот флаг игнорится
            if (Set_Generator.flag_ON_scan_time)       { cmd_write_16[8] += (1<<4); }//	Reg_CMD_Buf[0].4 - флаг-команда на вкл генерации на одной частоте, и циклическую передачу двух сигналов ТОК и НАПРЯЖЕНИЕ в реале, как есть из замера 

            cmd_write_16[9] = Convert.ToByte(Set_Generator.Power_proc >> 8);    //	Reg_CMD_Buf[1] - регистр мощности,  2-98% заполнения
            cmd_write_16[10] = Convert.ToByte(Set_Generator.Power_proc & 0xff);
            cmd_write_16[11] = Convert.ToByte(Set_Generator.Freq_start >> 8);   //	Reg_CMD_Buf[2] - регистр стартовой частоты, 14500-43000
            cmd_write_16[12] = Convert.ToByte(Set_Generator.Freq_start & 0xff);
            cmd_write_16[13] = Convert.ToByte(Set_Generator.F_Step >> 8);       //	Reg_CMD_Buf[3] - регистр step(1-25гц) перемещения частоты, при сканировании диапазона, при сканировании старт будет Reg_CMD_Buf[2], максимум = (Reg_CMD_Buf[2] + step*_N-количество_)
            cmd_write_16[14] = Convert.ToByte(Set_Generator.F_Step & 0xff);
            cmd_write_16[15] = Convert.ToByte(Set_Generator.Time_Step >> 8);    //	Reg_CMD_Buf[4] - регистр время милисекунд, между степами (10-1000мс)
            cmd_write_16[16] = Convert.ToByte(Set_Generator.Time_Step & 0xff);
            cmd_write_16[17] = Convert.ToByte(Set_Generator.N_step >> 8);       //	Reg_CMD_Buf[5] - регистр N-количество степов при сканировании 0-1000
            cmd_write_16[18] = Convert.ToByte(Set_Generator.N_step & 0xff);
            byte[] data_CRC = { 0, 0 };
            data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(cmd_write_16);
            Array.Resize(ref cmd_write_16, cmd_write_16.Length + 2);
            Array.Copy(data_CRC, 0, cmd_write_16, (cmd_write_16.Length - 2), data_CRC.Length);

            try
            {
                init_COM_port_MB();
                if (serialPort_MB.IsOpen == false)
                { serialPort_MB.Open(); }
                serialPort_MB.Write(cmd_write_16, 0, cmd_write_16.Length);
            }
            catch (Exception ex)
            { label_error.Text = ex.Message; }

            return cmd_write_16;
        } // private byte[] Write_Cmd_scan_freq()

        private string Read_answer_cmd_scan(ref byte[] array_read, // массив полученых в ответ данных, STM долбит непрерывно
                                                ref string message_status, // сообщения отсюда на форму, чё и как, человечьим языком
                                                byte[] cmd_arr) // массив-команда, которая ушла по модбусу
        {
            string answer_status = "OK";
            int count_byte_read = 0;
            byte[] massiv_answer = new byte[1024];

            try
            {
                uint index_end_recieve = 255;
                int read_int = serialPort_MB.ReadByte();

                    while (count_byte_read < index_end_recieve)
                    {
                        massiv_answer[count_byte_read] = (byte)read_int;
                        if (massiv_answer[0] == cmd_arr[0]) // адрес устройства, которое отвечает
                        {
                            if (count_byte_read == 0)
                            {
                                count_byte_read++;
                                read_int = serialPort_MB.ReadByte();
                            }
                            else
                            {
                                if (massiv_answer[1] == cmd_arr[1]) // код команды, от устройства, как там понято
                                {
                                    if (count_byte_read == 1)
                                    {
                                        count_byte_read++;
                                        read_int = serialPort_MB.ReadByte();
                                    }
                                    else
                                    {
                                        index_end_recieve = 8; // это длина при правильном ответе на команду 16
                                        if (count_byte_read < (index_end_recieve - 1))
                                        {
                                            count_byte_read++;
                                            read_int = serialPort_MB.ReadByte();
                                        }
                                        else
                                        {
                                            count_byte_read++;
                                        } //  if (count_byte_read < (index_end_recieve-1))
                                    } // if (count_byte_read == 1)
                                } // if (massiv_answer[1] == data_PDU[1])
                                else
                                {
                                    label_error.Text = " ошибка какая то пришла ";
                                    index_end_recieve = 5; //  длина ошибочного сообщения на команду 16, с кодом ошибки и CRC кодом
                                    if (count_byte_read < (index_end_recieve - 1))
                                    {
                                        count_byte_read++;
                                        read_int = serialPort_MB.ReadByte();
                                    }
                                    else
                                    {
                                        count_byte_read++;
                                    } //  if (count_byte_read < (index_end_recieve-1))
                                }
                            } // if (count_byte_read == 0)
                        } // if (massiv_answer[0] == data_PDU[0]) 
                    } // while(read_int >= 0)
                    // проверка CRC
                    byte crc_0 = massiv_answer[count_byte_read - 2];
                    byte crc_1 = massiv_answer[count_byte_read - 1];
                    Array.Resize(ref massiv_answer, (count_byte_read - 2));
                    byte[] data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(massiv_answer);
                    if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                    {
                        label_out.Text = " проверка CRC - НОРМ ";
                        // перекидос данных
                        label_out.Text = label_out.Text + " перекидос данных";

                                listBox_answer_one.Items.Clear();
                                for (int ir = 0; ir < count_byte_read - 2; ir++) // CRC 2 байта здесь уже нет
                                { listBox_answer_one.Items.Add(ir.ToString() + " " + massiv_answer[ir].ToString()); }

                        count_list_box++;
                        if (count_list_box > 5) { count_list_box = 0; }
                    }
                    else
                    {
                        label_out.Text = " проверка CRC - ОШИБКА ";
                    }

            } // try
            catch (Exception ex)
            { label_error.Text = ex.Message; }
            return answer_status;
        }

        public byte[] array_read = new byte[85]; // массив полученых в ответ данных, STM долбит непрерывно

        public async Task Read_cicle_scan_freq(byte[] cmd_arr) // массив-команда, которая ушла по модбусу
        {
            answer_status_cicles = "OK";
            int old_CRC = 0;
            int Fmin = int.MaxValue;
            int Fmax = int.MinValue;

            init_chart();
            data_freq.Clear();// очистка

            // крутимся, выход если прерван поток входной (нажата синяя кнопка )
            int ik = 0;
            ushort old_freq = 0;
            ushort perwiy_tuk = 0; // если был первый тук в конец диапазона, надо очистить  data_freq, поворотный проход будет правильным - последним
            Class_data temp_data = new Class_data();
            int count_byte_read = 0;
            uint index_end_recieve = 85;
            string ex_message = "";

            // while (ik < 2100)     // while (ik < 2100)     // while (ik < 2100)     // while (ik < 2100)     // while (ik < 2100)     // while (ik < 2100)     
            while ((ik < 2100) & (button_stop_read.Enabled == true)) // крутится в этом цикле, пока не схватим концы диапазона, после этого ik=2101
            {
                count_byte_read = 0;
                index_end_recieve = 85;
                label_error.Text = "читаем поток входных данных";
                // крутимся , поиск одной посылки
                await Task.Run(() =>
                {
                    try
                    { array_read[count_byte_read] = (byte)serialPort_read_data.BaseStream.ReadByte(); }
                    catch (Exception ex)
                    { ex_message = ex.Message; }
                });
                if (ex_message != "")
                {
                    label_error.Text = "Ошибка чтения данных, " + ex_message;
                    break;
                }


                while (count_byte_read < index_end_recieve)
                {
                    if (array_read[0] == cmd_arr[0]) // adr_slave) // адрес устройства, которое отвечает
                    {
                        if (count_byte_read == 0)
                        { count_byte_read++; }
                        else
                        {
                            if (array_read[1] == cmd_arr[1]) // num_cmd) // код команды, от устройства, как там понято
                            {
                                if (count_byte_read == 1)
                                { count_byte_read++; }
                                else
                                {
                                    if (array_read[2] == 80) // в этом байте длина пакета данных
                                    { count_byte_read++; }
                                    else
                                    { count_byte_read = 0; } // if (array_read[2] == 80) // в этом байте длина пакета данных
                                }
                            } // if (massiv_answer[1] == data_PDU[1])
                            else
                            { count_byte_read = 0; }
                        } // if (count_byte_read == 0)
                    } // if (massiv_answer[0] == data_PDU[0]) 
                    else
                    { count_byte_read = 0; }//  else  if (massiv_answer[0] == data_PDU[0]) 

                    // читаем следующий символ
                    await Task.Run(() =>
                    {
                        try
                        { array_read[count_byte_read] = (byte)serialPort_read_data.BaseStream.ReadByte(); }
                        catch (Exception ex)
                        { ex_message = ex.Message; }
                    });

                    if (ex_message != "") // а если пришло сообщение об ошибочке чтения
                    {
                        label_error.Text = "Ошибка чтения данных, " + ex_message;
                        break;
                    }
                } // while(count_byte_read < index_end_recieve)


                // пакет 80 байт словили, теперь проверка CRC // пакет 80 байт словили, теперь проверка CRC // пакет 80 байт словили, теперь проверка CRC
                byte crc_0 = array_read[array_read.Length - 3];
                byte crc_1 = array_read[array_read.Length - 2];
                Array.Resize(ref array_read, 83);
                byte[] data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(array_read);
                Array.Resize(ref array_read, 86);
                if (old_CRC != (data_CRC[0] + data_CRC[1]))
                {
                    old_CRC = data_CRC[0] + data_CRC[1];
                    if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1)) // CRC совпал - удача
                    {
                        temp_data.clear_data();
                        ushort t = (ushort)BitConverter.ToSingle(array_read, 3);
                        temp_data.Freq = t;
                        for (int i = 0; i < 6; i++)
                        {
                            temp_data.val[i] = BitConverter.ToSingle(array_read, 7 + 4 * i);
                            chart1.Series[i].Points.AddXY(temp_data.Freq, temp_data.val[i]); // там происходит каша, зато наглядно - прием идет
                        }
                        label_out.Text = temp_data.Freq.ToString();
                        temp_data.flag_yes = true;// значит для этой частоты пришли данные
                        data_freq.Add(new Class_data(temp_data));

                        // надо крутится до тех пор, пока не будут схвачены концы диапазона
                        if (temp_data.Freq > Fmax) { Fmax = temp_data.Freq; }
                        if (temp_data.Freq < Fmin) { Fmin = temp_data.Freq; }
                        if (((Fmax + 50) >= (Set_Generator.Freq_start + Set_Generator.F_Step * Set_Generator.N_step)) |
                            ((Fmin - 50) <= Set_Generator.Freq_start))
                        {
                            if (perwiy_tuk == 0) { data_freq.Clear(); }
                            perwiy_tuk++;
                        }
                        if (((Fmax + 50) >= (Set_Generator.Freq_start + Set_Generator.F_Step * Set_Generator.N_step)) &
                                ((Fmin - 50) <= Set_Generator.Freq_start))
                        { break; }
                        else
                        {
                            if (old_freq != temp_data.Freq)
                            {
                                ik++;
                                old_freq = temp_data.Freq;
                            }
                        } // if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                    }
                    else
                    {
                        label_out.Text = " проверка CRC - ОШИБКА ";
                        answer_status_cicles = "ERROR_CRC";
                    }// else  if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                }
            }//while (true)
            serialPort_read_data.Close();
            data_freq.Sort(); // убрать дублирующие , отсортровать

            //  data_freq.Distinct  - удаление дублирующих старым дедовским способом,  !! после сортировки
            for (int i = 0; i < data_freq.Count; i++)
            {
                if (old_freq == data_freq[i].Freq)
                {
                    data_freq.RemoveAt(i);
                    if (i > 0) { i--; }
                }
                else
                { old_freq = data_freq[i].Freq; }
            }
            otrisovka_graf_listbox(Fmin, Fmax);
            button_stop_read.Enabled = false;
            button_cicle_read.Enabled = true;
            if (label_error.Text == "читаем поток входных данных")
            { label_error.Text = "данные в границах диапазона прочтены, чтение остановлено"; }
            return;

        }




        // ==================================== READ_scan_time  =========================================================
        Thread thread_read;

        public void  Read_cicle_scan_time()
        {
            init_chart();
            data_freq.Clear();// очистка

            for (int i = 0; i < 6; i++)
            {
                chart1.ChartAreas[i].AxisX.Maximum = 1010;
                chart1.ChartAreas[i].AxisX.Minimum = 0;
                chart1.ChartAreas[i].AxisX2.Maximum = 1010;
                chart1.ChartAreas[i].AxisX2.Minimum = 0;
            }

            // подготовим ListBox все для работы в режиме скан по времени
            for (int i = 0; i < 6; i++)
            {
                listbox_arr_data_graf[i].Items.Clear();
                for (int k = 0; k < 1024; k++)
                { listbox_arr_data_graf[i].Items.Add(k.ToString("D4") + "= "  + Environment.NewLine); }
            }
            // теперь на графике 5 нарисуем сигнал ключей  (-1 плечо1верх >ток> плечо2низ) (0 плечо1=плечо2 ток=0) (+1 плечо1низ <ток< плечо2верх)
            // при старте периода ключей, после синхроимульса,
            // идет -1 и тянется %power от 64 импульсов,
            // потом 0 до 64 импульса,
            // потом +1 и тянется %power от 64 имп,
            // потом 0 до 128 импульса
            int temp_i=0;
            int temp_x = 0;
            float temp_y = 0;
            float[] series_minmax = new float[4] {1,1,1,1};

            // нарисуем график работы ключей
            for (int ser_i = 6; ser_i < 10; ser_i++)
            {
                chart1.Series[ser_i].Points.Clear();
                for (int k = 0; k < 17; k++)
                {
                    for (int i = 0; i < 64; i++)
                    {
                        temp_y = 0;
                        //temp_i = 32 * Set_Generator.Power_proc / 100;
                        temp_i = 64 * Set_Generator.Power_proc / 100;
                        if (i < temp_i) { temp_y = -1; }
                        if ((i < temp_i + 32) & (i > 31)) { temp_y = 1; }
                        temp_x = i + k * 64 - 18;
                        if ((temp_x >= 0) & (temp_x < 1010)) { chart1.Series[ser_i].Points.AddXY(temp_x, temp_y); }
                    }
                }
            }

            numericUpDown_mouse.Maximum = 1024;
            numericUpDown_mouse.Minimum = 0;

            thread_read = new Thread(thread_read_scan_time);
            if (thread_read.ThreadState == ThreadState.Unstarted)
            { thread_read.Start(); }
        }


        Class_data_read_time data_time = new Class_data_read_time();
        void thread_read_scan_time()
        {
            // крутимся, выход если прерван поток входной (нажата синяя кнопка )
            byte[] temp_read_byte = new byte[4096];
            int recive_byte = 0;
            int bufer_byte = 0;

            while (button_stop_read.Enabled == true) // крутится БЕСКОНЕЧНО в этом цикле, пока нажата кнопк
            {
                // крутимся , поиск одной посылки
                bufer_byte = serialPort_read_data.BytesToRead;

                if (bufer_byte > 84)
                { recive_byte = serialPort_read_data.Read(temp_read_byte, 0, bufer_byte); }

                if (recive_byte > 84)
                { data_time.Decode_string_to_data(temp_read_byte, recive_byte); }
            }// while (button_stop_read.Enabled == true) // крутится БЕСКОНЕЧНО в этом цикле, пока нажата кнопк

            //           Invoke(new Action(() => label_error.Text = "Ошибка, " + ex_message));
            if (serialPort_read_data.IsOpen == true) serialPort_read_data.Close();
            thread_read.Abort();
        }
    } // public partial class Form1

} // namespace Read_Modbus_UsbCDC_stm32G4
