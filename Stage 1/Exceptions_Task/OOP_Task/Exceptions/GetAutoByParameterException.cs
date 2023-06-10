using System;
namespace OOP_Task.Exceptions
{
	public class GetAutoByParameterException : Exception
	{
        public GetAutoByParameterException()
        {
        }
        public GetAutoByParameterException(string message) : base(message)
        {
        }
        public GetAutoByParameterException(string message, Exception innerException) : base (message, innerException)
        {
        }
    }
}

