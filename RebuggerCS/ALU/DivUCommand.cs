using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class DivUCommand : ALUCommand
	{
		public DivUCommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		override public void Execute(List<Int32> entries)
		{
			uint t = file.GetUInt(entries[0]);
			uint s = file.GetUInt(entries[1]);
			uint lo = s / t;
			uint hi = s % t;
			special.SetUInt(2, lo);
			special.SetUInt(3, hi);
		}
	}
}
