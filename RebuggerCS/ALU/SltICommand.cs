using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SltICommand : ALUCommand
	{
		public SltICommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		override public void Execute(List<Int32> entries)
		{
			if (file.GetInt(entries[1]) < entries[2])
				file.SetInt(entries[0], 1);
			else
				file.SetInt(entries[0], 0);

		}

	}
}
