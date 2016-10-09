﻿using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class SllCommand : ALUCommand
	{
		public SllCommand(RegisterFile file, RegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			file.SetUInt(entries[0], file.GetUInt(entries[1]) << entries[2]);
		}

	}
}
