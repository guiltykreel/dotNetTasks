using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    class Program
    {
        
        static void Main()
        {
            // Create bird
            Bird oriole = new Bird();
            Console.WriteLine("Oriole in point ");
            oriole.CurrentPoint(); // start position

            oriole.FlyTo();
            oriole.CurrentPoint(); // just flying

            Console.WriteLine($"Oriole fly to a new point in {oriole.GetFlyTime(oriole.CurrentPosition)} hours"); //lying with flight time calculate
            oriole.CurrentPoint();

            //Create plane
            Plane Airbus = new Plane();
            Console.WriteLine("Airbus in point ");
            Airbus.CurrentPoint();

            Airbus.FlyTo();
            Airbus.CurrentPoint();

            Console.WriteLine($"Airbus fly to a new point in {Airbus.GetFlyTime(Airbus.CurrentPosition)} hours"); //lying with flight time calculate
            Airbus.CurrentPoint();

            //Create drone

            Drone drone = new Drone();
            Console.WriteLine("Drone in point ");
            drone.CurrentPoint();

            //drone.FlyTo();
            //drone.CurrentPoint();

            Console.WriteLine($"Drone fly to a new point in {drone.GetFlyTime(drone.CurrentPosition)} hours"); //lying with flight time calculate
            drone.CurrentPoint();

        }
    }
}
