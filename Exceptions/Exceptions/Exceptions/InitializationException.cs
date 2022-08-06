namespace AutoPark.Exceptions
{
    public class AutoparkException : Exception
    {
        public string Brand { get; }

        public AutoparkException(string message, string brand) : base(message)
        {
            Brand = brand;
        }
    }
}
