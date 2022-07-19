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
        private string brand;
        public string year;
        public int id;
        public bool isSidecar;
        public string design;

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

        public Scooter(string brand, string year, int id,
            bool isSidecar, string design) : base(CarType) 
        { 
            Brand = brand;
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
