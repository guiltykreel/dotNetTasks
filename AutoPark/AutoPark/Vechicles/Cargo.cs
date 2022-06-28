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
        public string brand;
        public string year;
        public int id;
        public string companyName;
        public bool isRefregerator;
        public int bodyVolume; 

        public Cargo(string brand, string year, int id, string companyName, 
            bool isRefregerator, int bodyVolume) : base(CarType) 
        {
            this.brand = brand;
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
