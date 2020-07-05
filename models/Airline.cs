using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.models
{
    public class Airline
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Airplane { set; get; }
        public int SeatsAvailable { set; get; }
        public string MealAvailable { set; get; }

        public Airline() { }

        public Airline(int id, string name, string airplane, int seatsavailable, string mealavailable)
        {
            ID = ID;
            Name = name;
            Airplane = airplane;
            SeatsAvailable = seatsavailable;
            MealAvailable = mealavailable;
        }
    }
}
