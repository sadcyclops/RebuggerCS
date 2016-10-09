using System;
using System.Collections.Generic;
namespace RebuggerCS
{
	static class Program

	{
		static int Main(string[] args)
		{
			Processor temp = new Processor();
			List<String> sa = new List<String>();
			sa.Add("addi $t1 $t1 100 #do you still work");
			sa.Add("addi $t0 $t0 10");
			sa.Add("mult $t1 $t0");
			sa.Add("addi $sp $sp -16");
			sa.Add ("addi $sp $sp 8");
			Console.WriteLine ("I run");
			Int32[] sp = new Int32[0];
			temp.RecieveCode(sa.ToArray(), sp);
			temp.ProcessCode();
			temp.ExecuteCode();
			temp.ExecuteCode ();
			temp.ExecuteCode ();
			temp.ExecuteCode ();
			temp.ExecuteCode ();
			Console.Read();
			return 0;
		}
	}	
}
