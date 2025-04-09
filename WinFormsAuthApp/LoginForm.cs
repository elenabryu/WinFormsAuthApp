using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WinFormsAuthApp
{
    public partial class LoginForm : Form
    {
        private string generatedCaptcha;
        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            GenerateCaptcha();
            passwordTextBox.UseSystemPasswordChar = true;
        }
            private void GenerateCaptcha()
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();
                generatedCaptcha = new string(Enumerable.Repeat(chars, 6) // Минимум 4 символа (увеличил до 6)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                //  Применим случайные эффекты к метке CAPTCHA (перечеркивание, наложение)
                captchaLabel.Text = generatedCaptcha;
                captchaLabel.Font = new Font(captchaLabel.Font, FontStyle.Italic | FontStyle.Strikeout);
            }

            private void loginButton_Click(object sender, EventArgs e)
            {
                if (usernameTextBox.Text == "user" && passwordTextBox.Text == "user")
                {
                    // Дополнительная проверка CAPTCHA (хотя в задании не требуется ввод)
                    //if (captchaTextBox.Text == generatedCaptcha)
                    //{
                    MainForm mainForm = new MainForm(this); // Передаем ссылку на форму авторизации
                    mainForm.Show();
                    this.Hide(); // Скрываем форму авторизации
                                 //}
                                 //else
                                 //{
                                 //    MessageBox.Show("Неверная CAPTCHA!");
                                 //    GenerateCaptcha(); // Обновляем CAPTCHA при ошибке
                                 //}
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    GenerateCaptcha();
                }
            }

            private void togglePasswordButton_Click(object sender, EventArgs e)
            {
                passwordVisible = !passwordVisible;
                passwordTextBox.UseSystemPasswordChar = !passwordVisible; // Инвертируем видимость

                // Смена иконки (простой пример, нужны настоящие иконки)
                togglePasswordButton.Text = passwordVisible ? "Hide" : "Show";
            }

            private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }
        }
    }
