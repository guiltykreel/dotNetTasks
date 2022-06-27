using System;

namespace CalculationDifferentSymbols
{
    public class Program
    {
        /// <summary>
        /// Count the maximum number of different symbols in string
        /// </summary>
        public static void Main(string[] args)
        {
            string fromThisString;
            int numberOfDifferentSymbols = 1;
            int temporaryNumberDifferentSymbols = 0;

            Console.WriteLine("Input the string:");
            fromThisString = Console.ReadLine();

            for (int i = 1; i < fromThisString.Length; i++)
            {
                //for whole string
                if (fromThisString[i - 1] != fromThisString[i])
                {
                    //If previous symbol differ from next 
                    numberOfDifferentSymbols++;
                }
                else
                {
                    if (temporaryNumberDifferentSymbols < numberOfDifferentSymbols)
                    {
                        // if next sequens of differ symbols more long than previous
                        temporaryNumberDifferentSymbols = numberOfDifferentSymbols;
                        numberOfDifferentSymbols = 0;
                    }
                    //else do nothing                    
                }
            }

            if (temporaryNumberDifferentSymbols > numberOfDifferentSymbols)
            {
                // if previous sequens of differ symbols more long than next
                Console.WriteLine($"Maximum nuber of different symbols is {temporaryNumberDifferentSymbols}");
            }
            else
            {
                Console.WriteLine($"Maximum nuber of different symbols is {numberOfDifferentSymbols}");
            }
        }
    }
}