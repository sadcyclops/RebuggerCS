using System;

namespace RebuggerCS
{
	public class ParserException : Exception
	{
		public ParserException () : base ("There is an error in the syntax of your assembly code") {}
	}
}

