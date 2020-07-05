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
    public partial class FlightWindow : Window
    {
        private FlightService flightService;
        private LoginService loginService;
        public FlightWindow(FlightService flightService, LoginService loginService)
        {
            this.flightService = flightService;
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

        private void LstFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstFlights.SelectedIndex;
            Flight flight = flightService.Find(index);
            if (null != flight)
            {
                TxtAirlineID.Text = flight.AirlineId.ToString();
                TxtDepCity.Text = flight.DepartureCity;
                TxtDesCity.Text = flight.DestinationCity;
                TxtDepDate.Text = flight.DepartureDate;
                TxtFlightTime.Text = flight.FlightTime.ToString();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtAirlineID.Text.Equals("") || TxtDepCity.Text.Equals("") || TxtDesCity.Text.Equals("") || TxtDepDate.Text.Equals("") || TxtFlightTime.Text.Equals(""))
            {
                MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Flight flight = new Flight(flightService.GetFlights().Count, int.Parse(TxtAirlineID.Text), TxtDepCity.Text, TxtDesCity.Text, TxtDepDate.Text, double.Parse(TxtFlightTime.Text));
                    flightService.Add(flight);
                    RefreshList();
                } catch(Exception ex)
                {
                    MessageBox.Show("Please enter an integer for Airline ID ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (loginService.IsSuperUser)
            {
                if (TxtAirlineID.Text.Equals("") || TxtDepCity.Text.Equals("") || TxtDesCity.Text.Equals("") || TxtDepDate.Text.Equals("") || TxtFlightTime.Text.Equals(""))
                {
                    MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure to update this flight?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Flight fl = new Flight(LstFlights.SelectedIndex, int.Parse(TxtAirlineID.Text), TxtDepCity.Text, TxtDesCity.Text, TxtDepDate.Text, double.Parse(TxtFlightTime.Text));
                            flightService.Update(fl);
                            RefreshList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please enter an integer for Airline ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                if (MessageBox.Show("Are you sure to delete this flight?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    flightService.Delete(LstFlights.SelectedIndex);

                    for (int i = 0; i < flightService.GetFlights().Count; i++)
                    {
                        flightService.GetFlights()[i].ID = i;
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
            LstFlights.DataContext = (from fl in flightService.GetFlights()
                                        select fl.AirlineId).ToList();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
        }
    }
}
