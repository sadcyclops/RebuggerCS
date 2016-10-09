using System;
namespace RebuggerCS
{
	public class SpecialRegisterFile : RegisterFile
	{
		public SpecialRegisterFile()
		{
			this.data = new int[3];
		}
	}
}
