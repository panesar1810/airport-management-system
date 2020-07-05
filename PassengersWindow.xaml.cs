using Midterm.models;
using Midterm.services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class PassengersWindow : Window
    {
        private PassengerService passengerService;
        private LoginService loginService;

        public PassengersWindow(PassengerService passengerService, LoginService loginService)
        {
            this.passengerService = passengerService;
            this.loginService = loginService;
            InitializeComponent();
            RefreshList();
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to Quit?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void LstPassengers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstPassengers.SelectedIndex;
            Passenger ps = passengerService.Find(index);
            if (null != ps)
            {
                TxtCustID.Text = ps.CustomerID.ToString();
                TxtFlightID.Text = ps.FlightId.ToString();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCustID.Text.Equals("") || TxtFlightID.Text.Equals(""))
            {
                MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Passenger ps = new Passenger(passengerService.GetPassengers().Count, int.Parse(TxtCustID.Text), int.Parse(TxtFlightID.Text));
                    passengerService.Add(ps);
                    RefreshList();
                } catch (Exception ex)
                {
                    MessageBox.Show("Please enter an integer for ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (loginService.IsSuperUser)
            {
                if (TxtCustID.Text.Equals("") || TxtFlightID.Text.Equals(""))
                {
                    MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure to update this passenger?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Passenger ps = new Passenger(LstPassengers.SelectedIndex, int.Parse(TxtCustID.Text), int.Parse(TxtFlightID.Text));
                            passengerService.Update(ps);
                            RefreshList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please enter an integer for ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Access Denied", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (loginService.IsSuperUser)
            {
                if (MessageBox.Show("Are you sure to delete this passengers?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    passengerService.Delete(LstPassengers.SelectedIndex);

                    for (int i = 0; i < passengerService.GetPassengers().Count; i++)
                    {
                        passengerService.GetPassengers()[i].ID = i;
                    }

                    RefreshList();
                }
            }
            else
            {
                MessageBox.Show("Access Denied", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshList()
        {
            LstPassengers.DataContext = (from ps in passengerService.GetPassengers()
                                        select ps.ID).ToList();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
        }
    }
}
