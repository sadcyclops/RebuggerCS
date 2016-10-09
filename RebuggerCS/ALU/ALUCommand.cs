using System;
using System.Collections.Generic;



namespace RebuggerCS
{
	public abstract class ALUCommand
	{	
		protected StandardRegisterFile file;
		protected SpecialRegisterFile special;
		protected StackFile stack;
		public ALUCommand(StandardRegisterFile parFile, SpecialRegisterFile parSpecial, StackFile parStack)
		{
			file = parFile;
			stack = parStack;
			special = parSpecial;
		}
		abstract public void Execute(List<Int32> entries);
	}
}

