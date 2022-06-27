using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    class Cargo : Vehicle
    {
        private static string CarType = "Cargo";
        
        public Cargo():base(CarType)
        {

        }
    }
}
