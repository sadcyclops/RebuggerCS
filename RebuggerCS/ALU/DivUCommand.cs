using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class DivUCommand : ALUCommand
	{
		public DivUCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			uint t = file.GetUInt(entries[0]);
			uint s = file.GetUInt(entries[1]);
			uint lo = s / t;
			uint hi = s % t;
			special.SetUInt(1, lo);
			special.SetUInt(2, hi);
			special.SetInt(0, special.GetInt(0) + 1); // Check this one
		}
	}
}
