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

            int DecimalNumber; //Convertible number
            int BaseNumber; // Base of calculation system 

            Console.WriteLine("Enter a number in decimal count system: ");

            DecimalNumber = Convert.ToInt32 (Console.ReadLine());  
            Console.WriteLine("Enter a base of count system: ");

            BaseNumber  = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine($"Result = {ToAnotherCountSystem(DecimalNumber, BaseNumber)}");
        }

        public string ToAnotherCountSystem(int Decimalnumber, int CountSystemBase) 
        {
            
            int TemporaryNumber=Decimalnumber;
            string Result="";

           
            while (TemporaryNumber > 0) // Convert decimal number into b base calculate system
            {
                //reverse of the recording order 
                switch (TemporaryNumber % CountSystemBase) // if the reminder is 10 or more write symbols
                {
                    case 10:
                        Result = Result.Insert(0, "A");
                        break;
                    case 11:
                        Result = Result.Insert(0, "B");
                        break;
                    case 12:
                        Result = Result.Insert(0, "C");
                        break;
                    case 13:
                        Result = Result.Insert(0, "D");
                        break;
                    case 14:
                        Result = Result.Insert(0, "E");
                        break;
                    case 15:
                        Result = Result.Insert(0, "F");
                        break;
                    case 16:
                        Result = Result.Insert(0, "G");
                        break;
                    case 17:
                        Result = Result.Insert(0, "H");
                        break;
                    case 18:
                        Result = Result.Insert(0, "I");
                        break;
                    case 19:
                        Result = Result.Insert(0, "J");
                        break;
                    default:
                        Result = Result.Insert(0, Convert.ToString(TemporaryNumber % CountSystemBase));
                        break;
                }
                TemporaryNumber = TemporaryNumber / CountSystemBase;
            }
            return Result;

        }
        
    }
}
