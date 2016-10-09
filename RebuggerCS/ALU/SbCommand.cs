using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SbCommand : ALUCommand
	{
		public SbCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			stack.setByte(file.GetInt(entries[1]) + entries[2], file.GetByte(entries[0], 0));
			special.SetInt(0, special.GetInt(0) + 1);
		}

	}
}
