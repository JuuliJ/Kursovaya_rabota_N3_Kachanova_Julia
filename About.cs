using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            //Добавляем блок для обработки исключений — по разным причинам 
            //пользователь может не получить доступа к ресурсу.
            try
            {
                //Вызываем метод VisitLink, определенный ниже
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Unable to open link that was clicked.");
            }

        }

        //Создаем метод VisitLink
        private void VisitLink()
        {
            // Изменяем цвет посещенной ссылки, программно 
            //обращаясь к свойству LinkVisited элемента LinkLabel 
            linkLabel1.LinkVisited = true;
            //Вызываем метод Process.Start method  для запуска браузера, 
            //установленного по умолчанию, и открытия ссылки
            System.Diagnostics.Process.Start("http://www.mysite.com");
        }
        //Кнопка OK просто будет закрывать форму:
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
