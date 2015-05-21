using System;

namespace API.Exceptions
{
	public class ElementNotFoundException : Exception
	{
		private static string defaultMessage = "Element was not found.";

		public ElementNotFoundException(): base(defaultMessage)
		{
			// Does not do anything. Only sets default message.
		}

		public ElementNotFoundException(string customMessage) : base(customMessage)
		{
			// Only sets custom message.
		}
	}
}