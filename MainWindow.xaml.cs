using Midterm.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterm
{
    public partial class MainWindow : Window
    {
        private LoginService loginService = new LoginService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Waring", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginService.Login(TxtUsername.Text, TxtPassword.Password))
            {
                HomeWindow home = new HomeWindow(loginService);
                home.Show();
                Close();
            } 
            else
            {
                MessageBox.Show("Invalid Credentials", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
