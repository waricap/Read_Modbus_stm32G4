﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Modbus.Device;
using System.Threading;

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
            label_out.Text = message_status;
        }
        public void read_ONE()
        {
            byte[] cmd_read_1 = Write_CmdRead_one_point_freq(25000);
            string message_status = "";
            byte[] array_read = new byte[255]; // 255 -это максимальный размер, по мере приема будет обрезан
            string status_answer = Answer_Read_Register(ref array_read, ref message_status, cmd_read_1);
            serialPort_MB.Close();
            label_out.Text = message_status;
            int num_freq;

            if (status_answer == "OK")
            {
                num_freq = Convert.ToInt32(BitConverter.ToSingle(array_read, 3)) - 14500;
                if (num_freq < 0) { num_freq = 0; }
                if (num_freq > 28499) { num_freq = 28499; }
                for (int i = 0; i < 6; i++)
                { array_data_freq[i, num_freq] = BitConverter.ToSingle(array_read, 3 + 4 * i); }
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
            if (freq > 43000) { freq = 43000; }
            if (freq < 14500) { freq = 14500; }
            freq = 1;
            byte Hi = Convert.ToByte(freq >> 8);
            byte Low = Convert.ToByte(freq & 0xff);
            byte[] cmd_read_1 = { 7, 4, 0, 64, Hi, Low };
            byte[] data_CRC = { 0, 0 };
            data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(cmd_read_1);
            Array.Resize(ref cmd_read_1, cmd_read_1.Length + 2);
            Array.Copy(data_CRC, 0, cmd_read_1, (cmd_read_1.Length - 2), data_CRC.Length);

            byte[] read_data = new byte[256];
            init_COM_port();
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

            init_COM_port();
            if (serialPort_MB.IsOpen == false)
                { serialPort_MB.Open(); }
            serialPort_MB.Write(cmd_write_16, 0, cmd_write_16.Length);
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
                                    label_out.Text = " ошибка какая то пришла ";
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
            { label_out.Text = ex.Message; }
            return answer_status;
        }

        public byte[] array_read = new byte[86]; // массив полученых в ответ данных, STM долбит непрерывно

        private async Task<byte[]> Async_Read_one_paket(byte adr_slave, byte num_cmd)
        {
            int count_byte_read = 0;
            uint index_end_recieve = 85;
            // крутимся , поиск одной посылки
            Array.Resize(ref array_read, 86);
            await Task.Run(() => array_read[0] = (byte)serialPort_MB.BaseStream.ReadByte());

            while (count_byte_read < index_end_recieve)
            {
                if (array_read[0] == adr_slave) // адрес устройства, которое отвечает
                {
                    if (count_byte_read == 0)
                    {
                      count_byte_read = 1;
                      await Task.Run(() => array_read[1] = (byte)serialPort_MB.BaseStream.ReadByte());
                    }
                    else
                    {
                        if (array_read[1] == num_cmd) // код команды, от устройства, как там понято
                        {
                            if (count_byte_read == 1)
                            {
                               count_byte_read++;
                               await Task.Run(() => array_read[count_byte_read] = (byte)serialPort_MB.BaseStream.ReadByte());
                            }
                            else
                            {
                                if (array_read[2] == 80) // в этом байте длина пакета данных
                                {
                                    if (count_byte_read < (index_end_recieve - 1))
                                    {
                                      count_byte_read++;
                                      await Task.Run(() => array_read[count_byte_read] = (byte)serialPort_MB.BaseStream.ReadByte());
                                    }
                                    else
                                    { count_byte_read++; } //  if (count_byte_read < (index_end_recieve-1))
                                }
                                else
                                {
                                   count_byte_read = 0;
         //                          await Task.Run(() => array_read[0] = (byte)serialPort_MB.BaseStream.ReadByte());
                                } // if (array_read[2] == 80) // в этом байте длина пакета данных
                            } // if (count_byte_read == 1)
                        } // if (massiv_answer[1] == data_PDU[1])
                        else
                        {
                           count_byte_read = 0;
         //                  await Task.Run(() => array_read[0] = (byte)serialPort_MB.BaseStream.ReadByte());
                        }
                    } // if (count_byte_read == 0)
                } // if (massiv_answer[0] == data_PDU[0]) 
                else
                {
                   count_byte_read = 0;
                   await Task.Run(() => array_read[0] = (byte)serialPort_MB.BaseStream.ReadByte());
                }//  else  if (massiv_answer[0] == data_PDU[0]) 
            } // while(count_byte_read < index_end_recieve)
            return array_read;
        }

        public async Task Read_cicle_scan_freq(byte[] cmd_arr) // массив-команда, которая ушла по модбусу
        {
            answer_status_cicles = "OK";
            Int32 num_freq;
            float temp_num_freq_float;
            int old_CRC = 0;
                int Fmin = int.MaxValue;
                int Fmax=int.MinValue;

            // очистка   array_data_freq
            for (int i = 0; i < 6; i++) 
            { 
                chart1.Series[i].Points.Clear(); 
                chart1.ChartAreas[i].AxisX.Maximum = 43000;
                chart1.ChartAreas[i].AxisX.Minimum = 14500;
            }
            numericUpDown_mouse.Maximum = 43000;
            numericUpDown_mouse.Minimum = 14500;
            for (int i = 0; i < 7; i++)
            {
                for (int num = 0; num < 28500; num++)
                    { array_data_freq[i, num] = 0; }
            }

            try
            {
                // крутимся, выход если прерван поток входной (нажата синяя кнопка )
               //while (true)
                int ik = 0;

                int temp_num_freq = 0;
                while (ik <2100) // крутится в этом цикле, пока не схватим концы диапазона, после этого ik=2101
                {
                    // крутимся , поиск одной посылки
                    array_read = await Async_Read_one_paket(cmd_arr[0], cmd_arr[1]);
                    // пакет 80 байт словили, теперь проверка CRC
                    byte crc_0 = array_read[array_read.Length - 3];
                    byte crc_1 = array_read[array_read.Length - 2];
                    Array.Resize(ref array_read, 83);
                    byte [] data_CRC = Modbus.Utility.ModbusUtility.CalculateCrc(array_read);
                    Array.Resize(ref array_read, 86);
                    if (old_CRC != (data_CRC[0] + data_CRC[1]))
                    {
                        old_CRC = data_CRC[0] + data_CRC[1];
                        if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                        { 
                            temp_num_freq_float = BitConverter.ToSingle(array_read, 3);
                            if((temp_num_freq_float >=14500) & (temp_num_freq_float <=43000))
                            {
                                temp_num_freq = Convert.ToInt32(temp_num_freq_float);
                                num_freq = temp_num_freq - 14500;
                                for (int i = 0; i < 6; i++)
                                { 
                                    array_data_freq[i, num_freq] = BitConverter.ToSingle(array_read, 7 + 4 * i );
                                    chart1.Series[i].Points.AddXY(temp_num_freq, array_data_freq[i, num_freq]);
                                }
                                array_data_freq[7, num_freq] = 1; // значит для этой частоты пришли данные
                                label_out.Text = temp_num_freq_float.ToString();
                                // надо крутится до тех пор, пока не будут схвачены концы диапазона
                                if (temp_num_freq > Fmax) { Fmax = temp_num_freq; }
                                if (temp_num_freq < Fmin) { Fmin = temp_num_freq; }
                                if (((Fmax+50) >= (Set_Generator.Freq_start + Set_Generator.F_Step * Set_Generator.N_step)) &
                                        ((Fmin - 50) <= Set_Generator.Freq_start))
                                { ik = int.MaxValue; }
                                else
                                { ik++; }
                            }
                        } // if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                        else
                        {
                            temp_num_freq_float = BitConverter.ToSingle(array_read, 3);
                            if ((temp_num_freq_float >= 14500) & (temp_num_freq_float <= 43000))
                            {
                                num_freq = Convert.ToInt32(temp_num_freq_float) - 14500;
                            }
                            label_out.Text = " проверка CRC - ОШИБКА ";
                            answer_status_cicles = "ERROR_CRC";
                        }// else  if ((data_CRC[0] == crc_0) & (data_CRC[1] == crc_1))
                    }
                }//while (true)
                // this.Refresh();
            } // try
            catch (Exception ex)
            { 
                label_out.Text = ex.Message;
                answer_status_cicles = "ERROR_TIMEOUT";
            }
            serialPort_MB.Close();
            for (int i = 0; i < 6; i++)
                {
                    chart1.Series[i].Points.Clear();    
                    chart1.ChartAreas[i].AxisX.Maximum = Fmax;
                    chart1.ChartAreas[i].AxisX.Minimum = Fmin;
                    listbox_arr_data_graf[i].Items.Clear();
                    for (int num = Fmin; num < Fmax; num++)
                    {
                        if (array_data_freq[0, num-14500] != 0)
                        {
                            listbox_arr_data_graf[i].Items.Add(num.ToString() + "=" + array_data_freq[i, num - 14500].ToString() + "\n");
                            chart1.Series[i].Points.AddXY(num, array_data_freq[i, num - 14500]);
                        }                    
                    } 
                }
            numericUpDown_mouse.Maximum = Fmax;
            numericUpDown_mouse.Minimum = Fmin;

            return ;
        } // private string Read_register_scan_freq(ref byte[] array_read, 

    } // public partial class Form1

} // namespace Read_Modbus_UsbCDC_stm32G4