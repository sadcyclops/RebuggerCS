using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class JalCommand : ALUCommand
	{
		public JalCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetInt(31, special.GetInt(0) + 8);
			special.SetInt(0, entries[0]);

		}

	}
}
