namespace ObjectOrientedDesignPrinciples.Commands
{
    /// <summary>
    /// Count total number of autotmobiles in garage
    /// </summary>
    internal class CountAllCommand : ICommand
    {
        public int Count { get; set; }

        public CountAllCommand(Garage garage)
        {
            var automobilesAmount = from automobiles in garage.Automobiles
                                   select automobiles.Amount;

            foreach (var amountOfEveryAutomobileType in automobilesAmount)
            {
                Count += amountOfEveryAutomobileType;
            }
        }

        public void Execute()
        {
            Console.WriteLine($"Automobiles amount in garage: {Count}");
        }
    }
}
