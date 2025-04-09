using System;
using System.Windows.Forms;

namespace WinFormsAuthApp
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;
        public MainForm(LoginForm login)
        {
            InitializeComponent();
            // Предположим, что у вас есть свойства для хранения ФИО и группы
            fullNameLabel.Text = "ФИО: Иванов Иван Иванович"; // Замените на ваши данные
            groupNumberLabel.Text = "Группа: 12345"; // Замените на номер вашей группы
            loginForm = login; // Сохраняем ссылку на форму авторизации
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close(); // Закрываем форму авторизации
        }
    }
}
