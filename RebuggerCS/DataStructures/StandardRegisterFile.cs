using System;
namespace RebuggerCS
{
	public class StandardRegisterFile : RegisterFile
	{
		public RegisterFile Instance
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

		private RegisterFile instance;
		private StandardRegisterFile()
		{
			this.data = new uint[32];
		}
	}
}
