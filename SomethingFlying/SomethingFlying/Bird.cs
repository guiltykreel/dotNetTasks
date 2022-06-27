using System;

namespace SomethingFlying
{
    /// <summary>
    /// Class that creatse objects of the bird type  
    /// </summary>
    public class Bird : IFlyable
    {
        private Random speed; //Travel speed of bird (km/h)
        private const int MaxHeight = 2; //Maximum flight height of bird (km)
        private const int MaxFlightDistance = 100; // Maximum travel distance (km) of bird
        private double time; //Flight time

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

            Limitations(x, y, z);
        }

        /// <summary>
        /// Method set new position for object and calculate flying time 
        /// </summary>
        /// <param name="coordinate"> Get current coordinates of object </param>
        /// <returns> Return flying time from current position to new position  </returns>
        public double GetFlyTime(Coordinate coordinate)
        {           
            coordinate = CurrentPosition;
            
            FlyTo();
            
            speed = new Random();
            
            //Calculate flight distance
            time = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) +
                Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) +
                Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2));
            
            //Calculate flight time
            time = (time / speed.Next(1, 20));
            
            return time;
        }

        /// <summary>
        /// Method defines some limitations for bird type objects 
        /// </summary>
        ///<param name = "x" > Get new X coordinate</param>
        ///<param name = "y" > Get new Y coordinate</param>
        /// <param name = "z" > Get new Z coordinate</param>
        private void Limitations(uint x, uint y, uint z)
        {
            
            if (z > MaxHeight)
            {
                //bird can't fly above 2 km 
                Console.WriteLine("Too high.");

                FlyTo();
            }            
            else if (Math.Sqrt(Math.Pow((Convert.ToDouble(CurrentPosition.X) - x), 2) +
                Math.Pow((Convert.ToDouble(CurrentPosition.Y) - y), 2)) > MaxFlightDistance)
            {
                // max flight distance 10 km 
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