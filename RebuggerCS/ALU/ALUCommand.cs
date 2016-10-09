using System;
using System.Collections.Generic;



namespace RebuggerCS
{
	public abstract class ALUCommand
	{	
		protected RegisterFile file;
		protected RegisterFile special;
		protected StackFile stack;
		public ALUCommand(RegisterFile parFile, RegisterFile parSpecial, StackFile parStack)
		{
			file = parFile;
			stack = parStack;
			special = parSpecial;
		}
		abstract public void Execute(List<Int32> entries);
	}
}

