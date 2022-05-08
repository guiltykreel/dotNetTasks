using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * passenger car - лгковой
 * cargo - грузовой
 * Bus - автобус
 * scooter - скутер
 */
namespace AutPark
{
    public class Program
    {


        static void Main(string[] args)
        {
    //Создаем объекты класса Vehicle
            Vehicle PassengerCar = new Vehicle("passenger");
            Vehicle CargoCar = new Vehicle("cargo");
            Vehicle Bus = new Vehicle("bus");
            Vehicle Scooter = new Vehicle("scooter");

            PassengerCar.description();
            CargoCar.description();
            Bus.description();
            Scooter.description();
            
        }
    }
}




