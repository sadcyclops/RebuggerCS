using System;
namespace RebuggerCS
{
	public class StandardRegisterFile : RegisterFile
	{
		public StandardRegisterFile()
		{
			this.data = new int[32];

		}
		public void AlterSP(int x)
		{
			this.data[29] += x;
		}

		public int GetSP()
		{
			return this.data[29];
		}
	}
}
