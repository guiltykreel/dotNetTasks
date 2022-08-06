namespace ObjectOrientedDesignPrinciples.Commands
{
    /// <summary>
    /// Calculate automobile average price for specified type 
    /// </summary>
    internal class AveragePriceTypeCommand : ICommand
    {
        private string type;

        public double AveragePriceType { get; set; }

        public AveragePriceTypeCommand(Garage garage, string type)
        {
            this.type = type;

            // get every automobile with specified type
            var automobileType = from automobiles in garage.Automobiles
                                 where automobiles.Type == type
                                 select automobiles;

            foreach (var automobile in automobileType)
            {
                // calculate average price for every automobile type and sum it 
                AveragePriceType += automobile.Price / automobileType.Count();
            }
        }

        public void Execute()
        {
            Console.WriteLine($"Average price of {type} automobiles: {AveragePriceType}");
        }
    }
}
