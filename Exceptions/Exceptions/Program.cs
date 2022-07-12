using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    /// <summary>
    /// Crate exceptions
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Using exceptions
        /// </summary>
        static void Main()
        {
            Passenger passenger = new Passenger("BMW", "1996", 1, 2);
            Cargo cargo = new Cargo("MAN", "2011", 2, "TECO", false, 200);
            Bus bus = new Bus("MAZ", "1578", 3, true, 95, "Intercity");
            Scooter scooter = new Scooter("Minsk", "2037", 4, true, "Sport");

            var Garage = new List<Vehicle>();
            Garage.Add(passenger);
            Garage.Add(cargo);
            Garage.Add(bus);
            Garage.Add(scooter);

            // Exception Task
            //Trying add new Vehicle in list
            /*
             *ATTENTION!!!!!!!!!!!!!!!!!!!!!!!!!!
             *ADD EXCEPTION TO OTHER VEHICLES
             */            
            try
            {
                Passenger badPassenger = new Passenger("Tesa", "1996", 1, 2); 
                // "Tesa" is not "Tesla". BAD CASE
            }
            catch (Exceptions.AutoparkException e)
            {
                Console.WriteLine($"Error: {e.Message}, {e.Brand}");
            }

            Console.WriteLine("\n");
            // Trying add new vehicle brand in source file
            try
            {
                DataFile.AddBrandToData("Volvo!"); 
                //Check lenghth and special symols contains. BAD CASE
            }
            catch (Exceptions.AddBrandException e)
            {
                Console.WriteLine($"Error: {e.Message}, {e.Brand}");
            }
            finally
            {
                foreach (var brand in DataFile.GetModelList())
                {
                    Console.WriteLine(brand);
                }
            }

            Console.WriteLine("\n");
            // Tying find car in garage by field 
            try
            {
                GetAutoByParameter(Garage, "isRefregerator", "True"); //Good case, but bad value
                GetAutoByParameter(Garage, "something", "BMW"); //BAD CASE
            }
            catch (Exceptions.GetAutoByParameterException e)
            {
                Console.WriteLine($"Error: {e.Message}, {e.FieldName}");
            }

            Console.WriteLine("\n");
            //Trying update auto in Garage           
            Passenger newPassenger = new Passenger("Tesla", "2021", 5, 1);

            try
            {
                UpdateAuto(ref Garage, 1, newPassenger); // Good case
                UpdateAuto(ref Garage, 0, newPassenger); // BAD CASE
            }
            catch (Exceptions.UpdateAutoException e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Get fields and their value of the object that trying to find
        /// </summary>
        /// <param name="Garage">Collection for search</param>
        /// <param name="findField">Searched field</param>
        /// <param name="findValue">Searched value ()</param>
        /// <exception cref="Exceptions.GetAutoByParameterException"></exception>
        static void GetAutoByParameter(List<Vehicle> Garage, string findField, string findValue)
        {
            //Find car in garage by field
            var FindQuerry = from car in Garage
                             where (car.GetType().GetField(findField) != null) ||
                                   (car.Engine.GetType().GetField(findField) != null) ||
                                   (car.Transmission.GetType().GetField(findField) != null) ||
                                   (car.Chassis.GetType().GetField(findField) != null) ||
                                   ((car.GetType().GetProperty(findField.Replace(findField.First(), //asdqd
                                   char.ToUpper((findValue.First())))) != null))
                                   
                             select car;
            
            if (FindQuerry.Count() == 0)
            {
                //If noone object contains findField
                throw new Exceptions.GetAutoByParameterException("The parameter you are trying to find does not exist: ", findField, findValue);
            }
            else
            {
                Console.WriteLine(FindQuerry.Count());// this is exception case (if FindQuerry count = 0 )
                foreach (var car in FindQuerry) //Contain fields of searched object
                {
                    //Get each field and it's value in fields
                    foreach (var field in car.GetType().GetFields())
                    {
                        if (field.FieldType == typeof(Engine))
                        {
                            // if field type is Engine
                            Console.WriteLine(field.Name);
                            foreach (var specialField in field.FieldType.GetFields())// Get special field 
                            {
                                Console.WriteLine($"{specialField.Name} = {specialField.GetValue(car.Engine)}");
                                // write special field name and value
                            }
                        }
                        else if (field.FieldType == typeof(Chassis))
                        {
                            //if field type is Chassis
                            Console.WriteLine(field.Name);
                            foreach (var specialField in field.FieldType.GetFields())// Get special field 
                            {
                                Console.WriteLine($"{specialField.Name} = {specialField.GetValue(car.Chassis)}");
                                // write special field name and value
                            }
                        }
                        else if (field.FieldType == typeof(Transmission))
                        {
                            //if field type is Transmission
                            Console.WriteLine(field.Name);
                            foreach (var specialField in field.FieldType.GetFields())// Get special field 
                            {
                                Console.WriteLine($"{specialField.Name} = {specialField.GetValue(car.Transmission)}");
                                // write special field name and value
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{field.Name} = {field.GetValue(car)}"); //get field name and value  
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Replace auto in garage by id with new car 
        /// </summary>
        /// <param name="Garage">Collection</param>
        /// <param name="id">Replaced car id</param>
        /// <param name="NewCar">Auto which is replace with</param>
        static void UpdateAuto(ref List<Vehicle> Garage, int id, Vehicle NewCar)
        {
            var ReplaceCar = from car in Garage
                             where car.GetType().GetField("id").GetValue(car).ToString() == id.ToString()
                             select car;
            if (ReplaceCar.Count() == 0)
            {
                string error = $"Can't find car with id {id}";
                throw new Exceptions.UpdateAutoException(error, id);
            }
            else
            {
                foreach (var removedCar in ReplaceCar)
                {
                    Console.WriteLine($"Remove car with id: " +
                        $"{removedCar.GetType().GetField("id").GetValue(removedCar)}");
                }

                Garage.Remove(ReplaceCar.First()); //Remove found car
                Garage.Add(NewCar); // Add new car  

                Console.WriteLine("New car was added in Garage");
            }
                     
        }
    }
}
