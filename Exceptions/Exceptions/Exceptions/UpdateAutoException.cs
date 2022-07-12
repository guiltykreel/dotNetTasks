using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Exceptions
{
    public class UpdateAutoException : ArgumentException
    {
        public int Id { get;}

        public UpdateAutoException(string message, int id)
        {
            Id = id;
        }
    }
}
