using System;

namespace RebuggerCS
{
	public class IllegalOpcodeException : Exception
	{
		public IllegalOpcodeException () : base ("An illegal opcode was encountered") {}
	}
}

