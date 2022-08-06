namespace AutoPark.Exceptions
{
    public class GetAutoByParameterException : ArgumentException
    {
        public string FieldName { get; }
        public string FieldValue { get; }

        public GetAutoByParameterException(string message, string fieldName, string fieldValue) : base (message)
        { 
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}
