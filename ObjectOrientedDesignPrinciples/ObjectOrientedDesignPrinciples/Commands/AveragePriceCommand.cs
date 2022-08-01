namespace ObjectOrientedDesignPrinciples.Commands
{
    internal class AveragePriceCommand : ICommand
    {
        private double averagePrice;

        public AveragePriceCommand(Garage garage)
        {
            var allPrices = from automobiles in garage.Automobiles
                            select automobiles.Price;
            foreach (var prices in allPrices)
            {
                averagePrice = averagePrice + prices;
            }

            averagePrice = averagePrice / new CountAllCommand(garage).Count;
        }
        public void Execute()
        {
            Console.WriteLine($"Average price of automobiles in garage: {averagePrice}");
        }
    }
}
