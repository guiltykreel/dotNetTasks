using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;

namespace AutoPark
{
    /// <summary>
    /// Create and describes Auto Park
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Get information about vechicle objects and create xml report
        /// </summary>
        static void Main()
        {
            //create vehicle objects

            var Garage = new List<Vehicle> 
            {
                new Passenger("BMW", "1996", 1, 2), 
                new Cargo("MAN", "2011", 2, "TECO", false, 200), 
                new Bus("MAZ", "1578", 3, true, 95, "Intercity"), 
                new Scooter("Minsk", "2037", 4, true, "Sport")  
            };

            // Create LINQ respond querry to describe vehicles with engine volume more 1.5 
            var ByEngineVolume = new XElement("Garage",
                from transport in Garage
                where transport.Engine.Volume > 1.5
                select new XElement("Vechicle",
                    new XElement("VechicleType", transport.GetType()),
                        new XElement("Engine",
                            new XElement("Volume", transport.Engine.Volume),
                            new XElement("Power", transport.Engine.Power),
                            new XElement("Type", transport.Engine.Type),
                            new XElement("SerialNumber", transport.Engine.SerialNumber)),
                        new XElement("Chassis",
                            new XElement("WheelAmount", transport.Chassis.WheelAmount),
                            new XElement("MaxStress", transport.Chassis.MaxStress),
                            new XElement("Number", transport.Chassis.Number)),
                        new XElement("Transmission",
                            new XElement("GearNum", transport.Transmission.GearNum),
                            new XElement("Manufacturer", transport.Transmission.Manufacturer),
                            new XElement("Type", transport.Transmission.Type))
                        )
                );

            //save result into xml file
            XDocument Report = new XDocument();
            Report.Add(ByEngineVolume);
            Report.Save("ByEngineVolume.xml");

            // create LINQ querry to describe engine of Cargo and Bus 
            var BusAndCargo = new XElement("Garage",
                from transport in Garage
                where transport.GetType() == typeof(Cargo) ^ transport.GetType() == typeof(Bus)
                select new XElement("Vechicle",
                    new XElement("VechicleType", transport.GetType()),
                        new XElement("EngineType", transport.Engine.Type),
                        new XElement("EngineSerialNumber", transport.Engine.SerialNumber),
                        new XElement("EnginePower", transport.Engine.Power))
                );

            // save result into xml file
            XDocument SecondReport = new XDocument();
            SecondReport.Add(BusAndCargo);
            SecondReport.Save("BusAndCargo.xml");

            //for grouping by transmission type, create querry to full information about vechicle 
            var FullData = new XElement("Garage",
                from transport in Garage
                select new XElement("Vechicle",
                    new XElement("VechicleType", transport.GetType()),
                        
                            new XElement("Volume", transport.Engine.Volume),
                            new XElement("Power", transport.Engine.Power),
                            new XElement("Type", transport.Engine.Type),
                            new XElement("SerialNumber", transport.Engine.SerialNumber),
                        
                            new XElement("WheelAmount", transport.Chassis.WheelAmount),
                            new XElement("MaxStress", transport.Chassis.MaxStress),
                            new XElement("Number", transport.Chassis.Number),
                        
                            new XElement("GearNum", transport.Transmission.GearNum),
                            new XElement("Manufacturer", transport.Transmission.Manufacturer),
                            new XElement("TransmissionType", transport.Transmission.Type))                                            
                );
                                           
            // grouping by transmission type
            var grouped = new XElement("Root",
                from transport in FullData.Elements("Vechicle")
                group transport by (string)transport.Element("TransmissionType") into Grouped
                select new XElement("Group",
                    new XAttribute("TransmissionType", Grouped.Key),
                    from vehicle in Grouped
                    select new XElement("Vechicle",
                    new XAttribute("Type", (string)vehicle.Element("VechicleType"))),                    
                    from transmission in Grouped
                    select new XElement("Transmission",
                    transmission.Element("GearNum"),
                    transmission.Element("Manufacturer")),
                    from engine in Grouped
                    select new XElement("Engine",
                        engine.Element("Type"),
                        engine.Element("Volume"),
                        engine.Element("Power"),
                        engine.Element("SerialNumber")),
                    from chassis in Grouped
                    select new XElement("Chassis",
                    chassis.Element("WheelAmount"),
                    chassis.Element("MaxStress"),
                    chassis.Element("Number"))
                    )
                );

            //save result into xml file
            XDocument ThirdReport = new XDocument();
            ThirdReport.Add(grouped);
            ThirdReport.Save("GroupByTransmission.xml");
            Console.WriteLine(grouped);            
        }
    }
}




