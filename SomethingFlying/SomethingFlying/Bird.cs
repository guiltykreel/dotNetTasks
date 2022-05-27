using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    /// <summary>
    /// Class that creatse objects of the bird type  
    /// </summary>
    public class Bird : IFlyable
    {
        private Random Speed; //Travel speed of bird (km/h)
        private const int MaxHeight = 2; //Maximum flight height of bird (km)
        private const int MaxFlightDistance = 100; // Maximum travel distance (km) of bird

        /// <summary>
        /// Property that defines the coordinates of object 
        /// </summary>
        public Coordinate CurrentPosition { get; set; }

        /// <summary>
        /// Method that write in console current coordinates of object
        /// </summary>
        public void GetCurrentPoint() // show current point
        {
            Console.WriteLine($"X: {CurrentPosition.X}; " +
                $"Y: {CurrentPosition.Y}; Z: {CurrentPosition.Z}");
        }

        /// <summary>
        /// Set new CurrentPosition (Coordinate) of object
        /// </summary>
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
            Speed = new Random();
            Time = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X),2)+
                Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X),2) +
                Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X),2));
            Time = (Time / Speed.Next(1,20));
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
           
            //bird can't fly above 2 km 
            if (z >MaxHeight)
            {
                Console.WriteLine("Too high.");
                FlyTo();
            }
            // max flight distance 10 km 
            else if (Math.Sqrt(Math.Pow((Convert.ToDouble(CurrentPosition.X) - x),2)+
                Math.Pow((Convert.ToDouble(CurrentPosition.Y)-y),2))>MaxFlightDistance)
            {
                Console.WriteLine("Too long distance, bird will be exhausted.");
                FlyTo();
            }
            else 
            {
                // Set new coordinate of object
                CurrentPosition = new Coordinate(x, y, z);
            }
        }

        

        
    }
}