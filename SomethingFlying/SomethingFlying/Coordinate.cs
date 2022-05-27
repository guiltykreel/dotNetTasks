using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    /// <summary>
    /// Coordinate structure set and get the position of flying object 
    /// </summary>
    public struct Coordinate
    {
        /// <summary>
        /// Create object with coordinate data type
        /// </summary>
        /// <param name="x"> Set X coordinate </param>
        /// <param name="y"> Set y coordinate </param>
        /// <param name="z"> Sez Z coordinate </param>
        public Coordinate(uint x, uint y, uint z)
            {
                X = x;
                Y = y;
                Z = z;
            }

        /// <summary>
        /// Set and get X coordinate
        /// </summary>
        public uint X { get; set; }

        /// <summary>
        /// Set and get Y coordinate
        /// </summary>    
        public uint Y { get; set; }

        /// <summary>
        /// Set and get Z coordinate
        /// </summary> 
        public uint Z { get; set; }

        
    }
    
}
