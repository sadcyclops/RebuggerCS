using System;
namespace RebuggerCS
{
	class AssemblyTest
	{
		static void Main()
		{
			Processor temp = new Processor();
			String[] sa = { "addi $t1 $t1 100000","addi $t0 $t0 1", "j 1"};
			Int32[] sp = new Int32[0];
			temp.RecieveCode(sa, sp);
			temp.ProcessCode();
			for (int i = 0; i < 1000001; i++)
				temp.mapper.ExecuteInstruction(sa[temp.SRegisters.GetInt(0)]);
			Console.Read();
		}

	}	
}
