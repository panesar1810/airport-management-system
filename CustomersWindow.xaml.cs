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
    public partial class CustomersWindow : Window
    {
        private CustomerService customerService;
        private LoginService loginService;

        public CustomersWindow(CustomerService customerService, LoginService loginService)
        {
            this.customerService = customerService;
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


        private void LstCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstCustomers.SelectedIndex;
            Customer cu = customerService.FindCustomer(index);
            if (null != cu)
            {
                TxtName.Text = cu.Name;
                TxtAddress.Text = cu.Address;
                TxtEmail.Text = cu.Email;
                TxtPhone.Text = cu.PhoneNumber;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtEmail.Text.Equals("") || TxtName.Text.Equals("") || TxtPhone.Text.Equals("") || TxtAddress.Text.Equals(""))
            {
                MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Customer cu = new Customer(customerService.GetCustomers().Count, TxtName.Text, TxtAddress.Text, TxtEmail.Text, TxtPhone.Text);
                customerService.Add(cu);
                RefreshList();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (loginService.IsSuperUser)
            {
                if (TxtEmail.Text.Equals("") || TxtName.Text.Equals("") || TxtPhone.Text.Equals("") || TxtAddress.Text.Equals(""))
                {
                    MessageBox.Show("All Fields Required", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure to update this customer?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        Customer cu = new Customer(LstCustomers.SelectedIndex, TxtName.Text, TxtAddress.Text, TxtEmail.Text, TxtPhone.Text);
                        customerService.Update(cu);
                        RefreshList();
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
                if (MessageBox.Show("Are you sure to delete this customer?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    customerService.Delete(LstCustomers.SelectedIndex);

                    for (int i = 0; i < customerService.GetCustomers().Count; i++)
                    {
                        customerService.GetCustomers()[i].ID = i;
                    }

                    RefreshList();
                }
                else
                {
                    MessageBox.Show("Plase Enter valid Id number", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Access Denied", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshList()
        {
            LstCustomers.DataContext = (from cu in customerService.GetCustomers()
                                        select cu.Name).ToList();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
        }

    }
}
