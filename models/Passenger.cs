using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.models
{
    public class Passenger
    {
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public int FlightId { set; get; }

        public Passenger() { }

        public Passenger(int id, int custId, int flightId)
        {
            ID = id;
            CustomerID = custId;
            FlightId = flightId;
        }
    }
}
