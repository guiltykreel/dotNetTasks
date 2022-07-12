using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;


namespace AutoPark
{
    /// <summary>
    /// Work with data file CarModelList.xml
    /// </summary>
    public class DataFile
    {
        private static XDocument xData = XDocument.Load("DataFiles\\CarModelList.xml");

        private static XDocument XData
        {
            get { return xData; }            
        }

        /// <summary>
        /// Return all models in list
        /// </summary>
        /// <returns>All models in list</returns>
        public static List<string> GetModelList()
        {           
            XElement CarTitle = XData.Element("CarModelList");
            var CarModelList = new List<string>();
            foreach (XElement Title in CarTitle.Elements("Model"))
            {
                XAttribute TitleAttribute = Title.Attribute("title");
                CarModelList.Add(TitleAttribute.Value.ToString());
            }
            return CarModelList;
        }

        /// <summary>
        /// Add new brand name in model list
        /// </summary>
        /// <param name="brand">name</param>
        /// <exception cref="Exceptions.AddBrandException">
        /// If brand name length less than 2 symbols or it contains special symbols
        /// </exception>
        public static void AddBrandToData(string brand)
        {

            if (brand.Length < 2 || brand.Length > 20)
            {
                throw new Exceptions.AddBrandException("Brand name is too short or too long", brand);
            }
            else if (SymbolCheck(brand))
            {
                throw new Exceptions.AddBrandException("Brand contains special symbols or numbers", brand);
            }
            else
            {
                XElement BrandTitle = XData.Element("CarModelList");
                BrandTitle.Add(new XElement("Model", new XAttribute("title", brand)));
            }                       
            //File changes are not saved
        }

        /// <summary>
        /// Ceck for special symbol contains for every symbol in brand string 
        /// </summary>
        /// <param name="checkedString">
        /// If brand contain special symbol (except white space and "-") is true
        /// is false if not
        /// </param>
        /// <returns>
        /// true for throw new exception
        /// </returns>
        private static bool SymbolCheck(string checkedString)
        {
            bool result = true;

            foreach  (char symbol in checkedString.Trim())
            {
                if (Char.IsLetter(symbol) || Char.IsWhiteSpace(symbol) || symbol == '-')
                {
                    result = false;
                }
                else 
                {
                    result = true;
                    break; 
                }
            }
            return result;
        }
    }
}
