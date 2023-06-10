using System;
namespace OOP_Task.Exceptions
{
	public class AddException : Exception
	{
		public AddException()
		{
		}

		public AddException(string message) : base(message)
		{
				
		}

		public AddException(string message, Exception innerException) : base (message, innerException)
		{

		}
	}
}

