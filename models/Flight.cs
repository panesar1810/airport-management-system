using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.models
{
    public class Flight
    {
        public int ID { set; get; }
        public int AirlineId { set; get; }
        public string DepartureCity { set; get; }
        public string DestinationCity { set; get; }
        public string DepartureDate { set; get; }
        public double FlightTime { set; get; }

        public Flight() { }

        public Flight(int id, int airlineId, string depCity, string desCity, string depDate, double hrs)
        {
            ID = id;
            AirlineId = airlineId;
            DepartureCity = depCity;
            DestinationCity = desCity;
            DepartureDate = depDate;
            FlightTime = hrs;
        }
    }
}
