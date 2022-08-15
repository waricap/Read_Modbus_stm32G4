using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Drawing;
using Modbus.Device;
using System.IO;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Read_Modbus_UsbCDC_stm32G4
{


    public partial class Form1
    {
        private string path_directory = @"C:\Users\" + Environment.UserName + @"\source\repos\Read_Modbus_stm32G4\файлы_замеров_АЧХ";
        //private string path_directory = @"C:\Users\" + Environment.UserName + @"\Documents\файлы_замеров_АЧХ";
        private void save_data_in_file()
        {
            string text_coment = ""; // используется для формирования поля названия графика в файле перед пакетом данных
            // проверить или создать папку в папке документов юзера
            if (!Directory.Exists(path_directory))
                {  Directory.CreateDirectory(path_directory); }

            // диалог выбора имени для файла записи
            saveFileDialog1.InitialDirectory = path_directory;  // устанавливает каталог, который отображается при первом вызове окна
            saveFileDialog1.DefaultExt = ".tfx"; // устанавливает расширение файла, которое добавляется по умолчанию, если пользователь ввел имя файла без расширения
            saveFileDialog1.AddExtension = true;// при значении true добавляет к имени файла расширение при его отсуствии. Расширение берется из свойства DefaultExt или Filter
            saveFileDialog1.Title = "Сохранить данные текущего замера"; // заголовок диалогового окна
            saveFileDialog1.Filter = "(*.tfx) | *.tfx"; // задает фильтр файлов, благодаря чему в диалоговом окне можно отфильтровать файлы по расширению. Фильтр задается в следующем формате Название_файлов| *.расширение.Например, Текстовые файлы(*.txt)| *.txt.
            saveFileDialog1.OverwritePrompt = true; // при значении true в случае, если указан существующий файл, то будет отображаться сообщение о том, что файл будет перезаписан

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // отработаем запись данных только если нажата кнопочка ОК в диалоге
            {
                string patch_file = saveFileDialog1.FileName;   // получаем имя выбранный файл

                using (StreamWriter temp_write = new StreamWriter(patch_file, false))
                {
                    // файл будем экспортировать редактировать в EXCEL, поэтому формат соблюдать обязан ты
                    temp_write.WriteLine("## вначале идут данные #set..., на которых снимался график, на [16] позиции стоит <TAB>, потом данные, <ENTER>");
                    temp_write.WriteLine("##   ( текущие настройки генератора могут не совпасть, и наверняка не совпадут, со считанными настройками )");
                    temp_write.WriteLine("## потом строка с номером и названием графика, #0# ... <TAB> N <ENTER> ");
                    temp_write.WriteLine("## непосредственно данные идут в формате: частота-5цифр, <TAB>, значение параметра через десятичная запятая <ENTER>");
                    temp_write.WriteLine("## экспоненциальная форма записи числа E+n - приходит из EXCEL - не прокатывает ");
                    temp_write.WriteLine("#set Freq_start " + "\t" + Set_Generator.Freq_start.ToString());
                    temp_write.WriteLine("#set Power_proc " + "\t" + Set_Generator.Power_proc.ToString());
                    temp_write.WriteLine("#set F_Step     " + "\t" + Set_Generator.F_Step.ToString());
                    temp_write.WriteLine("#set Time_Step  " + "\t" + Set_Generator.Time_Step.ToString());
                    temp_write.WriteLine("#set N_step     " + "\t" + Set_Generator.N_step.ToString());
                    temp_write.WriteLine("#set F_marker   " + "\t" + numericUpDown_mouse.Value.ToString());
                    for(int i = 0; i < 6; i++)
                    {
                        switch (i)
                        {               // text_coment - на будущее, на форме, будет сделан выбор пакета данных для построения графика, пока так
                            case 0:
                                text_coment = "current I_out\t";
                                break;
                            case 1:
                                text_coment = "voltage U_out\t";
                                break;
                            case 2:
                                text_coment = "ph1_out\t";
                                break;
                            case 3:
                                text_coment = "ph2_out\t";
                                break;
                            case 4:
                                text_coment = "delta_Ph_out\t";
                                break;
                            case 5:
                                text_coment = "power P_out\t";
                                break;
                        }
                        // заголовочная строка пакета данных графика
                        temp_write.WriteLine("#" + i.ToString() + "# value " + text_coment + i.ToString());
                        // пишем непосредственно данные
                        foreach(Class_data df in data_freq)
                            { temp_write.Write(df.form_one_string_file()); }// если там есть какие  данные, скидываем. Не на каждой точке будет такая удача.
                    }// for(int i = 0; i < 6; i++)
                }// using (StreamWriter temp_write = new StreamWriter(patch_file, true))
            } // if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        } //  save_data_in_file()

        private void open_file_extract_data()
        {
            Class_data df = new Class_data();
            List<Class_data> data_freq_full = new List<Class_data>();
            // диалог выбора имени для файла записи
            openFileDialog1.InitialDirectory = path_directory;  // устанавливает каталог, который отображается при первом вызове окна
            openFileDialog1.DefaultExt = ".tfx"; // устанавливает расширение файла, которое добавляется по умолчанию, если пользователь ввел имя файла без расширения
            openFileDialog1.AddExtension = true;// при значении true добавляет к имени файла расширение при его отсуствии. Расширение берется из свойства DefaultExt или Filter
            openFileDialog1.Title = "Сохранить данные текущего замера"; // заголовок диалогового окна
            openFileDialog1.Filter = "(*.tfx) | *.tfx"; // задает фильтр файлов, благодаря чему в диалоговом окне можно отфильтровать файлы по расширению. Фильтр задается в следующем формате Название_файлов| *.расширение.Например, Текстовые файлы(*.txt)| *.txt.

            int num_data_paket=0; // при отсосе данных это будет номер пакета данных, ну и номер графика тоже
            int temp_numericUpDown_Value  = freq_begin_band;
            int Fmin = int.MaxValue;
            int Fmax = int.MinValue;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string patch_file = openFileDialog1.FileName;   // получаем имя выбранный файл
                using (StreamReader temp_read = new StreamReader(patch_file))
                {
                    string read_stroka = temp_read.ReadLine();
                    while ((read_stroka != null) && (read_stroka.Length >0))
                    {
                        // читаем, смотрим содержание, раскидываем туда сюда
                        if (read_stroka[0] == '#')   // шапка коментариев интереса не представляет
                        {
                            if (read_stroka[1] == 's')
                            {
                                ushort temp_ushort = Convert.ToUInt16(read_stroka.Substring(16));
                                if (read_stroka.IndexOf("Freq_start") > 0) { Set_Generator.Freq_start = temp_ushort; }
                                if (read_stroka.IndexOf("Power_proc") > 0) { Set_Generator.Power_proc = temp_ushort; }
                                if (read_stroka.IndexOf("F_Step") > 0) { Set_Generator.F_Step = temp_ushort; }
                                if (read_stroka.IndexOf("Time_Step") > 0) { Set_Generator.Time_Step = temp_ushort; }
                                if (read_stroka.IndexOf("N_step") > 0) { Set_Generator.N_step = temp_ushort; }
                                if (read_stroka.IndexOf("F_marker") > 0) { temp_numericUpDown_Value = (int)temp_ushort; }
                            }
                            else
                            {
                                if (read_stroka[1] == 'D')
                                {// теперь, именно здесь,  непосредственно данные отсасываем из принятой строки
                                    string[] array_string_data = read_stroka.Split('\t');
                                    df.Freq = Convert.ToUInt16(array_string_data[1]);
                                    if (Fmin > df.Freq) { Fmin = df.Freq; }
                                    if (Fmax < df.Freq) { Fmax = df.Freq; }
                                    for(int i = 2; i < array_string_data.Length -3; i++)
                                    {
                                        if (i<18)
                                        { df.val[i-2] = (float) Convert.ToDecimal(array_string_data[i]); }
                                    }
                                    df.flag_yes = true;
                                    data_freq_full.Add(new Class_data(df));
                                }
                                else
                                {
                                    switch (read_stroka[1])
                                    {
                                        case '0':
                                            num_data_paket = 0;
                                            // вот дошли до точки, когда все таки есть надежда, что данные таки есть будут
                                            // чистим на радости массив данных, к приему новых
                                            data_freq.Clear();
                                            break;
                                        case '1': num_data_paket = 1; break;
                                        case '2': num_data_paket = 2; break;
                                        case '3': num_data_paket = 3; break;
                                        case '4': num_data_paket = 4; break;
                                        case '5': num_data_paket = 5; break;
                                    }
                                }
                            }
                        } // if (read_stroka[0] == '#')
                        read_stroka = temp_read.ReadLine();// читаем следующую строку

                    } // while (read_stroka.Length >0)
                } // using (StreamReader temp_read = new StreamReader(patch_file))
                // поток читательный закрыт, раскидываем теперь полученые данные и разрисовываем все
                data_freq = data_freq_full.GroupBy(i => i.Freq, (key, group) => group.First()).ToList();
                data_freq.Sort();
                otrisovka_graf_listbox(Fmin, Fmax);
                numericUpDown_mouse.Value = temp_numericUpDown_Value;
            }// if (openFileDialog1.ShowDialog() == DialogResult.OK)
        } // private void open_file_extract_data()
    }
}