using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SbCommand : ALUCommand
	{
		public SbCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			stack.setByte(file.GetInt(entries[1]) + entries[2], file.GetBytee(entries[0], 0));
		}

	}
}
