using System;

namespace SomethingFlying
{
    /// <summary>
    /// dotNetTasks
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Create flying objects, change their position and calculate flying time to new
        /// position
        /// </summary>
        public static void Main()
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
            Plane airbus = new Plane();
            Console.WriteLine("Airbus in point ");
            airbus.GetCurrentPoint();

            airbus.FlyTo();
            airbus.GetCurrentPoint();

            Console.WriteLine($"Airbus fly to a new point in {airbus.GetFlyTime(airbus.CurrentPosition)} hours"); //lying with flight time calculate
            airbus.GetCurrentPoint();

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
