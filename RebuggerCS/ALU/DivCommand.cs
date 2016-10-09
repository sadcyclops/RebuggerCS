using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class DivCommand : ALUCommand
	{
		public DivCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			int t = file.GetInt(entries[0]);
			int s = file.GetInt(entries[1]);
			int lo = s / t;
			int hi = s % t;
			special.SetInt(1, lo);
			special.SetInt(2, hi);
			special.SetInt(0, special.GetInt(0) + 1); // Check this one
		}
	}
}
