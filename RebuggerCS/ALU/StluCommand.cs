using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SltuCommand : ALUCommand
	{
		public SltuCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			if (file.GetInt(entries[1]) < file.GetInt(entries[2]))
				file.SetInt(entries[0], 1);
			else
				file.SetInt(entries[0], 0);
			special.SetInt(0, special.GetInt(0) + 1);
		}

	}
}
