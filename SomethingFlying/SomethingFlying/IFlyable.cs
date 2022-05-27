using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    /// <summary>
    /// Interface provides flying objects behaviour
    /// </summary>
    interface IFlyable 
    {
        /// <summary>
        /// show current position of flying object
        /// </summary>
        void GetCurrentPoint();

        /// <summary>
        /// change position of flying object without flight time calculation
        /// </summary>
        void FlyTo(); //TODO desigh the input check

        /// <summary>
        /// change position of flying object with flight time calculation
        /// </summary>
        /// <param name="coordinate"> Get current coordinates of object </param>
        /// <returns>  Return flying time from current position to new position </returns>
        double GetFlyTime(Coordinate coordinate); 
        
 
    }
}
