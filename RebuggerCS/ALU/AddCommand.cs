using System;
using System.Collections.Generic;
namespace RebuggerCS
{
    public class AddCommand : ALUCommand
    {
		public ALUCommand() : base(file,  special,  stack);

		override public void Execute(List<Int32> entries)
		{ 
			file.SetInt(entries[0], entries[1] + entries[2]);
		}
    }
}