using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SltiuCommand : ALUCommand
	{
		public SltiuCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			if (file.GetUInt(entries[1]) < entries[2])
				file.SetInt(entries[0], 1);
			else
				file.SetInt(entries[0], 0);
			special.SetInt(0, special.GetInt(0) + 1);
		}

	}
}