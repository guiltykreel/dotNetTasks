using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoPark
{
    /// <summary>
    /// Base class for "Passenger", "Cargo", "Bus" and "Scooter" classes
    /// </summary>
    public class Vehicle
    {       
        public Engine Engine ;
        public Chassis Chassis;
        public Transmission Transmission;

        //Constructor get the type of vechicle and create Engine, Chasiis and Transmission objects
        public Vehicle(object CarType) 
        {
            Engine = new Engine(CarType);
            Chassis = new Chassis(CarType);
            Transmission = new Transmission(CarType);           
        }

        public void Description() //Write in console description of vechicle's parts
        {
            //Console.WriteLine($"Car type: {Car}");
            Console.WriteLine("");
            Engine.EngineDescription();
            Console.WriteLine("");
            Chassis.ChassisDescription();
            Console.WriteLine("");
            Transmission.TransmissionDescription();
            Console.WriteLine("///////////////////////////////////////////////////////////");
        }
    }   
}
        


        
    
