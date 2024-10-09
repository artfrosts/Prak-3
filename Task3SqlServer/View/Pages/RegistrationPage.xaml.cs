using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Task3SqlServer.Core;
using Task3SqlServer.Model;

namespace Task3SqlServer.View.Pages
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            CbRole.ItemsSource = CoreConnection.DB.Roles.ToList();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) |
                string.IsNullOrEmpty(PbPassword.Password))
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
                    CoreConnection.DB.Users.Add(new User()
                    {
                        UserLogin = TbLogin.Text,
                        UserPassword = PbPassword.Password,
                        RoleID = Convert.ToInt32(CbRole.Text)
                    });
                    CoreConnection.DB.SaveChanges();
                    MessageBox.Show("Учетная запись создана",
                                    "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    CoreConnection.CoreFrame.Navigate(new MainLoginPage());
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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new MainLoginPage());
        }
    }
}
