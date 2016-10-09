using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SltUCommand : ALUCommand
	{
		public SltUCommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		override public void Execute(List<Int32> entries)
		{
			if (file.GetInt(entries[1]) < file.GetInt(entries[2]))
				file.SetInt(entries[0], 1);
			else
				file.SetInt(entries[0], 0);
		}

	}
}