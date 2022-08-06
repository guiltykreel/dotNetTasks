using ObjectOrientedDesignPrinciples.Commands;

namespace ObjectOrientedDesignPrinciples;
class Program
{
    static void Main()
    {
        string type;
        string model;
        string command = null;
        int automobileAmount;
        double modelPrice;
        Automobile newAutomobile;

        // create new automobiles and add it to list (singleton)
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Enter automobile type: ");
            type = Console.ReadLine();
            Console.WriteLine("Enter automobile model: ");
            model = Console.ReadLine();
            Console.WriteLine("Enter automobile amount: ");
            automobileAmount = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter model price: ");
            modelPrice = Convert.ToDouble(Console.ReadLine());

            newAutomobile = new Automobile(type, model, automobileAmount, modelPrice);

            Garage.GetInstance().AddToGarage(newAutomobile);
        }

        /*Automobile automobile = new Automobile("A","B",1,10);
        Automobile automobile2 = new Automobile("A2", "B", 3, 70);
        Automobile automobile3 = new Automobile("A3", "B", 5, 30);
        Automobile automobile4 = new Automobile("A2", "B2", 2, 20);
        Garage.GetInstance().AddToGarage(automobile);
        Garage.GetInstance().AddToGarage(automobile2);
        Garage.GetInstance().AddToGarage(automobile3);
        Garage.GetInstance().AddToGarage(automobile4);
        */

        Console.WriteLine("Please, input a command: ");

        while (command != "exit")
        {
            command = Console.ReadLine();
            if (command.Equals("count types"))
            {
                new CountTypesCommand(Garage.GetInstance()).Execute();
            }
            else if (command.Equals("count all"))
            {
                new CountAllCommand(Garage.GetInstance()).Execute();
            }
            else if (command.Equals("average price"))
            {
                new AveragePriceCommand(Garage.GetInstance()).Execute();
            }
            else if (command.StartsWith("average price "))
            {
                type = command.Substring(14).Trim();
                new AveragePriceTypeCommand(Garage.GetInstance(), type).Execute();
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }

        Environment.Exit(0);
    }
}

