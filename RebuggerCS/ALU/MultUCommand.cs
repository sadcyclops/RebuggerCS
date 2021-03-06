﻿using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	public class MultUCommand : ALUCommand
	{
		public MultUCommand(StandardRegisterFile file, SpecialRegisterFile special, StackFile stack) : base(file, special, stack) { }

		override public void Execute(List<Int32> entries)
		{
			uint t = file.GetUInt(entries[0]);
			uint s = file.GetUInt(entries[1]);
			uint lo = ((t * s) << 32) >> 32;
			uint hi = (s * t) >> 32;
			special.SetUInt(2, lo);
			special.SetUInt(3, hi);
			special.SetInt(0, special.GetInt(0) + 1);
		}
	}
}
