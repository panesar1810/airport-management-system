using Midterm.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Midterm
{
    public partial class HomeWindow : Window
    {
        private LoginService loginService;
        private MainService service = new MainService();

        public HomeWindow(LoginService loginService)
        {
            InitializeComponent();
            this.loginService = loginService;
            LbWelcome.Content = "Welcome " + this.loginService.LoggedUser.Username;
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("You are about to exit application!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
        }

        private void View_Airlines_Click(object sender, RoutedEventArgs e)
        {
            new AirlineWindow(service.GetAirlineService(), loginService).Show();
            Close();
        }
        private void View_Customers_Click(object sender, RoutedEventArgs e)
        {
            new CustomersWindow(service.GetCustomerService(), loginService).Show();
            Close();
        }
        private void View_Flights_Click(object sender, RoutedEventArgs e)
        {
            new FlightWindow(service.GetFlightService(), loginService).Show();
            Close();
        }
        private void View_Passengers_Click(object sender, RoutedEventArgs e)
        {
            new PassengersWindow(service.GetPassengerService(), loginService).Show();
            Close();
        }

    }
}
