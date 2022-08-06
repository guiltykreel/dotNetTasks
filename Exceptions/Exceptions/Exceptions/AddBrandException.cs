namespace AutoPark.Exceptions
{
    public class AddBrandException : Exception
    {
        public string Brand { get; }

        public AddBrandException(string message, string brand) : base(message)
        {
            Brand = brand;
        }
    }
}
