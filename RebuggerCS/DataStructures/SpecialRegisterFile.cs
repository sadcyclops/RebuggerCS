using System;
namespace RebuggerCS
{
	public class SpecialRegisterFile : RegisterFile
	{

		public RegisterFile Instance
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
		private RegisterFile instance;
		private SpecialRegisterFile()
		{
			this.data = new uint[3];
		}

	}
}
