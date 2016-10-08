using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SltCommand : ALUCommand
	{
		public SltCommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		public void Execute(String line, List<Int32> entries)
		{
			if (file.GetInt(entries[1]) < file.GetInt(entries[2]))
				file.SetInt(entries[0], 1);
			else
				file.SetInt(entries[0], 0);

		}

	}
}
