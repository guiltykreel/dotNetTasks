using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoPark
{
    public class Passenger : Vehicle
    {
        private static string CarType = "Passenger";
        private string brand;
        public string year;
        public int id;
        public int numberOfPassengers;        

        public string  Brand
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

        public Passenger(string brand, string year, int id, 
            int nunumberOfPassengers) : base(CarType)
        {
            Brand = brand;
            this.year = year;
            this.id = id;
            this.numberOfPassengers = nunumberOfPassengers;
        }

        public void GetDescription()
        {
            Console.WriteLine($"Brand: {brand}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Number of passengers: {numberOfPassengers}");
            base.Description();
        }
    }
}
