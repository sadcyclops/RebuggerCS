using System;
namespace RebuggerCS
{
	public class StandardRegisterFile : RegisterFile
	{
		public static RegisterFile Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new StandardRegisterFile();
				}
				return instance;
			}
		}

		private static RegisterFile instance;
		private StandardRegisterFile()
		{
			this.data = new uint[32];
		}
	}
}
