namespace AsadaLisboaBackend.Services.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public InvalidRefreshTokenException() : base() { }
        public InvalidRefreshTokenException(string message) : base(message) { }
        public InvalidRefreshTokenException(string message, Exception inner) : base(message, inner) { }
    }
}
