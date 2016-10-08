using System;




namespace RebuggerCS
{
	public abstract class ALUCommand
	{	
		protected RegisterFile file;
		protected RegisterFile special;
		abstract public void Execute();
	}
}

