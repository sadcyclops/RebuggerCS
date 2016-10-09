using System;
namespace RebuggerCS
{
	public class SpecialRegisterFile : RegisterFile
	{
		public SpecialRegisterFile(StackFile stack)
		{
			this.data = new int[3];
		}
	}
}
