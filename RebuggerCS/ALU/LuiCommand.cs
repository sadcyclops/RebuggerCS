using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class LuiCommand : ALUCommand
	{
		public LuiCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetInt(entries[0], entries[1] << 16);
			special.SetInt(0, special.GetInt(0) + 1);
		}

	}
}
