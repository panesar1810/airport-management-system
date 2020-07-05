using Midterm.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm.services
{
    public class AirlineService
    {
        private List<Airline> Airlines = new List<Airline>();
        private int IdCounter;

        public AirlineService()
        {
            Airlines.Add(new Airline(0, "Air CA 1", "ap1", 20, "Butter Chicken"));
            Airlines.Add(new Airline(1, "Air CA 2", "ap2", 24, "French Toast"));
            Airlines.Add(new Airline(2, "Air CA 3", "ap3", 65, "Fried Rice"));
            Airlines.Add(new Airline(3, "Air CA 4", "ap4", 435, "Chicken Sandwich"));
            Airlines.Add(new Airline(4, "Air CA 5", "ap5", 243, "Pizzas"));
            Airlines.Add(new Airline(5, "Air CA 6", "ap6", 43, "Curry with Rice"));
        }

        private int GetId()
        {
            return ++IdCounter;
        }

        public void Add(Airline airline)
        {
            Airlines.Add(airline);
        }

        public void Update(Airline airline)
        {
            int index = Airlines.FindIndex(al => al.ID == airline.ID);
            Airlines.RemoveAt(index);
            Airlines.Insert(index, airline);
        }

        public void Delete(int id)
        {
            int index = Airlines.FindIndex(al => al.ID == id);
            Airlines.RemoveAt(index);
        }

        public List<Airline> GetAirlines ()
        {
            return Airlines;
        }

        public Airline Find(int id)
        {
            return (from al in Airlines
                    where al.ID.Equals(id)
                    select al).FirstOrDefault();
        }



    }
}
