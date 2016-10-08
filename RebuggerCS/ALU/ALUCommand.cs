using System;
using System.Collections.Generic;



namespace RebuggerCS
{
	public abstract class ALUCommand
	{	
		protected RegisterFile file;
		protected RegisterFile special;
		abstract public void Execute(List<Int32> entries);
	}
}

