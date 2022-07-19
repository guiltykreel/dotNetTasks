using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Exceptions
{
    public class RemoveAutoException : Exception
    {
        public int Id { get; }

        public RemoveAutoException(string message, int id): base(message)
        {
            Id = id;
        }
    }
}
