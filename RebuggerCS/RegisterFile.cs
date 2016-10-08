using System;
namespace RebuggerCSharp
{
	public class RegisterFile
	{
		public const uint BYTE = 255;
		public const uint WORD = 65535;

		public uint[] data;

		public RegisterFile()
		{
			this.data = new uint[30];
		}

		public byte GetByte(int register, int position)
		{
			if (position > 3) { /*throw new RegisterException(); */}
			return (byte)(this.data[register] >> (position << 3));
		}

		public ushort getWord(int register, int position)
		{
		if(position > 3){ /*throw new RegisterException(); */}
		return (ushort)(this.data[register] >> (position << 4));
		}

		public uint getInt(int register)
		{
			return this.data[register];
		}

		public void setByte(int register, int pos, uint value)
		{
			if(pos > 3){ /*throw new RegisterException(); */}
			uint target = this.data[register];
			target &= ~((BYTE << 8 * pos));
			target += (value << (8 * pos));
			this.data [register] = target;
		}

	public void setWord(int register, int pos, int value) throws RegisterException
	{
		if(pos > 2 || pos % 2 != 0){ throw new RegisterException(); }
		int target = this.data [register];
		target &= ~((WORD << pos*8));
		target += (value << (8 * pos));
		this.data [register] = target;
	}

	public void setInt(int register, int value)
	{
		this.data[register] = value;
	}
}
}
