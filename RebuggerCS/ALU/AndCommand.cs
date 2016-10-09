using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class AndCommand : ALUCommand
	{
		public AndCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetUInt(entries[0], file.GetUInt(entries[2]) & file.GetUInt(entries[1]));

		}
	}
}
