using System.Windows;
using Task3SqlServer.Core;
using Task3SqlServer.Model;
using Task3SqlServer.View.Pages;

namespace Task3SqlServer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CoreConnection.CoreFrame = MainFrame;
            CoreConnection.DB = new Task3DBEntities();
            MainFrame.Navigate(new MainLoginPage());
        }
    }
}
