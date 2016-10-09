using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class LbuCommand : ALUCommand
	{
		public LbuCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetByte(entries[0], 0, stack.peekByte(file.GetInt(entries[1]) + entries[2]));
			special.SetInt(0, special.GetInt(0) + 4);
		}

	}
}
