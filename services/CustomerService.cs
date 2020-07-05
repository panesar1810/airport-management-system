using Midterm.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace Midterm.services
{
    public class CustomerService
    {
        private readonly Queue<Customer> Customers = new Queue<Customer>();

        public CustomerService()
        {
            Customers.Enqueue(new Customer(0, "Derek", "10 ohara pl", "derek@gmail.com", "9343244323"));
            Customers.Enqueue(new Customer(1, "Banas", "20 lake road", "banas@gmail.com", "9346544323"));
            Customers.Enqueue(new Customer(2, "Ram", "54 king st", "ram@gmail.com", "9343219373"));
            Customers.Enqueue(new Customer(3, "Betty", "56 queen st", "bettyk@gmail.com", "9343297375"));
            Customers.Enqueue(new Customer(4, "Jughead", "10 ohara pl", "jughead@gmail.com", "3964344323"));
            Customers.Enqueue(new Customer(5, "Erik", "67 newlake pl", "erik@gmail.com", "9343212345"));
        }

        public Customer Add(Customer customer)
        {
            Customers.Enqueue(customer);
            return customer;
        }


        public Customer Update(Customer customer)
        {
            List<Customer> tempCustomers = new List<Customer>();
            GetCustomers().ForEach(cu => tempCustomers.Add(cu));
            // empty the queue
            while (Customers.Count > 0) Customers.Dequeue();

            int index = tempCustomers.FindIndex(cust => cust.ID == customer.ID);
            tempCustomers.RemoveAt(index);
            tempCustomers.Insert(index, customer);

            // repopupate queue with updated customer
            tempCustomers.ForEach(cust => Customers.Enqueue(cust));

            return customer;
        }

        public void Delete(int id)
        {
            List<Customer> tempCustomers = new List<Customer>();
            GetCustomers().ForEach(cu => tempCustomers.Add(cu));
            // empty the queue
            while (Customers.Count > 0) Customers.Dequeue();

            int index = tempCustomers.FindIndex(cust => cust.ID == id);
            tempCustomers.RemoveAt(index);

            // repopupate queue with updated customer
            tempCustomers.ForEach(cust => Customers.Enqueue(cust));
        }

        public Customer FindCustomer(int id)
        {
            return (from cu in Customers
                    where cu.ID.Equals(id)
                    select cu).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return (from cu in Customers select cu).ToList();
        }

    }
}
