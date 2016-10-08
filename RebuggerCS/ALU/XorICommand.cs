using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class XorICommand : ALUCommand
	{
		public XorICommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		public void Execute(String line, List<Int32> entries)
		{
			file.SetInt(entries[0], file.GetInt(entries[1]) ^ entries[2]);

		}

	}
}
