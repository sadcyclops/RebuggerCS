using System;




namespace RebuggerCS
{
	public abstract class ALUCommand
	{	
		private RegisterFile standard;
		private RegisterFile special;
		void Execute();
	}
}

