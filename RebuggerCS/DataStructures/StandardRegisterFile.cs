using System;
namespace RebuggerCS
{
	public class StandardRegisterFile : RegisterFile
	{
		public StandardRegisterFile()
		{
			this.data = new uint[32];

		}
	}
}
