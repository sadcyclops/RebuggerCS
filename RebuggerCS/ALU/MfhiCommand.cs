using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class MfhiCommand : ALUCommand
	{
		public MfhiCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetInt(entries[0], special.GetInt(2));
		}

	}
}
