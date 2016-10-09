using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class ShCommand : ALUCommand
	{
		public ShCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			stack.setShort(file.GetInt(entries[1]) + entries[2], file.GetWord(entries[0], 0));
			special.SetInt(0, special.GetInt(0) + 1);
		}

	}
}
