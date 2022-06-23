using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutPark
{
    internal class ModelList
    {
       static XDocument CarModelList = XDocument.Load("D:/Projects/GIthub/dotNetTasks/AutPark/AutPark/CarModelList.xml");
        static XElement CarTitle = CarModelList.Element("CarModelList");
      
        public static List<string> GetModelList()
        {
            var CML = new List<string>();
            foreach (XElement Title in CarTitle.Elements("Model"))
            {
                XAttribute TitleAttribute = Title.Attribute("title");
                              
                CML.Add(TitleAttribute.Value.ToString());

                
            }
            return CML;
        }
    }    
}
