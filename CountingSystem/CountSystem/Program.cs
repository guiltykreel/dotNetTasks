using System;

namespace CountSystem
{
    public class Program
    {
        /// <summary>
        /// Conversion of integer numbers from decimal to another system of calculation (from 2 to 20)
        /// </summary>
        private static void Main()
        {
            int decimalNumber; //Convertible number
            int baseNumber; // Base of calculation system 

            Console.WriteLine("Enter a number in decimal count system: ");

            decimalNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a base of count system (from 2 to 20): ");

            baseNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Result = {ToAnotherCountSystem(decimalNumber, baseNumber)}");
        }

        private static string ToAnotherCountSystem(int convertiBledecimalNumber, int countSystemBase)
        {
            int temporaryNumber = convertiBledecimalNumber;
            string result = "";

            while (temporaryNumber > 0) // Convert decimal number into b base calculate system
            {
                //reverse of the recording order 
                switch (temporaryNumber % countSystemBase) // if the reminder is 10 or more write symbols
                {
                    case 10:
                        result = result.Insert(0, "A");
                        break;
                    case 11:
                        result = result.Insert(0, "B");
                        break;
                    case 12:
                        result = result.Insert(0, "C");
                        break;
                    case 13:
                        result = result.Insert(0, "D");
                        break;
                    case 14:
                        result = result.Insert(0, "E");
                        break;
                    case 15:
                        result = result.Insert(0, "F");
                        break;
                    case 16:
                        result = result.Insert(0, "G");
                        break;
                    case 17:
                        result = result.Insert(0, "H");
                        break;
                    case 18:
                        result = result.Insert(0, "I");
                        break;
                    case 19:
                        result = result.Insert(0, "J");
                        break;
                    default:
                        result = result.Insert(0, Convert.ToString(temporaryNumber % countSystemBase));
                        break;
                }
                temporaryNumber = temporaryNumber / countSystemBase;
            }
            return result;
        }
    }
}
