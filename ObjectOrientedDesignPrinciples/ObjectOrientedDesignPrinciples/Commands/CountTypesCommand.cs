namespace ObjectOrientedDesignPrinciples.Commands
{
    /// <summary>
    /// Count unique types of automobiles in garage
    /// </summary>
    internal class CountTypesCommand : ICommand
    {
        private int _typesCount;
        public CountTypesCommand(Garage garage)
        {
            var count = from auto in garage.Automobiles
                        select auto.Type;

            _typesCount = count.Distinct().Count();
        }
        public void Execute()
        {
            Console.WriteLine($"Different marks in garage: {_typesCount}");
        }
    }
}
