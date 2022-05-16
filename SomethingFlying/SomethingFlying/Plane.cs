using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    class Plane : IFlyable
    {

        public Coordinate CurrentPosition { get; set; }
        

        
        private const double MaxFlightDistance = 1500;
        private const long MaxHeight = 15;
        const double Speed = 200;
        
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
            double Distance;
            double Time = 0;
            coordinate = CurrentPosition;
            FlyTo();
            
            // calculate flight distance
            Distance = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) + Math.Pow(Convert.ToDouble(CurrentPosition.Y - coordinate.Y), 2) + Math.Pow(Convert.ToDouble(CurrentPosition.Z - coordinate.Z), 2));
            //calculate flight time
            
            for (int n = 0; n < ( Convert.ToInt32(Distance) / 10)-1; n++)
            {
                Time = Time + (10 / (Speed + (n * 10))); // speed increase on 10 km/h every 10 km
            }
            
            return Time;
        }

        void Limitations(uint x, uint y, uint z)
        {
            if (z > MaxHeight) //plane can't fly above 10 km 
            {
                Console.WriteLine("Too high.");
                FlyTo();
            }
            else if (Math.Sqrt(
                Math.Pow(
                    (Convert.ToDouble(CurrentPosition.X) - x), 2) 
                + Math.Pow(
                    (Convert.ToDouble(CurrentPosition.Y) - y), 2) 
                + Math.Pow(
                    (Convert.ToDouble( CurrentPosition.Z) -z),2) ) > MaxFlightDistance) // max flight distance 15000 km 
            {
                Console.WriteLine("Too long distance, not enogh fuel.");
                FlyTo();
            }
            else
            {
                CurrentPosition = new Coordinate(x, y, z);
            }
        }
    }
}
