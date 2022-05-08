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
        private Engine Engine ;
        private Chassis Chassis;
        private Transmission Transmission;
        private string cartype;
        public Vehicle(string cartype) // Конструктор принимает "тип" ТС и создает объекты классов "Двигатель", "Шасси", "Трансмиссия"
        {
            Engine = new Engine(cartype);
            Chassis = new Chassis(cartype);
            Transmission = new Transmission(cartype);
            this.cartype = cartype;
        }


        public void description()
        {
            Console.WriteLine($"Car type: {cartype}");
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
        


        
    
