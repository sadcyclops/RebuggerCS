using System;




namespace RebuggerCS
{
	public abstract class ALUCommand
	{
		public ALUCommand(RegisterFile parfile, )
		{
			RegisterFile file = parfile;
		}
		protected RegisterFile file;
		protected RegisterFile special;
		abstract public void Execute();
	}
}

