using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark.Exceptions
{
    class InitializationExeption:ArgumentException
    {
        public string m { get; }
        public InitializationExeption(string message,string model) 
            : base(message) 
        { 
        m = model;
        }
    
    }
}
