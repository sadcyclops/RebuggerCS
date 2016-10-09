using System;
namespace RebuggerCS
{
	public class SpecialRegisterFile : RegisterFile
	{
		public SpecialRegisterFile()
		{
			this.data = new uint[3];
		}
	}
}
