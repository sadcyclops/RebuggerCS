using System;
namespace RebuggerCS
{
	public class SpecialRegisterFile : RegisterFile
	{

		public static RegisterFile Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SpecialRegisterFile();
				}
				return instance;
			}
		}
		private static RegisterFile instance;
		private SpecialRegisterFile()
		{
			this.data = new uint[3];
		}

	}
}
