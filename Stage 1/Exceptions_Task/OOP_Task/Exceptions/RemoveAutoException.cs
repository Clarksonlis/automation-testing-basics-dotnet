﻿using System;
namespace OOP_Task.Exceptions
{
	public class RemoveAutoException : Exception
	{
        public RemoveAutoException()
        {
        }
        public RemoveAutoException(string message) : base(message)
        {
        }
        public RemoveAutoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

