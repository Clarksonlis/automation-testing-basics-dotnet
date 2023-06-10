using System;
namespace OOP_Task.Exceptions
{
	public class UpdateAutoException : Exception
	{
		public UpdateAutoException()
		{
		}
        public UpdateAutoException(string message) : base(message)
        {
        }
        public UpdateAutoException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

