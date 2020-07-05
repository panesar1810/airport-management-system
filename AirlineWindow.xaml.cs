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
    public partial class AirlineWindow : Window
    {
        private AirlineService airlineService;
        private LoginService loginService;

        public AirlineWindow(AirlineService airlineService, LoginService loginService)
        {
            this.airlineService = airlineService;
            this.loginService = loginService;
            InitializeComponent();
            RefreshList();
        }

        private void LstAirlines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstAirlines.SelectedIndex;
            Airline al = airlineService.Find(index);
            if (null != al)
            {
                TxtName.Text = al.Name;
                TxtSeatsAvailable.Text = al.SeatsAvailable.ToString();
                RadAirplane.Content = al.Airplane;
                RadMeals.Content = al.MealAvailable;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text.Equals("") || TxtSeatsAvailable.Text.Equals(""))
            {
                MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                { 
                    Airline al = new Airline(airlineService.GetAirlines().Count, TxtName.Text, RadAirplane.Content.ToString(), int.Parse(TxtSeatsAvailable.Text), RadMeals.Content.ToString());
                    airlineService.Add(al);
                    RefreshList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter an Integer in seats", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
            
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (loginService.IsSuperUser)
            {
                if (TxtName.Text.Equals("") || TxtSeatsAvailable.Text.Equals(""))
                {
                    MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure to update this Airline?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Airline al = new Airline(airlineService.GetAirlines().Count, TxtName.Text, RadAirplane.Content.ToString(), int.Parse(TxtSeatsAvailable.Text), RadMeals.Content.ToString());
                            airlineService.Update(al);
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
                    airlineService.Delete(LstAirlines.SelectedIndex);

                    for (int i = 0; i < airlineService.GetAirlines().Count; i++)
                    {
                        airlineService.GetAirlines()[i].ID = i;
                    }

                    RefreshList();
                }
            }
            else
            {
                MessageBox.Show("Access Denied", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to Quit?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void RefreshList()
        {
            LstAirlines.DataContext = (from al in airlineService.GetAirlines()
                                         select al.Name).ToList();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
        }

    }
}
