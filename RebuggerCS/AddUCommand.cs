using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class AddUCommand : ALUCommand
	{
		public AddUCommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}
		//0:rd 1:rs 2:rt
		public void Execute(String line, List<Int32> entries)
		{
			file.SetInt(entries[0], entries[1] + entries[2]);
		}
	}
}
