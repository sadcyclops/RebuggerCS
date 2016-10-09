using System;
namespace RebuggerCS
{
	public class SpecialRegisterFile : RegisterFile
	{
		public SpecialRegisterFile()
		{
			this.data = new int[3];
		}

		public void AlterSP(int x)
		{
			this.data[0] += x;
		}

		public int GetSP()
		{
			return this.data[0];
		}
	}
}
