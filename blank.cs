using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class blank : Form
    {
        public string DocName = "";

        //фиксируем сохранение документа
        public bool IsSaved = false;

        public blank()
        {
            InitializeComponent();
            //Свойству Text панели sbTime устанавливаем системное время, 
            // конвертировав его в тип String
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            //В тексте всплывающей подсказки  выводим текущую дату
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());

        }

        //Создаем метод Open, в качестве параметра объявляем строку адреса  файла.
        public void Open(string OpenFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamReader и передаем ему переменную //OpenFileName
                StreamReader sr = new StreamReader(OpenFileName);
                //Читаем весь файл и записываем его в richTextBox1
                richTextBox1.Text = sr.ReadToEnd();
                // Закрываем поток
                sr.Close();
                //Переменной DocName присваиваем адресную строку
                DocName = OpenFileName;
            }
        }

        //Создаем метод Save, в качестве параметра объявляем строку адреса  файла.
        public void Save (string SaveFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (SaveFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamWriter и передаем ему переменную //SaveFileName
                StreamWriter sw = new StreamWriter(SaveFileName);
                //Содержимое richTextBox1 записываем в файл
                sw.WriteLine(richTextBox1.Text);
                //Закрываем поток
                sw.Close();
                //Устанавливаем в качестве имени документа название сохраненного файла
                DocName = SaveFileName;

            }
        }

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmmain frmm = (frmmain)this.MdiParent;
            //Если переменная IsSaved имеет значение true, т. е.  новый документ 
            //был сохранен (Save As) или в открытом документе были сохранены изменения (Save), то //выполняется условие
            if (IsSaved == false)
                //Появляется диалоговое окно, предлагающее сохранить документ.
                if (MessageBox.Show(frmm.resourceManager.GetString("MessageText"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //  if (MessageBox.Show("Do you want save changes in " + this.DocName + "?","Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                //Если была нажата  кнопка Yes, вызываем метод Save
                {
                        this.Save(this.DocName);
                }
        }

        // Вырезание текста
        public void Cut()
        {
            richTextBox1.Cut();
        }

        // Копирование текста
        public void Copy()
        {
            richTextBox1.Copy();
        }

        // Вставка
        public void Paste()
        {
            richTextBox1.Paste();
        }

        // Выделение всего текста — используем свойство SelectAll элемента управления RichTextBox 
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        // Удаление
        public void Delete()
        {
            richTextBox1.SelectedText = "";
        }


        private void blank_Load(object sender, EventArgs e)
        {

        }

        private void cmnuCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void cmnuCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void cmnuPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void cmnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Свойству Text панели sbAmount устанавливаем надпись "Аmount of symbols" 
            //и длину  текста в RichTextBox.
            sbAmound.Text = "Аmount of symbols " + richTextBox1.Text.Length.ToString();

        }
    }
}
