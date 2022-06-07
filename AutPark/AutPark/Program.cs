using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * passenger car - лгковой
 * cargo - грузовой
 * Bus - автобус
 * scooter - скутер
 */
namespace AutPark
{
    /// <summary>
    /// Create and describes Auto Park
    /// </summary>
    public class Program
    {


        static void Main(string[] args)
        {
            //create vehicle objects

            var Garage = new List<Vehicle> {new Passenger(), new Cargo(), new Bus(), new Scooter()  };

            

            // Create LINQ respond querry to describe vehicles with engine volume more 1.5 
            var ByEngineVolume = new XElement("Garage",
                from Transport in Garage
                where Transport.Engine.Volume > 1.5
                select new XElement("Vechicle",
                    new XElement("VechicleType", Transport.GetType()),
                        new XElement("Engine",
                            new XElement("Volume", Transport.Engine.Volume),
                            new XElement("Power", Transport.Engine.Power),
                            new XElement("Type", Transport.Engine.Type),
                            new XElement("SerialNumber", Transport.Engine.SerialNumber)),
                        new XElement("Chassis",
                            new XElement("WheelAmount", Transport.Chassis.WheelAmount),
                            new XElement("MaxStress", Transport.Chassis.MaxStress),
                            new XElement("Number", Transport.Chassis.Number)),
                        new XElement("Transmission",
                            new XElement("GearNum", Transport.Transmission.GearNum),
                            new XElement("Manufacturer", Transport.Transmission.Manufacturer),
                            new XElement("Type", Transport.Transmission.Type)
                        )
                    )
                );

            //save result into xml file
            XDocument Report = new XDocument();
            Report.Add(ByEngineVolume);
            Report.Save("ByEngineVolume.xml");

            // create LINQ querry to describe engine of Cargo and Bus 
            var BusAndCargo = new XElement("Garage",
                from Transport in Garage
                where Transport.GetType() == typeof(Cargo) ^ Transport.GetType() == typeof(Bus)
                select new XElement("Vechicle",
                    new XElement("VechicleType", Transport.GetType()),
                        new XElement("EngineType", Transport.Engine.Type),
                        new XElement("EngineSerialNumber", Transport.Engine.SerialNumber),
                        new XElement("EnginePower", Transport.Engine.Power)
                  )
                );

            // save result into xml file
            XDocument SecondReport = new XDocument();
            SecondReport.Add(BusAndCargo);
            SecondReport.Save("BusAndCargo.xml");

            //for grouping by transmission type, create querry to full information about vechicle 
            var FullData = new XElement("Garage",
                from Transport in Garage
                select new XElement("Vechicle",
                    new XElement("VechicleType", Transport.GetType()),
                        
                            new XElement("Volume", Transport.Engine.Volume),
                            new XElement("Power", Transport.Engine.Power),
                            new XElement("Type", Transport.Engine.Type),
                            new XElement("SerialNumber", Transport.Engine.SerialNumber),
                        
                            new XElement("WheelAmount", Transport.Chassis.WheelAmount),
                            new XElement("MaxStress", Transport.Chassis.MaxStress),
                            new XElement("Number", Transport.Chassis.Number),
                        
                            new XElement("GearNum", Transport.Transmission.GearNum),
                            new XElement("Manufacturer", Transport.Transmission.Manufacturer),
                            new XElement("TransmissionType", Transport.Transmission.Type)
                        )
                    
                );
                                           
            // grouping by transmission type
            var grouped = new XElement("Root",
                from transport in FullData.Elements("Vechicle")
                group transport by (string)transport.Element("TransmissionType") into G
                select new XElement("Group",
                    new XAttribute("TransmissionType", G.Key),
                    from V in G
                    select new XElement("Vechicle",
                    new XAttribute("Type", (string)V.Element("VechicleType"))),
                    
                    from Tran in G
                    select new XElement("Transmission",
                    Tran.Element("GearNum"),
                    Tran.Element("Manufacturer")
                        ),
                    from eng in G
                    select new XElement("Engine",
                        eng.Element("Type"),
                        eng.Element("Volume"),
                        eng.Element("Power"),
                        eng.Element("SerialNumber")
                        ),
                    from chas in G
                    select new XElement("Chassis",
                    chas.Element("WheelAmount"),
                    chas.Element("MaxStress"),
                    chas.Element("Number")
                        )
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




