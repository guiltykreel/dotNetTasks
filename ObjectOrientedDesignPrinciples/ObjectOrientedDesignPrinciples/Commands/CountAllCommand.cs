namespace ObjectOrientedDesignPrinciples.Commands
{
    internal class CountAllCommand : ICommand
    {
        public int Count { get; set; }

        public CountAllCommand(Garage garage)
        {
            var automobilesCount = from automobiles in garage.Automobiles
                                   select automobiles.Amount;
            foreach (var count in automobilesCount)
            {
                Count += count;
            }
        }
        public void Execute()
        {
            Console.WriteLine($"Automobiles amount in garage: {Count}");
        }
    }
}
