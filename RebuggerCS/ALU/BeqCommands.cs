﻿using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class BeqCommand : ALUCommand
	{
		public BeqCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			if (file.GetInt(entries[0]) == file.GetInt(entries[1]))
				special.SetInt(0, entries[2]);

		}

	}
}
