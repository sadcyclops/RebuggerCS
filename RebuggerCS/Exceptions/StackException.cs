using System;

namespace RebuggerCS
{
	public class StackException : Exception
	{
		public StackException () : base("An illegal memory access occured") {}
	}
}

