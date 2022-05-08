using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    public class Chassis
    {
        private int WheelAmount;
        private Guid Number;
        private double MaxStress;

        public Chassis(string cartype)
        {
            switch (cartype)
            {
                case "passenger":
                    WheelAmount = 4;
                    Number = Guid.NewGuid();
                    MaxStress = 5000;
                    break;
                case "cargo":
                    WheelAmount = 4;
                    Number = Guid.NewGuid();
                    MaxStress = 50000;
                    break;
                case "bus":
                    WheelAmount = 4;
                    Number = Guid.NewGuid();
                    MaxStress = 30000;
                    break;
                case "scooter":
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