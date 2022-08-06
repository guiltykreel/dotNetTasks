namespace AutoPark.Exceptions
{
    public class UpdateAutoException : ArgumentException
    {
        public int Id { get;}

        public UpdateAutoException(string message, int id) : base (message)
        {
            Id = id;
        }
    }
}
