using System;
namespace RebuggerCS
{
	abstract public class RegisterFile
	{
		public const uint BYTE = 255;
		public const uint WORD = 65535;
		protected uint[] data;


		public byte GetByte(int register, int position)
		{
			if (position > 3) { throw new RegisterException(); }
			return (byte)(this.data[register] >> (position << 3));
		}

		public ushort GetWord(int register, int position)
		{
			if (position > 3) { throw new RegisterException(); }
			return (ushort)(this.data[register] >> (position << 4));
		}

		public uint GetUInt(int register)
		{
			return this.data[register];
		}

		public int GetInt(int register)
		{
			return (int) this.data[register];
		}

		public void SetByte(int register, int pos, uint value)
		{
			if (pos > 3) {throw new RegisterException();}
			uint target = this.data[register];
			target &= ~((BYTE << 8 * pos));
			target += (value << (8 * pos));
			this.data[register] = target;
		}

		public void SetWord(int register, int pos, uint value)
		{
			if(pos > 2 || pos % 2 != 0){throw new RegisterException();}
			uint target = this.data[register];
			target &= ~((WORD << pos*8));
			target += (value << (8 * pos));
			this.data[register] = target;
		}

		public void SetInt(int register, int value)
		{
			this.data[register] = (uint) value;
		}

		public void SetUInt(int register, uint value)
		{
			this.data[register] = value;
		}
	}
}
