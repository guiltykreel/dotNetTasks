using System;

namespace countsystem
{
    class Program
    {
       
        static void Main()
        {
           int decnum;
            int basenum;
            string decn;
            

           

            Console.WriteLine("Enter a number in decimal count system: ");
            decn = Console.ReadLine();
            decnum = Convert.ToInt32 (decn);  
            Console.WriteLine("Enter a base of count system: ");
            decn = Console.ReadLine();
            basenum  = Convert.ToInt32(decn);  
            Toanothercountsystem(decnum, basenum);
            
        }

        static void Toanothercountsystem(int d, int b) 
        {
            int i = 1;
            int tmp=1;
            string res="";
            
            
            while ( tmp >= 1) { //вычисляем количество знаков в числе
                tmp = d;
                tmp = tmp / Convert.ToInt32((Math.Pow(10,i)));

                i++;
                
            }
            i=i-2;
            
           // Console.WriteLine($"d = {d}");
           // Console.WriteLine($"i = {i}");
            tmp = d;
            while (tmp > 0) // переводим в b систему исчисления
            {
                switch (tmp % b)
                {
                    case 10:
                        res = res.Insert(0, "A");
                        break;
                    case 11:
                        res = res.Insert(0, "B");
                        break;
                    case 12:
                        res = res.Insert(0, "C");
                        break;
                    case 13:
                        res = res.Insert(0, "D");
                        break;
                    case 14:
                        res = res.Insert(0, "E");
                        break;
                    case 15:
                        res = res.Insert(0, "F");
                        break;
                    case 16:
                        res = res.Insert(0, "G");
                        break;
                    case 17:
                        res = res.Insert(0, "H");
                        break;
                    case 18:
                        res = res.Insert(0, "I");
                        break;
                    case 19:
                        res = res.Insert(0, "J");
                        break;
                    default:
                        res = res.Insert(0, Convert.ToString(tmp % b));
                        break;
            }
                tmp = tmp/ b;
                Console.WriteLine($"res = {res}");
            }
            

        }
    }
}
