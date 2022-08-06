namespace AutoPark.Exceptions
{
    public class RemoveAutoException : Exception
    {
        public int Id { get; }

        public RemoveAutoException(string message, int id): base(message)
        {
            Id = id;
        }
    }
}
