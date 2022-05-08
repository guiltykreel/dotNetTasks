using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    public class Transmission
    {
        private string Type;
        private int GearNum;
        private string Manufacturer;
        public Transmission(string cartype)
        {
            switch (cartype)
            {
                case "passenger":
                    Type = "Automatic";
                    GearNum = 5;
                    Manufacturer = "Porshce";
                    break;
                case "cargo":
                    Type = "Manual";
                    GearNum = 7;
                    Manufacturer = "MAN";
                    break;
                case "bus":
                    Type = "Manual";
                    GearNum = 6;
                    Manufacturer = "MAZ";
                    break;
                case "scooter":
                    Type = "Automatic";
                    GearNum = 4;
                    Manufacturer = "Harley Davidson";
                    break;
            }
        }

        public void TransmissionDescription()
        {
            Console.WriteLine($"Transmission type: {Type}");
            Console.WriteLine($"Gear number: {GearNum}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
        }
    }
}
