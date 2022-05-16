using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    class Drone : IFlyable
    {
        public Coordinate CurrentPosition { get; set; }

        double Time;
        const int Speed = 40;

        const int MaxHeight = 2;
        const int MaxFlightDistance = 100;
        public void CurrentPoint()
        {
            Console.WriteLine($"X: {CurrentPosition.X}; Y: {CurrentPosition.Y}; Z: {CurrentPosition.Z}");
        }

        public void FlyTo()
        {
            Console.WriteLine("Fly to point :   X = ");
            uint x = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("                 Y = ");
            uint y = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("                 Z = ");
            uint z = Convert.ToUInt32(Console.ReadLine());
            Limitations(x, y, z);
        }

        public double GetFlyTime(Coordinate coordinate)
        {
            coordinate = CurrentPosition;
            FlyTo();
            Time = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) + Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) + Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2));
            Time = (Time / Speed);
            Time = (Time * 60 + ((Time * 60 - Time * 60 % 10) / 10)) / 60;// drone stops every 10 miuntes on 1 minute
            return Time;
        }

        void Limitations(uint x, uint y, uint z)
        {
            if ( z > MaxHeight) //drone can't fly above 2 km 
            {
                Console.WriteLine("Too high. Connection is lost.");
                FlyTo();
            }
            else if (Math.Sqrt(Math.Pow((Convert.ToDouble(CurrentPosition.X) - x), 2) + Math.Pow((Convert.ToDouble(CurrentPosition.Y) - y), 2)+ Math.Pow((Convert.ToDouble(CurrentPosition.Z)-z),2)) > MaxFlightDistance) // max flight distance 100 km 
            {
                Console.WriteLine("Too long distance, Battery low.");
                FlyTo();
            }
            else
            {
                CurrentPosition = new Coordinate(x, y, z);
            }
        }
    }
}
