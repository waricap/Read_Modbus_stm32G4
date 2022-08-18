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
                    try
                    {
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
                        temp_write.WriteLine("#set Chart_min  " + "\t" + chart1.ChartAreas[0].AxisX.Minimum.ToString());
                        temp_write.WriteLine("#set Chart_max  " + "\t" + chart1.ChartAreas[0].AxisX.Maximum.ToString());
                    }
                    catch (Exception e)
                    { label_error.Text = "ошибка записи шапки данных " + e.Message ; }

                        //switch (i)
                        //{   // todo text_coment - на будущее, на форме, будет сделан выбор пакета данных для построения графика, пока так
                        //    case 0:
                        //        text_coment = "current I_out\t";
                        //        break;
                        //    case 1:
                        //        text_coment = "voltage U_out\t";
                        //        break;
                        //    case 2:
                        //        text_coment = "ph1_out\t";
                        //        break;
                        //    case 3:
                        //        text_coment = "ph2_out\t";
                        //        break;
                        //    case 4:
                        //        text_coment = "delta_Ph_out\t";
                        //        break;
                        //    case 5:
                        //        text_coment = "power P_out\t";
                        //        break;
                        //}
                        // пишем непосредственно данные
                        foreach (Class_data df in data_freq)
                        {
                            try
                            { temp_write.Write(df.form_one_string_file()); } // если там есть какие  данные, скидываем. Не на каждой точке будет такая удача.
                            catch (Exception e)
                            { label_error.Text = "ошибка записи шапки данных " + e.Message; }
                        }
                    label_name_file_zamer.Text = Path.GetFileName(patch_file);
                }// using (StreamWriter temp_write = new StreamWriter(patch_file, true))
            } // if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            else
            { label_error.Text = "ошибка открытия файла"; }
        } //  save_data_in_file()

        private void open_file_extract_data()
        {
            Class_data df = new Class_data();
            // диалог выбора имени для файла записи
            openFileDialog1.InitialDirectory = path_directory;  // устанавливает каталог, который отображается при первом вызове окна
            openFileDialog1.DefaultExt = ".tfx"; // устанавливает расширение файла, которое добавляется по умолчанию, если пользователь ввел имя файла без расширения
            openFileDialog1.AddExtension = true; // при значении true добавляет к имени файла расширение при его отсуствии. Расширение берется из свойства DefaultExt или Filter
            openFileDialog1.Title = "Загрузить из файла сохраненные данные"; // заголовок диалогового окна
            openFileDialog1.Filter = "(*.tfx) | *.tfx"; // задает фильтр файлов, благодаря чему в диалоговом окне можно отфильтровать файлы по расширению. Фильтр задается в следующем формате Название_файлов| *.расширение.Например, Текстовые файлы(*.txt)| *.txt.

            int num_data_paket=0; // при отсосе данных это будет номер пакета данных, ну и номер графика тоже
            int temp_numericUpDown_Value  = freq_begin_band;
            int Fmin = int.MaxValue;
            int Fmax = int.MinValue;
            string read_stroka = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string patch_file = openFileDialog1.FileName;   // получаем имя выбранный файл
                using (StreamReader temp_read = new StreamReader(patch_file))
                {
                    try
                    { read_stroka = temp_read.ReadLine(); }// читаем первую строку
                    catch (Exception e)
                    { label_error.Text = "ошибка чтения файла: " + e.Message; }

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
                                if (read_stroka.IndexOf("Chart_min") > 0)
                                {
                                    for (int i = 0; i < 6; i++) 
                                    { chart1.ChartAreas[i].AxisX.Minimum = temp_ushort; }
                                    numericUpDown_mouse.Minimum = temp_ushort;
                                }
                                if (read_stroka.IndexOf("Chart_max") > 0)
                                {
                                    for (int i = 0; i < 6; i++) 
                                    { chart1.ChartAreas[i].AxisX.Maximum = temp_ushort; }
                                    numericUpDown_mouse.Maximum = temp_ushort;
                                }
                                if (read_stroka.IndexOf("F_marker") > 0)
                                {
                                    temp_numericUpDown_Value = (int)temp_ushort;
                                    // вот дошли до точки, когда все таки есть надежда, что данные таки есть будут
                                    // чистим на радости массив данных, к приему новых
                                    data_freq.Clear();// очистка
                                }
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
                                    data_freq.Add(new Class_data(df));
                                }
                            }
                        } // if (read_stroka[0] == '#')
                        try
                        { read_stroka = temp_read.ReadLine(); }// читаем следующую строку
                        catch (Exception e)
                        { label_error.Text = "ошибка чтения файла: " + e.Message; }

                    } // while (read_stroka.Length >0)
                    label_name_file_zamer.Text = openFileDialog1.SafeFileName;
                } // using (StreamReader temp_read = new StreamReader(patch_file))
                // поток читательный закрыт, раскидываем теперь полученые данные и разрисовываем все
                textBox_Fstart.Text = Set_Generator.Freq_start.ToString();
                textBox_Power.Text = Set_Generator.Power_proc.ToString(); 
                textBox_Step.Text = Set_Generator.F_Step.ToString(); 
                textBox_Step.Text = Set_Generator.Time_Step.ToString(); 
                textBox_NumPoint.Text =  Set_Generator.N_step.ToString();

                data_freq.Sort(); // убрать дублирующие , отсортровать
                ushort old_freq = 0;
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
                numeric_Up_Down(temp_numericUpDown_Value); // m==+1  нажат микрик +number;  m==-1  нажат микрик -number;  m==0 клац мыши по chart;  m==FREQ клац маши по ListBox
                numericUpDown_mouse.Value = temp_numericUpDown_Value;
            }// if (openFileDialog1.ShowDialog() == DialogResult.OK)
        } // private void open_file_extract_data()

        private void open_data_SpLab(int num_chart)
        {
            // диалог выбора имени для файла записи
            openFileDialog1.InitialDirectory = path_directory;  // устанавливает каталог, который отображается при первом вызове окна
            openFileDialog1.DefaultExt = ".txt"; // устанавливает расширение файла, которое добавляется по умолчанию, если пользователь ввел имя файла без расширения
            openFileDialog1.AddExtension = true;// при значении true добавляет к имени файла расширение при его отсуствии. Расширение берется из свойства DefaultExt или Filter
            openFileDialog1.Title = "Найти данные от SpLab, загрузить в 6-й график"; // заголовок диалогового окна
            openFileDialog1.Filter = "(*.txt) | *.txt"; // задает фильтр файлов, благодаря чему в диалоговом окне можно отфильтровать файлы по расширению. Фильтр задается в следующем формате Название_файлов| *.расширение.Например, Текстовые файлы(*.txt)| *.txt.

            char[] delete_char = {'\r', '\n', '\t', ' '};
            List<int> freq = new List<int>();
            List<float> val = new List<float>();
            string read_stroka ="";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string patch_file = openFileDialog1.FileName;   // получаем имя выбранный файл
                using (StreamReader temp_read = new StreamReader(patch_file))
                {
                    try
                        { read_stroka = temp_read.ReadLine(); }
                    catch (Exception  e)
                        { label_error.Text = "ошибка чтения файла: " + e.Message ;  }
                    
                    while (read_stroka != null) 
                    {
                        if (read_stroka.Length > 0)
                        {
                            // читаем, смотрим содержание, раскидываем туда сюда
                            if ((read_stroka[0] >= '0') & (read_stroka[0] <= '9'))  // строки данных содержат только цифры, если там что ещё - проброс
                            {
                                string[] array_string_data = (read_stroka.Replace('.', ',')).Split('\t');
                                freq.Add( (int)Convert.ToDecimal(array_string_data[0].Trim(delete_char)));
                                val.Add ( (float) Convert.ToDecimal(array_string_data[1].Trim(delete_char)));
                            }
                        }

                        try
                        { read_stroka = temp_read.ReadLine(); }
                        catch (Exception e)
                        { label_error.Text = "ошибка чтения файла: " + e.Message; }

                    } // while ((read_stroka != null) && (read_stroka.Length > 0))
                    info_data_chart[num_chart].label_name_file.Text = openFileDialog1.SafeFileName;
                }// using (StreamReader temp_read = new StreamReader(patch_file))
                otrisovka_graf_listbox_SpLab(freq, val, num_chart);
                // данные SpLab отрисованы по данным в реале, для ListBox_6 и для работы, надо привести-усреднить данные к шкале работы STM32G4
                if((data_freq.Count > 0) &(freq.Count > 0))
                {
                    int count_point;
                    foreach (Class_data df in data_freq)
                    {
                        df.val[num_chart] = 0;
                        count_point = 0;
                        for (int i = 0; i < freq.Count; i++)
                        {
                            if ((freq[i] > df.Freq-6) & (freq[i] < df.Freq + 6))
                            {
                                df.val[num_chart] += val[i];
                                count_point++;
                            }
                        }
                        if(count_point >0)
                        {
                            df.val[num_chart] = df.val[num_chart] / count_point;
                        }
                        else
                        {
                            for (int i = 0; i < freq.Count; i++)
                                { df.val[num_chart] += val[i]; }
                            df.val[num_chart] = df.val[num_chart] / freq.Count;
                        }
                        
                    }
                    // после того как сформировали ряд частот для 6 графика SpLab по шкале STM32G4, заполним ListBox_6
                    listbox_arr_data_graf[num_chart].Items.Clear();
                    string s = "";
                    for (int j = 0; j < data_freq.Count; j++)
                    {
                        if (data_freq[j].flag_yes)
                        {
                            s = data_freq[j].form_one_string_ListBox(data_freq[j].Freq, data_freq[j].val[num_chart]);
                            listbox_arr_data_graf[num_chart].Items.Add(s);
                        }
                    }
                }


            } // if (openFileDialog1.ShowDialog() == DialogResult.OK)
            else
            { label_error.Text = "ошибка открытия файла";  }
        }// private void open_data_SpLab()
    }
}