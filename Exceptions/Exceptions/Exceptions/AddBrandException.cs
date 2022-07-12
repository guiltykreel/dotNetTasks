using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Exceptions
{
    public class AddBrandException : Exception
    {
        public string Brand { get; }

        public AddBrandException(string message, string brand)
            : base(message)
        {
            Brand = brand;
        }

    }
}
