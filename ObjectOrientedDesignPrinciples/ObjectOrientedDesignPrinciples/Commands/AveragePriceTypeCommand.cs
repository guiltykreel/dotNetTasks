namespace ObjectOrientedDesignPrinciples.Commands
{
    internal class AveragePriceTypeCommand : ICommand
    {
        private string type;

        public double AveragePriceType { get; set; }

        public AveragePriceTypeCommand(Garage garage, string type)
        {
            this.type = type;

            var automobileType = from automobiles in garage.Automobiles
                                 where automobiles.Type == type
                                 select automobiles;
            foreach (var automobile in automobileType)
            {
                AveragePriceType += automobile.Price / automobileType.Count();
            }
        }
        public void Execute()
        {
            Console.WriteLine($"Average price of {type} automobiles: {AveragePriceType}");
        }
    }
}
