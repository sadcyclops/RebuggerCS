using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class AddICommand : ALUCommand
	{
		public AddICommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}
		//0:rd 1:rs 2:rt
		override public void Execute(List<Int32> entries)
		{
			file.SetInt(entries[0], entries[1] + entries[2]);
		}
	}
}

