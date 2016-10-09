using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	class AssemblyTest
	{
		static void Main()
		{
			Processor temp = new Processor();
			List<String> sa = new List<String>();
			sa.Add("addi $t1 $t1 100 #do you still work");
			sa.Add("addi $t0 $t0 10");
			sa.Add("mult $t1 $t0");
			Int32[] sp = new Int32[0];
			temp.RecieveCode(sa.ToArray(), sp);
			temp.ProcessCode();
			temp.ExecuteCode();
			Console.Read();
		}
	}	
}
