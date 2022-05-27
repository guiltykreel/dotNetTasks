using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    class Program
    {
        /// <summary>
        /// Create flying objects, change their position and calculate flying time to new
        /// position
        /// </summary>
        static void Main()
        {
            // Create bird
            Bird oriole = new Bird();
            Console.WriteLine("Oriole in point ");
            oriole.GetCurrentPoint(); // start position

            oriole.FlyTo();
            oriole.GetCurrentPoint(); // just flying

            Console.WriteLine($"Oriole fly to a new point in {oriole.GetFlyTime(oriole.CurrentPosition)} hours"); 
            //lying with flight time calculate
            oriole.GetCurrentPoint();

            //Create plane
            Plane Airbus = new Plane();
            Console.WriteLine("Airbus in point ");
            Airbus.GetCurrentPoint();

            Airbus.FlyTo();
            Airbus.GetCurrentPoint();

            Console.WriteLine($"Airbus fly to a new point in {Airbus.GetFlyTime(Airbus.CurrentPosition)} hours"); //lying with flight time calculate
            Airbus.GetCurrentPoint();

            //Create drone

            Drone drone = new Drone();
            Console.WriteLine("Drone in point ");
            drone.GetCurrentPoint();

            drone.FlyTo();
            drone.GetCurrentPoint();

            Console.WriteLine($"Drone fly to a new point in {drone.GetFlyTime(drone.CurrentPosition)} hours"); //lying with flight time calculate
            drone.GetCurrentPoint();

        }
    }
}
