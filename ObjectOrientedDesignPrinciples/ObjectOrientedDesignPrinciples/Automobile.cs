namespace ObjectOrientedDesignPrinciples
{
    /// <summary>
    /// Automobiles for garage
    /// </summary>
    public class Automobile
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Automobile(string type, string model, int amount, double price)
        {
            Type = type;
            Model = model;
            Amount = amount;
            Price = price;
        }
    }
}
