using System;

namespace CountSystem
{
    class Program
    {
        /// <summary>
        /// Conversion of integer numbers from decimal to another system of calculation (from 2 to 20)
        /// </summary>
        static void Main()
        {
            int decimalnumber; //Convertible number
            int basenumber; // Base of calculation system 

            Console.WriteLine("Enter a number in decimal count system: ");

            decimalnumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a base of count system: ");

            basenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Result = {ToAnotherCountSystem(decimalnumber, basenumber)}");
        }

        static string ToAnotherCountSystem(int convertibledecimalnumber, int countsystembase)
        {
            int temporarynumber = convertibledecimalnumber;
            string result = "";

            while (temporarynumber > 0) // Convert decimal number into b base calculate system
            {
                //reverse of the recording order 
                switch (temporarynumber % countsystembase) // if the reminder is 10 or more write symbols
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
                        result = result.Insert(0, Convert.ToString(temporarynumber % countsystembase));
                        break;
                }
                temporarynumber = temporarynumber / countsystembase;
            }
            return result;
        }
    }
}
