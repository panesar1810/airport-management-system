using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.services
{
    class MainService
    {
        public static CustomerService customerService = new CustomerService();
        public static AirlineService airlineService = new AirlineService();
        public static FlightService flightService = new FlightService(airlineService);
        public static PassengerService passengerService = new PassengerService(customerService, flightService);

        public CustomerService GetCustomerService()
        {
            return customerService;
        }
        public AirlineService GetAirlineService()
        {
            return airlineService;
        }
        public FlightService GetFlightService()
        {
            return flightService;
        }
        public PassengerService GetPassengerService()
        {
            return passengerService;
        }

    }
}
