using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    public class Chassis
    {
        public int WheelAmount;
        public Guid Number;
        public double MaxStress;

        public Chassis(object CarType)
        {
            switch (CarType)
            {
                case "Passenger":
                    WheelAmount = 4;
                    Number = Guid.NewGuid();
                    MaxStress = 5000;
                    break;
                case "Cargo":
                    WheelAmount = 4;
                    Number = Guid.NewGuid();
                    MaxStress = 50000;
                    break;
                case "Bus":
                    WheelAmount = 4;
                    Number = Guid.NewGuid();
                    MaxStress = 30000;
                    break;
                case "Scooter":
                    WheelAmount = 2;
                    Number = Guid.NewGuid();
                    MaxStress = 700;
                    break;
            }
        }

        public void ChassisDescription()
        {
            Console.WriteLine($"Wheel amount: {WheelAmount}");
            Console.WriteLine($"Chassis number: {Number}");
            Console.WriteLine($"Chassis max stress: {MaxStress}");
        }
    }
}