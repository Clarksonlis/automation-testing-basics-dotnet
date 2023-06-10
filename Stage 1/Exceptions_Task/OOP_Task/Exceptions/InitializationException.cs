using System;
namespace OOP_Task.Exceptions
{
	public class InitializationException : Exception
	{
		public InitializationException()
		{

		}
        public InitializationException(string message) : base(message)
        {

        }
		public InitializationException(string message, Exception innerException) : base(message, innerException)
		{

		}
    }
}

