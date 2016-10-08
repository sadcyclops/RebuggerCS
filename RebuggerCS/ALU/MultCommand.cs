using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class MultCommand : ALUCommand
	{
		public MultCommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}
		public void Mult(String line, List<Int32> entries)
		{
			int t = file.GetInt(entries[0]);
			int s = file.GetInt(entries[1]);
			int lo = ((t * s) << 32) >> 32;
			int hi = (s * t) >> 32;
			special.SetInt(1, lo);
			special.SetInt(2, hi);
		}
	}
}
