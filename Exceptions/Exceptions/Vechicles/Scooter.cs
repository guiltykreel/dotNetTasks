using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    public class Scooter :Vehicle
    {
        private static string CarType = "Scooter";
        public string brand;
        public string year;
        public int id;
        public bool isSidecar;
        public string design; 

        public Scooter(string brand, string year, int id,
            bool isSidecar, string design) : base(CarType) 
        { 
            this.brand = brand;
            this.year = year;
            this.id = id;
            this.isSidecar = isSidecar;
            this.design = design;
        }

        public void GetDescription()
        {
            Console.WriteLine($"Brand: {brand}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"With sidecar {isSidecar}");
            Console.WriteLine($"Design: {design}");
            base.Description();
        }
    }
}
