using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    /// <summary>
    /// Generate engine for different types of vechicles
    /// </summary>
    public class Engine
    {
        public double Power;
        public double Volume;
        public string Type;
        public Guid SerialNumber; // generate randomly Guid number for part

        public Engine(object CarType)
        {
           
            switch (CarType) {
                case "Passenger":
                Power = 250;
                Volume = 2;
                Type = "injector";
                SerialNumber = Guid.NewGuid();
                    break;
                case "Cargo":
                    Power = 750;
                    Volume = 15;
                    Type = "Diesel";
                    SerialNumber = Guid.NewGuid();
                    break;
                case "Bus":
                    Power = 500;
                    Volume = 6;
                    Type = "Hybrid";
                    SerialNumber = Guid.NewGuid();
                    break;
                case "Scooter":
                    Power = 50;
                    Volume = 0.6;
                    Type = "Corn";
                    SerialNumber = Guid.NewGuid();
                    break;
            }
        }
        public void EngineDescription() //Write description of the part in coscole
        {
            Console.WriteLine($"Engine Power = {Power}");
            Console.WriteLine($"Engine Volume = {Volume}");
            Console.WriteLine($"Engine Type = {Type}");
            Console.WriteLine($"Engine Serial Number = {SerialNumber}");
        }
    }
}
