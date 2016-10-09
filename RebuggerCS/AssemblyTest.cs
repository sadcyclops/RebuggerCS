using System;
namespace RebuggerCS
{
	class AssemblyTest
	{
		static void Main()
		{
			Processor temp = new Processor();
			String[] sa = { "addi $t0 $t0 12", "addi $t1 $t1 15", "add $t2 $t1 $t0" };
			Int32[] sp = new Int32[0];
			temp.RecieveCode(sa, sp);
			temp.ProcessCode();
			temp.mapper.ExecuteInstruction(sa[0]);
			Console.Read();
		}

	}	
}
