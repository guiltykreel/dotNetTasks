using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    public class Cargo : Vehicle
    {
        private static string CarType = "Cargo"; 
        private string brand;
        public string year;
        public int id;
        public string companyName;
        public bool isRefregerator;
        public int bodyVolume;

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

        public Cargo(string brand, string year, int id, string companyName, 
            bool isRefregerator, int bodyVolume) : base(CarType) 
        {
            Brand = brand;
            this.year = year;
            this.id = id;
            this.companyName = companyName;
            this.isRefregerator = isRefregerator;
            this.bodyVolume = bodyVolume;
        }

        public void GetDescription()
        {
            Console.WriteLine($"Brand: {brand}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Company name: {companyName}");
            Console.WriteLine($"With refragirator: {isRefregerator}");
            Console.WriteLine($"Body Volume: {bodyVolume}");
            base.Description();
        }
    }
}
