using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.models
{
    public class Customer
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }

        public Customer() { }

        public Customer(int id, string name, string address, string email, string phonenumber)
        {
            ID = id;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phonenumber;
        }

    }
}
