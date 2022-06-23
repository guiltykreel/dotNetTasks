using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutPark
{
    public class Vehicle
    {
        // Поля класса Vehicle являются в свою очередь классами 
        public Engine Engine ;
        public Chassis Chassis;
        public Transmission Transmission;
        //private string cartype;
        public Vehicle(object CarType) // Конструктор принимает "тип" ТС и создает объекты классов "Двигатель", "Шасси", "Трансмиссия"
        {
            Engine = new Engine(CarType);
            Chassis = new Chassis(CarType);
            Transmission = new Transmission(CarType);
            
        }


        public void Description()
        {
            
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
        


        
    
