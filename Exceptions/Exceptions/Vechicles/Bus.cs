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
        private string brand;
        public string year;
        public int id;
        public bool isDoubleDecker;
        public int maxPassengersNumber;
        public string destination;

        public string Brand
        {
            get { return brand; }
            set
            {
                //InitializationExeption Model of initializated object is not contained in 
                //Model list (xml file)
                //filepath is DataFiles\CarModelList.xml
                if (DataFile.GetModelList().Contains(value))
                {
                    brand = value;
                }
                else
                {
                    throw new Exceptions.AutoparkException("This model is out of list", value);
                }
            }
        }

        public Bus(string brand, string year, int id, bool isDoubleDecker,
            int maxPassengersNumber, string destination) : base(CarType) 
        {
            Brand = brand;
            this.year = year;
            this.id = id;
            this.isDoubleDecker = isDoubleDecker;
            this.maxPassengersNumber = maxPassengersNumber;
            this.destination = destination;
        }

        public void GetDescription()
        {
            Console.WriteLine($"Brand: {brand}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Double Decker: {isDoubleDecker}");
            Console.WriteLine($"Number pf passengers: {maxPassengersNumber}");
            Console.WriteLine($"Destination: {destination}");
            base.Description();
        }
    }
}
