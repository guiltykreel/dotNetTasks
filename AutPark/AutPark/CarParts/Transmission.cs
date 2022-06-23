using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    public class Transmission
    {
        public string Type;
        public int GearNum;
        public string Manufacturer;
        public Transmission(object CarType)
        {
            switch (CarType.ToString())
            {
                case "Passenger":
                    Type = "Automatic";
                    GearNum = 5;
                    Manufacturer = "Porshce";
                    break;
                case "Cargo":
                    Type = "Manual";
                    GearNum = 7;
                    Manufacturer = "MAN";
                    break;
                case "Bus":
                    Type = "Manual";
                    GearNum = 6;
                    Manufacturer = "MAZ";
                    break;
                case "Scooter":
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
