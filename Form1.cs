using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
//Пространство имен, используемое для определения культуры
//приложения и операционной системы
using System.Globalization;
//Пространство, используемое для работы с файлами ресурсов .resx,
//такими как ClosingText.en-US.resx, ClosingText.ru-RU.resx.
using System.Resources;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class frmmain : Form
    {
        //Переменная выбора, необходимая для определения культуры 
        public string CultureDefine;
        //Переменная для хранения английской культуры
        private string EnglishCulture;
        //Переменная для русской культуры.
        private string RussianCulture;
        private int openDocuments = 0; //счётчик числа открываемых документов
        public ResourceManager resourceManager;
        public frmmain()
        {
            Thread.CurrentThread.CurrentUICulture =Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            mnuSave.Enabled = false;
            //Инициализируем переменные
            EnglishCulture = "en-US";
            RussianCulture = "ru-RU";
            // Перменной CultureDefine присваиваем значение культуры, установленной на компьютере, 
            //используя свойство класса ResourceManager
            CultureDefine = CultureInfo.InstalledUICulture.ToString();
            // Создаем новый объект resourceManager, извлекающий из сборки 
            //текстовую переменную ClosingText
            resourceManager = new ResourceManager("WindowsFormsApp1.ClosingText", Assembly.GetExecutingAssembly());
        }

        public frmmain (string FormCulture)
        {

            InitializeComponent();
            EnglishCulture = "en-US";
            RussianCulture = "ru-RU";
            //В качестве культуры устанавливаем значение CultureDefine
            CultureDefine = FormCulture;
            // Создаем новый объект resourceManager, извлекающий из сборки 
            //текстовую переменную ClosingText
            resourceManager = new ResourceManager("WindowsFormsApp1.ClosingText", Assembly.GetExecutingAssembly());
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создаем новый экземпляр формы  frm
            blank frm = new blank();
            frm.DocName = "Untitled " + ++openDocuments; //название окна по шаблону с учётом счётчика
            frm.Text = frm.DocName;
            //Указываем, что родительским контейнером 
            //нового экземпляра будет эта, главная форма.
            frm.MdiParent = this;
            //Вызываем форму
            frm.Show();
        }

        private void mnuOpen_Click_1(object sender, EventArgs e)
        {
            mnuSave.Enabled = true;

            //Можно программно задавать доступные для обзора расширения файлов 
            //openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            //Если выбран диалог открытия файла, выполняем условие
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Создаем новый документ
                blank frm = new blank();
                //Вызываем метод Open формы blank
                frm.Open(openFileDialog1.FileName);
                //Указываем, что родительской формой является форма frmmain
                frm.MdiParent = this;
                //Присваиваем переменной DocName имя открываемого файла
                frm.DocName = openFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                //Вызываем форму frm
                frm.Show();
            }
        }

        public void Save(object sender, System.EventArgs e)
        {
           
        }


        private void mnuSave_Click(object sender, EventArgs e)
        {
            //Можно программно задавать доступные для обзора расширения файлов 
            //openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            //Если выбран диалог открытия файла, выполняем условие
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Переключаем фокус на данную форму.
                blank frm = (blank)this.ActiveMdiChild;
                //Вызываем метод Save формы blank
                frm.Save(frm.DocName);
                //Вызываем метод Save формы blank
                frm.Save(saveFileDialog1.FileName);
                //Указываем, что родительской формой является форма frmmain
                frm.MdiParent = this;
                //Присваиваем переменной FileName имя сохраняемого файла
                frm.DocName = saveFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                frm.IsSaved = true;
            }
        }

        private void cmnuSaveAs_Click(object sender, EventArgs e)
        {
            //Можно программно задавать доступные для обзора расширения файлов 
            //openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            //Если выбран диалог открытия файла, выполняем условие
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Переключаем фокус на данную форму.
                blank frm = (blank)this.ActiveMdiChild;
                //Вызываем метод Save формы blank
                frm.Save(saveFileDialog1.FileName);
                //Указываем, что родительской формой является форма frmmain
                frm.MdiParent = this;
                //Присваиваем переменной FileName имя сохраняемого файла
                frm.DocName = saveFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                mnuSave.Enabled = true;
                frm.IsSaved = true;
            }
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuHorizontal_Click(object sender, EventArgs e)
        {

        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.SelectAll();
        }
        private void mnuFont_Click_1(object sender, EventArgs e)
        {
            //Переключаем фокус на данную форму.
            blank frm = (blank)this.ActiveMdiChild;
            //Указываем, что родительской формой является форма frmmain	
            frm.MdiParent = this;
            //Вызываем диалог
            fontDialog1.ShowColor = true;
            //Связываем свойства SelectionFont и SelectionColor элемента RichTextBox 
            //с соответствующими свойствами диалога
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            //Если выбран диалог открытия файла, выполняем условие
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color;
            }
            //Показываем форму
            frm.Show();
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionColor = colorDialog1.Color;
            }

            frm.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создаем новый экземпляр формы  About
            About frm = new About();
            frm.Show();
        }

        private void tbNew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(this, new EventArgs());
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            mnuOpen_Click_1(this, new EventArgs());
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            mnuSave_Click(this, new EventArgs());
        }

        private void tbCut_Click(object sender, EventArgs e)
        {
            mnuCut_Click(this, new EventArgs());
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            mnuCopy_Click(this, new EventArgs());
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            mnuPaste_Click(this, new EventArgs());
        }

        private void frmmain_Load(object sender, EventArgs e)
        {

        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"C:\Users\super\Documents\HelpNDoc\Output\html\CodePadC.html");
        }

        private void mnuEnglish_Click(object sender, EventArgs e)
        {
            //Устанавливаем английскую культуру в качестве выбранной.
            CultureDefine = EnglishCulture;
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, false);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, false);
            //Создаем новый экземпляр frm формы Form1:
            frmmain frm = new frmmain(CultureDefine);
            //Скрываем текущий экземпляр
            this.Hide();
            //Вызываем новый экземпляр
            frm.Show();
        }

        private void mnuRussian_Click(object sender, EventArgs e)
        {
            CultureDefine = RussianCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, false);
            frmmain frm = new frmmain(CultureDefine);
            this.Hide();
            frm.Show();
        }
       

        private void frmmain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
