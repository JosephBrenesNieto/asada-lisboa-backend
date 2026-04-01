namespace AsadaLisboaBackend.Services.Exceptions
{
    public class ExistingValueException : Exception
    {
        public ExistingValueException() : base() { }
        public ExistingValueException(string message) : base(message) { }
        public ExistingValueException(string message, Exception inner) : base(message, inner) { }
    }
}
