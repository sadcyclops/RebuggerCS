using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class LhCommand : ALUCommand
	{
		public LhCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			int value = stack.peekShort(file.GetInt(entries[1]) + entries[2]);
			file.SetWord(entries[0], 0, (uint)value);
			if ((value & 32768) == 65536)
				file.SetWord(entries[0], 1, 65535);
			else
				file.SetWord(entries[0], 1, 0);
			special.SetInt(0, special.GetInt(0) + 4);
		}

	}
}
