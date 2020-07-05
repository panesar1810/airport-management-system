using Midterm.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Midterm.services
{
    public class PassengerService
    {
        private readonly List<Passenger> Passengers = new List<Passenger>();
        private CustomerService customerService;
        private FlightService flightService;

        public PassengerService(CustomerService customerService, FlightService flightService)
        {
            this.customerService = customerService;
            this.flightService = flightService;

            Passengers.Add(new Passenger(0, 0, 0));
            Passengers.Add(new Passenger(1, 1, 1));
            Passengers.Add(new Passenger(2, 2, 2));
            Passengers.Add(new Passenger(3, 3, 3));
            Passengers.Add(new Passenger(4, 4, 4));
            Passengers.Add(new Passenger(5, 5, 5));
        }

        public void Add(Passenger passenger)
        {
            Passengers.Add(passenger);
        }

        public void Update(Passenger passenger)
        {
            int index = Passengers.FindIndex(ps => ps.ID == passenger.ID);
            Passengers.RemoveAt(index);
            Passengers.Insert(index, passenger);
        }

        public void Delete(int id)
        {
            int index = Passengers.FindIndex(ps => ps.ID == id);
            Passengers.RemoveAt(index);
        }

        public Passenger Find(int id)
        {
            return (from ps in Passengers
                    where ps.ID.Equals(id)
                    select ps).FirstOrDefault();
        }

        public List<Passenger> GetPassengers()
        {
            return (from ps in this.Passengers select ps).ToList();
        }

    }
}
