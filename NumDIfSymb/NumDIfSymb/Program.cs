using System;

namespace NumDIfSymb
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            String fromthisstring;
            int NumDifSymb = 1;
            int tmp = 0;
            
            fromthisstring = Console.ReadLine();

            for (int i = 1; i < fromthisstring.Length; i++)
            {
                if (fromthisstring[i-1] != fromthisstring[i])
                {
                    NumDifSymb++;
                    
                }
                else
                {
                    if (tmp<NumDifSymb)
                    {
                        tmp = NumDifSymb;
                        NumDifSymb = 0;
                    }
                    
                }
                
            }
            if (tmp > NumDifSymb)
            {
                Console.WriteLine(tmp);
            }
            else
            {
                Console.WriteLine(NumDifSymb);
            } 

        }
    }
}
