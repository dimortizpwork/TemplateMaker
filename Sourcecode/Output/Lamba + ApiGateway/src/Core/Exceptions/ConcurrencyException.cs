using System;

namespace InviteToKill.Exceptions
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException() : base()
        { }

        public ConcurrencyException(string message) : base(message)
        { }

        public ConcurrencyException(string message, Exception innerException): base(message, innerException)
        { }
    }
}
