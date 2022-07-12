using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Exceptions
{
    public class AutoparkException : ArgumentException
    {
        public string Brand { get; }

        public AutoparkException(string message, string brand)
            : base(message)
        {
            Brand = brand;
        }
    }   
}
