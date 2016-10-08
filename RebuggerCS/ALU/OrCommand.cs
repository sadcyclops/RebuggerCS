using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class OrCommand : ALUCommand
	{
		public OrCommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		public void Execute(String line, List<Int32> entries)
		{
			file.SetUInt(entries[0], file.GetUInt(entries[1]) | file.GetUInt(entries[2]));

		}

	}
}
