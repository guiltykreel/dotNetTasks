using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    public class Engine
    {
        private double Power;
        private double Volume;
        private string Type;
        private Guid SerialNumber;

        public Engine(string cartype)
        {
            switch (cartype) {
                case "passenger":
                Power = 250;
                Volume = 2;
                Type = "Electicity";
                SerialNumber = Guid.NewGuid();
                    break;
                case "cargo":
                    Power = 750;
                    Volume = 25;
                    Type = "Gasoline";
                    SerialNumber = Guid.NewGuid();
                    break;
                case "bus":
                    Power = 500;
                    Volume = 15;
                    Type = "Gasoline";
                    SerialNumber = Guid.NewGuid();
                    break;
                case "scooter":
                    Power = 50;
                    Volume = 1.5;
                    Type = "Corn";
                    SerialNumber = Guid.NewGuid();
                    break;
            }
        }
        public void EngineDescription()
        {
            Console.WriteLine($"Engine Power = {Power}");
            Console.WriteLine($"Engine Volume = {Volume}");
            Console.WriteLine($"Engine Type = {Type}");
            Console.WriteLine($"Engine Serial Number = {SerialNumber}");
        }
    }
}
