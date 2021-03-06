﻿using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SubUCommand : ALUCommand
	{
		public SubUCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetUInt(entries[0], file.GetUInt(entries[1]) - file.GetUInt(entries[2]));
			special.SetInt(0, special.GetInt(0) + 1);
		}
	}
}
