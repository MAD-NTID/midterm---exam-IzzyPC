using System;

namespace Coinbase.Exceptions
{
    public class UserErrorException : Exception, IUserErrorException
    {
        private readonly int _code;
        private readonly string _message;

        public UserErrorException(string message, int code = 400):base(message)
        {
            _code = code;
            _message = message;
        }
        
        
        public int GetStatusCode()
        {
            return _code;
        }

        public string GetMessage()
        {
            return _message;
        }
    }
}