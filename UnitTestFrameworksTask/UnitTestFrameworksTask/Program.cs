namespace UnitTestFrameworksTask;

public class Program
{
    /// <summary>
    /// Count number of different symbols or letters or numbers in line
    /// </summary>
    public static void Main()
    {
        string someString;

        Console.WriteLine("Input the string:");
        //someString = Console.ReadLine();    

        someString = "qwe123rr";
        Console.WriteLine(someString);

        Calculation calculation = new Calculation();

        Console.WriteLine($" Maximum number of consecutive different symbols is " +
            $"{calculation.CountMaximumDifferrentSymbols(someString)}");
        Console.WriteLine($"Maximum number of consecutive different letters is " +
            $"{calculation.CountMaximumDifferentLetter(someString)}");
        Console.WriteLine($"Maximum number of consecutive different numbers is " +
            $"{calculation.CountMaximumDifferentNumbers(someString)}");

        someString = "123qwe11";
        Console.WriteLine(someString);
        Console.WriteLine($" Maximum number of consecutive different symbols is " +
            $"{calculation.CountMaximumDifferrentSymbols(someString)}");
        Console.WriteLine($"Maximum number of consecutive different letters is " +
            $"{calculation.CountMaximumDifferentLetter(someString)}");
        Console.WriteLine($"Maximum number of consecutive different numbers is " +
            $"{calculation.CountMaximumDifferentNumbers(someString)}");
    }

    
}
