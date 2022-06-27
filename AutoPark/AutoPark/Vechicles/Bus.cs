using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    public class Bus : Vehicle
    {

        private static string CarType = "Bus";
        public string brand;
        public string year;
        public int id;
        public bool isDoubleDecker;
        public int maxPassengersNumber;
        public string destination;

        public Bus(string brand, string year, int id, bool isDoubleDecker,
            int maxPassengersNumber, string destination) : base(CarType) 
        {
            this.brand = brand;
            this.year = year;
            this.id = id;
            this.isDoubleDecker = isDoubleDecker;
            this.maxPassengersNumber = maxPassengersNumber;
            this.destination = destination;
        }
    }
}
