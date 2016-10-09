using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class DivCommand : ALUCommand
	{
		public DivCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			int t = file.GetInt(entries[0]);
			int s = file.GetInt(entries[1]);
			int lo = s / t;
			int hi = s % t;
			special.SetInt(2, lo);
			special.SetInt(3, hi);
		}
	}
}
