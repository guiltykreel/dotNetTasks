﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingFlying
{
    public struct Coordinate
    {
        public Coordinate(uint x, uint y, uint z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public uint X { get; set; }
            public uint Y { get; set; }
            public uint Z { get; set; }

        
    }
    
}
