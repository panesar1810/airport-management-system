using Midterm.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm.services
{
    public class FlightService
    {
        private Stack<Flight> Flights = new Stack<Flight>();
        private AirlineService airlineService;
        private int IdCounter;

        public FlightService(AirlineService airlineService)
        {
            this.airlineService = airlineService;

            Flights.Push(new Flight(0, 0, "Brampton1", "Delhi", "4/9/20", 7.0));
            Flights.Push(new Flight(1, 1, "Brampton2", "Delhi", "4/9/20", 7.0));
            Flights.Push(new Flight(2, 2, "Brampton3", "Delhi", "4/9/20", 7.0));
            Flights.Push(new Flight(3, 3, "Brampton4", "Delhi", "4/9/20", 7.0));
            Flights.Push(new Flight(4, 4, "Brampton5", "Delhi", "4/9/20", 7.0));
            Flights.Push(new Flight(5, 5, "Brampton6", "Delhi", "4/9/20", 7.0));
        }

        public void Add(Flight flight)
        {
            Flights.Push(flight);
        }

        public void Update(Flight flight)
        {
            int index = GetFlights().FindIndex(fl => fl.ID == flight.ID);
            List<Flight> flightList = Flights.ToList();
            flightList.RemoveAt(index);
            flightList.Insert(index, flight); 
            Stack<Flight> stflights = new Stack<Flight>();
            flightList.ForEach(fl => stflights.Push(fl));
            Flights = stflights;
        }

        public void Delete(int id)
        {
            int index = GetFlights().FindIndex(fl => fl.ID == id);
            List<Flight> flightList = Flights.ToList();
            flightList.RemoveAt(index);
            Stack<Flight> stflights = new Stack<Flight>();
            flightList.ForEach(fl => stflights.Push(fl));
            Flights = stflights;
        }

        public List<Flight> GetFlights()
        {
            return (from fl in Flights select fl).ToList();
        }

        public Flight Find(int id)
        {
            return (from fl in Flights
                    where fl.ID.Equals(id)
                    select fl).FirstOrDefault();
        }

    }
}
