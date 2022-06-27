using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    class Passenger : Vehicle
    {
        static  string CarType = "Passenger";
        public Passenger() : base(CarType)
        {

        }
    }
}
