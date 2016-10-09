using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class JrCommand : ALUCommand
	{
		public JrCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			special.SetInt(0, file.GetInt(entries[0]));

		}

	}
}
