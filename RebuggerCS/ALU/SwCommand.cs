﻿using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SwCommand : ALUCommand
	{
		public SwCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			stack.setInt(file.GetInt(entries[1]) + entries[2], file.GetUInt(entries[0]));
			special.SetInt(0, special.GetInt(0) + 1);
		}

	}
}
