using System;
using System.Collections.Generic;

namespace RebuggerCS
{
	public class StackFile
	{
		const uint BYTE = 255;
		const uint WORD = 65535;

		private List<UInt32> stack;
		private StandardRegisterFile sReg;

		private static StackFile instance;

		public StackFile(StandardRegisterFile file) {
			this.stack = new List<UInt32> ();
			this.sReg.AlterSP(64000);
		}
			
		public void changeStackPointer(int difference) {
			if (difference < 0) {
				int someThing = this.sReg.GetSP() % 4;
				difference -= someThing;
				this.sReg.AlterSP(difference);
				while (difference >= 0) {
					this.stack.Add(0);
					difference -= 4;
				}
			} else {
				while (difference >= 4) {
					difference -= 4;
					this.sReg.AlterSP(4);
					if(this.sReg.GetSP() >= 63997) {
						throw new StackException();
					}
					this.stack.RemoveAt(this.stack.Count);
				}
				this.sReg.AlterSP(-difference);
			}
		}

		public void pushByte(byte value) {
			this.sReg.AlterSP(-1);
			if (this.sReg.GetSP() % 4 == 3) {
				this.stack.Add((uint) value);
			} else {
				uint end = this.stack[this.stack.Count];
				value <<= (((this.sReg.GetSP()+2 % 4) << 3); // previously stackPointer + 2 % 4 
				end += value;
				this.stack[this.stack.Count] = end;
			}
		}

		public void pushShort(ushort value) {

			// Align
			if (this.sReg.GetSP() % 2 == 1) {
				this.sReg.AlterSP(-1);
			}
			this.sReg.AlterSP(-2);
			if (this.sReg.GetSP() % 4 == 2) {
				this.stack.Add((uint) value);
			} else {
				uint end = this.stack[this.stack.Count];
				end += ((uint) value << 16);
				this.stack [this.stack.Count] = end;
			}
		}

		public void pushInt(uint value) {

			// Align
			this.sReg.AlterSP(-(this.sReg.GetSP() % 4));
			this.sReg.AlterSP(-4);
			this.stack.Add(value);
		}

		public byte popByte() {
			byte value;
			this.sReg.AlterSP(1);
			if (this.sReg.GetSP() % 4 == 0) {
				value = (byte) this.stack[this.stack.Count];
				this.stack.RemoveAt (this.stack.Count);
			} else {
				uint end = this.stack[this.stack.Count];
				end >>= ((this.sReg.GetSP() - 1) << 3);
				value = (byte) end;
				end &= ~((BYTE) << (this.sReg.GetSP() - 1) % 4);
				this.stack.Add (end);
			}
			return value;
		}

		public ushort popShort() {
			if (this.sReg.GetSP() % 2 != 0) {
				throw new StackException();
			}
			ushort value;
			this.sReg.AlterSP(2);
			if (this.sReg.GetSP() % 4 == 0) {
				value = (ushort) this.stack[this.stack.Count];
			} else {
				uint end = this.stack[this.stack.Count];
				end >>= (16);
				value = (ushort) end;
				this.stack[this.stack.Count] &= ~((WORD << (16)));
			}
			return value;
		}

		public uint popInt() {
			if (this.sReg.GetSP() % 4 != 0) {
				throw new StackException();
			}
			return this.stack[this.stack.Count];
		}

		public byte peekByte(int offset) {
			int index = (this.sReg.GetSP() + offset);
			index /= 4;
			uint tarGet = this.stack[index];
			return (byte) (tarGet >> (8 * (index % 4)));
		}

		public ushort peekShort(int offset)  {
			int index = (this.sReg.GetSP() + offset);
			if (index % 2 != 0) {
				throw new StackException();
			}
			index /= 4;
			uint tarGet = this.stack[index];
			return (ushort) (tarGet >> (16 * (index % 2)));
		}

		public uint peekInt(int offset) {
			int index = (this.sReg.GetSP() + offset);
			if (index % 4 != 0) {
				throw new StackException();
			}
			index /= 4;
			return this.stack[index];
		}

		public void setByte(int offset, byte data) {
			int index = (this.sReg.GetSP() + offset);
			int temp_index = index/4;
			uint tarGet = this.stack[temp_index];
			tarGet &= ~((BYTE) << index % 4);
			tarGet += (uint) (data << (8 * (index % 4)));
			this.stack[temp_index] = tarGet;
		}

		public void setShort(int offset, ushort data) {
			int index = (this.sReg.GetSP() + offset);
			if (index % 2 != 0) {
				throw new StackException();
			}
			index /= 4;
			uint tarGet = this.stack[index];
			tarGet &= ~((WORD << (8*index)));
			tarGet += (uint) (data << (8*index));
			this.stack[index] = tarGet;
		}

		public void setInt(int offset, uint data) {
			int index = (this.sReg.GetSP() + offset);
			if (index % 4 != 0) {
				throw new StackException();
			}
			index /= 4;
			this.stack[index] = data;
		}
	}

}

