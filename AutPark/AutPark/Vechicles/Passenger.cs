using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AutPark
{
    class Passenger : Vehicle
    {
        
        internal static  string CarType = "Passenger";
        string CarModel;
        public string CM
        {
            get { return CarModel; }
            set 
            {
                
                //InitializationExeption Model of initializated object is not contained in 
                //Model list (xml file)
                    if (ModelList.GetModelList().Contains(value))
                    {
                        CarModel = value;
                        
                    }
                    else 
                    {
                        throw new Exceptions.InitializationExeption("This model is out of list", value);
                    }               
                
            }
        }


        public Passenger(string Model) : base(CarType)
        {
            
            CM = Model;

        }
    }
}
