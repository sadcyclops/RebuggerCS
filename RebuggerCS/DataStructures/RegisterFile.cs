using System;
namespace RebuggerCS
{
	abstract public class RegisterFile
	{
		public const uint BYTE = 255;
		public const uint WORD = 65535;
		protected int[] data;

		/*	All accesors forced to return 0 from register 0.
			No other restructions applied as is MIPS standard*/
		public byte GetByte(int register, int position)
		{
			if (position > 3) { throw new RegisterException(); }
			if (register == 0) { return (byte)0; }
			return (byte)(this.data[register] >> (position << 3));
		}

		public ushort GetWord(int register, int position)
		{
			if (position > 3) { throw new RegisterException(); }
			if (register == 0) { return (ushort)0; }
			return (ushort)(this.data[register] >> (position << 4));
		}

		public uint GetUInt(int register)
		{
			if (register == 0) { return (uint) 0; }
			return (uint) this.data[register];
		}

		public int GetInt(int register)
		{
			return (int) this.data[register];
		}

		public void SetByte(int register, int pos, uint value)
		{
			if (pos > 3) {throw new RegisterException();}
			int target = this.data[register];
			target &= (int) ~((BYTE << 8 * pos));
			target += (int)(value << (8 * pos));
			this.data[register] = target;
		}

		public void SetWord(int register, int pos, uint value)
		{
			if(pos > 2 || pos % 2 != 0){throw new RegisterException();}
			int target = this.data[register];
			target &= (int) ~((WORD << pos*8));
			target += (int) (value << (8 * pos));
			this.data[register] = target;
		}

		public void SetInt(int register, int value)
		{
			this.data[register] = value;
		}

		public void SetUInt(int register, uint value)
		{
			this.data[register] = (int) value;
		}
	}
}
