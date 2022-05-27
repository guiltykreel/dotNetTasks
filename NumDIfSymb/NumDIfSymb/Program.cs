using System;

namespace NumDIfSymb
{
    class Program
    {
        /// <summary>
        /// Count the maximum number of different symbols in string
        /// </summary>
        static void Main(string[] args)
        {
            
            String FromThisString;
            int NumberOfDifferentSymbols = 1;
            int tmp = 0;
            Console.WriteLine("Input the string");
            FromThisString = Console.ReadLine();

            for (int i = 1; i < FromThisString.Length; i++)
            {
                //for whole string
                if (FromThisString[i-1] != FromThisString[i])
                {
                    //If previous symbol differ from next 
                    NumberOfDifferentSymbols++;
                    
                }
                else
                {
                    if (tmp<NumberOfDifferentSymbols)
                    {
                        // if next sequens of differ symbols more long than previous
                        tmp = NumberOfDifferentSymbols;
                        NumberOfDifferentSymbols = 0;
                    } 
                    //else do nothing
                    
                }
                
            }
            if (tmp > NumberOfDifferentSymbols)
            {
                // if previous sequens of differ symbols more long than next
                Console.WriteLine($"Maximum nuber of different symbols is {tmp}");
            }
            else
            {
                
                Console.WriteLine($"Maximum nuber of different symbols is {NumberOfDifferentSymbols}");
            } 

        }
    }
}
