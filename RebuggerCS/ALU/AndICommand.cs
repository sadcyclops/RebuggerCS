﻿using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class AndICommand : ALUCommand
	{
		public AndICommand()
		{
			file = StandardRegisterFile.Instance;
			special = SpecialRegisterFile.Instance;
		}

		override public void Execute(List<Int32> entries)
		{
			file.SetInt(entries[0], file.GetInt(entries[2]) & entries[1]);

		}
	}
}
