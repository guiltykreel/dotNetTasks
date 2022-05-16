using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    public class Bird : IFlyable
    {
        public Coordinate CurrentPosition { get; set; }

        double Time;
        Random Speed;
        
        const int MaxHeight = 2;
        const int MaxFlightDistance = 100;
        
        public void FlyTo() // set new CurrentPosition (Coordinate)
        {
            
            Console.WriteLine("Fly to point :   X = ");
            uint x = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("                 Y = ");
            uint y = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("                 Z = ");
            uint z = Convert.ToUInt32(Console.ReadLine());
            Limitations(x ,y,z);
        }


        public double GetFlyTime(Coordinate coordinate) // count flying time from previous point to new point
        {

            coordinate = CurrentPosition;
            FlyTo();
            Speed = new Random();
            Time = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X),2)+ Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X),2) + Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X),2));
            Time = (Time / Speed.Next(1,20));
            return Time;
            
        }

        void Limitations(uint x, uint y, uint z)
        {
           
            //bird can't fly above 2 km 
            if (z >MaxHeight)
            {
                Console.WriteLine("Too high.");
                FlyTo();
            }
            // max flight distance 10 km 
            else if (Math.Sqrt(Math.Pow((Convert.ToDouble(CurrentPosition.X) - x),2)+Math.Pow((Convert.ToDouble(CurrentPosition.Y)-y),2))>MaxFlightDistance)
            {
                Console.WriteLine("Too long distance, bird will be exhausted.");
                FlyTo();
            }
            else 
            {
                CurrentPosition = new Coordinate(x, y, z);
            }
        }

        public void CurrentPoint() // show current point
        {
            Console.WriteLine($"X: {CurrentPosition.X}; Y: {CurrentPosition.Y}; Z: {CurrentPosition.Z}");
        }

        
    }
}