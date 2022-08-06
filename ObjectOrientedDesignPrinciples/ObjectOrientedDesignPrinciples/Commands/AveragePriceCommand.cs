namespace ObjectOrientedDesignPrinciples.Commands
{
    /// <summary>
    /// calculate average price of automobile in garage
    /// </summary>
    internal class AveragePriceCommand : ICommand
    {
        private double averagePrice;

        public AveragePriceCommand(Garage garage)
        {
            var allPrices = from automobiles in garage.Automobiles
                            select automobiles.Price;

            foreach (var prices in allPrices)
            {
                averagePrice += prices;
            }

            averagePrice = averagePrice / new CountAllCommand(garage).Count;
        }
        public void Execute()
        {
            Console.WriteLine($"Average price of automobiles in garage: {averagePrice}");
        }
    }
}
