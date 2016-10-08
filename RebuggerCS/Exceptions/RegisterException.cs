using System;

namespace RebuggerCS
{
	public class RegisterException : Exception
	{
		public RegisterException () : base("An illegal register action occured") {}
	}
}

