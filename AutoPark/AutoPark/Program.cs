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
            //OOP Task
            // Create objects with "Passenger", "Cargo", "Bus", "Scooter" types
            Passenger passenger = new Passenger("BMW", "1996", 1, 2);
            Cargo cargo = new Cargo("MAN", "2011", 2, "TECO", false, 200);
            Bus bus = new Bus("MAZ", "1578", 3, true, 95, "Intercity");
            Scooter scooter = new Scooter("Minsk", "2037", 4, true, "Sport");

            // Write in console full description of every vehicle
            passenger.GetDescription();
            cargo.GetDescription();
            bus.GetDescription();
            scooter.GetDescription();

            // Collections Task
            // Create list of Vehicle objects
            var Garage = new List<Vehicle>();
            Garage.Add(passenger);
            Garage.Add(cargo);
            Garage.Add(bus);
            Garage.Add(scooter);
            
            // Create LINQ querry to describe vehicles with engine volume more 1.5 
            var ByEngineVolume = new XElement("Garage",
                from transport in Garage
                where transport.Engine.Volume > 1.5
                select new XElement("Vechicle",
                    new XElement("VechicleType", transport.GetType()),
                        
                        new XElement("Engine",
                            new XElement("Volume", transport.Engine.Volume),
                            new XElement("Power", transport.Engine.Power),
                            new XElement("Type", transport.Engine.Type),
                            new XElement("SerialNumber", transport.Engine.SerialNumber)), // end "engine"
                        
                        new XElement("Chassis",
                            new XElement("WheelAmount", transport.Chassis.WheelAmount),
                            new XElement("MaxStress", transport.Chassis.MaxStress),
                            new XElement("Number", transport.Chassis.Number)), // end "chassis"
                        
                        new XElement("Transmission",
                            new XElement("GearNum", transport.Transmission.GearNum),
                            new XElement("Manufacturer", transport.Transmission.Manufacturer),
                            new XElement("Type", transport.Transmission.Type)) // end "transmission"
                        )               
                );

            //save result into xml file
            XDocument Report = new XDocument();
            Report.Add(ByEngineVolume);
            Report.Save("CollectionsReport\\ByEngineVolume.xml");

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
            SecondReport.Save("CollectionsReport\\BusAndCargo.xml");

            //for grouping by transmission type, create querry to full information about vechicle 
            var fullData = new XElement("Garage",
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
                from transport in fullData.Elements("Vechicle")
                group transport by (string)transport.Element("TransmissionType") into Grouped
                select new XElement("Group",
                    new XAttribute("TransmissionType", Grouped.Key),
                    from vehicle in Grouped
                    select new XElement("Vechicle",
                    new XAttribute("Type", (string)vehicle.Element("VechicleType"))), 
                    
                    from transmission in Grouped
                    select new XElement("Transmission",
                    transmission.Element("GearNum"),
                    transmission.Element("Manufacturer")), // end "transmission"

                    from engine in Grouped
                    select new XElement("Engine",
                        engine.Element("Type"),
                        engine.Element("Volume"),
                        engine.Element("Power"),
                        engine.Element("SerialNumber")), // end "engine"

                    from chassis in Grouped
                    select new XElement("Chassis",
                        chassis.Element("WheelAmount"),
                        chassis.Element("MaxStress"),
                        chassis.Element("Number")) // end "chassis"
                    )
                );

            //save result into xml file 
            XDocument ThirdReport = new XDocument();
            ThirdReport.Add(grouped);
            ThirdReport.Save("CollectionsReport\\GroupByTransmission.xml");
            //Console.WriteLine(grouped);

            // All xml files save at at bin\Debug
            Console.ReadKey();
        }        
    }
}




