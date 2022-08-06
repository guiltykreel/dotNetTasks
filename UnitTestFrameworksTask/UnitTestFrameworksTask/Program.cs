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
        Console.WriteLine($" Maximum number of consecutive different symbols is " +
            $"{Calculation.GetInstance().CountMaximumDifferrentSymbols(someString)}");
        Console.WriteLine($"Maximum number of consecutive different letters is " +
            $"{Calculation.GetInstance().CountMaximumDifferentLetter(someString)}");
        Console.WriteLine($"Maximum number of consecutive different numbers is " +
            $"{Calculation.GetInstance().CountMaximumDifferentNumbers(someString)}");

        someString = "123qwe11";
        Console.WriteLine(someString);
        Console.WriteLine($" Maximum number of consecutive different symbols is " +
            $"{Calculation.GetInstance().CountMaximumDifferrentSymbols(someString)}");
        Console.WriteLine($"Maximum number of consecutive different letters is " +
            $"{Calculation.GetInstance().CountMaximumDifferentLetter(someString)}");
        Console.WriteLine($"Maximum number of consecutive different numbers is " +
            $"{Calculation.GetInstance().CountMaximumDifferentNumbers(someString)}");
    }

    
}
