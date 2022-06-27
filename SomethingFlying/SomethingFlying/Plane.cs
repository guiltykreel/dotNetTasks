using System;

namespace SomethingFlying
{
    /// <summary>
    /// Class that creatse objects of the plane type  
    /// </summary>
    public class Plane : IFlyable
    {
        private const double Speed = 200; // Initial speed of plane (km/h)
        private const double MaxFlightDistance = 1500; // Travel speed of plane (km)
        private const long MaxHeight = 15; // Maximum flight height of plane (km)        
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
            Console.WriteLine($"X: {CurrentPosition.X}; Y: {CurrentPosition.Y}; Z: {CurrentPosition.Z}");
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
            coordinate = CurrentPosition;

            FlyTo();

            // calculate flight distance
            time = Math.Sqrt(Math.Pow(Convert.ToDouble(CurrentPosition.X - coordinate.X), 2) +
                Math.Pow(Convert.ToDouble(CurrentPosition.Y - coordinate.Y), 2) +
                Math.Pow(Convert.ToDouble(CurrentPosition.Z - coordinate.Z), 2));

            //calculate flight time
            for (int n = 0; n < (Convert.ToInt32(time) / 10) - 1; n++)
            {
                time = time + (10 / (Speed + (n * 10))); // speed increase on 10 km/h every 10 km
            }
            return time;
        }

        /// <summary>
        /// Method defines some limitations for bird type objects 
        /// </summary>
        ///<param name = "x" > Get new X coordinate</param>
        ///<param name = "y" > Get new Y coordinate</param>
        /// <param name = "z" > Get new Z coordinate</param>
        void Limitations(uint x, uint y, uint z)
        {
            if (z > MaxHeight)  
            {
                //plane can't fly above 10 km
                Console.WriteLine("Too high.");
                FlyTo();
            }
            else if (Math.Sqrt(
                Math.Pow(
                    (Convert.ToDouble(CurrentPosition.X) - x), 2)
                + Math.Pow(
                    (Convert.ToDouble(CurrentPosition.Y) - y), 2)
                + Math.Pow(
                    (Convert.ToDouble(CurrentPosition.Z) - z), 2)) > MaxFlightDistance)            
            {
                // Plane can't fly more than 1500 km
                Console.WriteLine("Too long distance, not enogh fuel.");

                FlyTo();
            }
            else
            {
                // Set new coordinate
                CurrentPosition = new Coordinate(x, y, z);
            }
        }
    }
}
