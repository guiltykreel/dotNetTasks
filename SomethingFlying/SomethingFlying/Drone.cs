using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    /// <summary>
    /// Class that creatse objects of the drone type  
    /// </summary>
    class Drone : IFlyable
    {

        private const int Speed = 40; // Travel speed of drone (km/h)
        private const int MaxHeight = 2; // Maximum flight height of drone (km)
        private const int MaxFlightDistance = 100; // Maximum flight distance of drone (km)

        /// <summary>
        /// Property that defines the coordinates of object 
        /// </summary>
        public Coordinate CurrentPosition { get; set; }

        /// <summary>
        /// Method that write in console current coordinates of object
        /// </summary>
        public void GetCurrentPoint()
        {
            Console.WriteLine($"X: {CurrentPosition.X}; " +
                $"Y: {CurrentPosition.Y}; Z: {CurrentPosition.Z}");
        }

        /// <summary>
        /// Set new CurrentPosition (Coordinate) of object
        /// </summary>
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

        /// <summary>
        /// Method set new position for object and calculate flying time 
        /// </summary>
        /// <param name="coordinate"> Get current coordinates of object </param>
        /// <returns> Return flying time from current position to new position  </returns>
        public double GetFlyTime(Coordinate coordinate)
        {
            double Time;
            coordinate = CurrentPosition;
            FlyTo();
            Time = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) 
                + Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) 
                + Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2));
            Time = (Time / Speed);
            Time = (Time * 60 + ((Time * 60 - Time * 60 % 10) / 10)) / 60;
            // drone stops every 10 miuntes on 1 minute
            return Time;
        }

        /// <summary>
        /// Method defines some limitations for bird type objects 
        /// </summary>
        ///<param name = "x" > Get new X coordinate</param>
        ///<param name = "y" > Get new Y coordinate</param>
        /// <param name = "z" > Get new Z coordinate</param>
        private void Limitations(uint x, uint y, uint z)
        {
            if ( z > MaxHeight) //drone can't fly above 2 km 
            {
                Console.WriteLine("Too high. Connection is lost.");
                FlyTo();
            }
            else if (Math.Sqrt(Math.Pow((Convert.ToDouble(CurrentPosition.X) - x), 2) +
                Math.Pow((Convert.ToDouble(CurrentPosition.Y) - y), 2)+
                Math.Pow((Convert.ToDouble(CurrentPosition.Z)-z),2)) > MaxFlightDistance) // max flight distance 100 km 
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
