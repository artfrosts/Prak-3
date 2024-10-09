using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Task3SqlServer.Core;
using Task3SqlServer.Model;

namespace Task3SqlServer.View.Pages
{
    public partial class MainLoginPage : Page
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) |
                string.IsNullOrWhiteSpace(PbPassword.Password))
                
            {
                MessageBox.Show("Ошибка ввода данных",
                                "Системное сообщение",
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    User userModel = CoreConnection.DB.Users.FirstOrDefault(u =>
                                                    u.UserLogin == TbLogin.Text &&
                                                    u.UserPassword == PbPassword.Password);
                    if (userModel != null)
                    {
                        MessageBox.Show($"{userModel.UserLogin} - выполнен успешный вход!",
                                   "Системное сообщение",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных",
                                        "Системное сообщение",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(),
                                    "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new RegistrationPage());
        }
    }
}
