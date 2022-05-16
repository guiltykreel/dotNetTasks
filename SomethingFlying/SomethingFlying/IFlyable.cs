using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    /*
     * интерфейс отвечает за то, какие методы быудут у классов Bird, Plane, Drone 
     */
    interface IFlyable 
    {
        
        //void FlyTo(Coordinate coordinate);
        

        void CurrentPoint(); // show current position of flying object

        void FlyTo(); // change position of flying object without flight time calculation

        double GetFlyTime(Coordinate coordinate); // change position of flying object with flight time calculation


        //Limitations: max range, max height, 



    }
}
