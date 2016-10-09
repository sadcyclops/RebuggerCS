using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class LhuCommand : ALUCommand
	{
		public LhuCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetWord(entries[0], 0, stack.peekShort(file.GetInt(entries[1]) + entries[2]));

		}

	}
}
