using System;
using System.Collections.Generic;

namespace RebuggerCS
{
	public class StackFile {
		const uint BYTE = 255;
		const uint WORD = 65535;

		private List<UInt32> stack;
		private int stackPointer;
		private static StackFile instance;

		public StackFile() {
			this.stack = new List<UInt32> ();
			this.stackPointer = 64000;
		}
			
		public void changeStackPointer(int difference) {
			if (difference < 0) {
				int someThing = stackPointer % 4;
				difference -= someThing;
				stackPointer += difference;
				while (difference >= 0) {
					this.stack.Add(0);
					difference -= 4;
				}
			} else {
				while (difference >= 4) {
					difference -= 4;
					stackPointer += 4;
					if(stackPointer >= 63997) {
						throw new StackException();
					}
					this.stack.RemoveAt(this.stack.Count);
				}
				stackPointer -= difference;
			}
		}

		public void pushByte(byte value) {
			this.stackPointer -= 1;
			if (stackPointer % 4 == 3) {
				this.stack.Add((uint) value);
			} else {
				uint end = this.stack[this.stack.Count];
				value <<= (((stackPointer + 2) % 4) << 3); // previously stackPointer + 2 % 4 
				end += value;
				this.stack[this.stack.Count] = end;
			}
		}

		public void pushShort(ushort value) {

			// Align
			if (this.stackPointer % 2 == 1) {
				this.stackPointer -= 1;
			}

			this.stackPointer -= 2;
			if (stackPointer % 4 == 2) {
				this.stack.Add((uint) value);
			} else {
				uint end = this.stack[this.stack.Count];
				end += ((uint) value << 16);
				this.stack [this.stack.Count] = end;
			}
		}

		public void pushInt(uint value) {

			// Align
			this.stackPointer -= this.stackPointer % 4;
			this.stackPointer -= 4;
			this.stack.Add(value);
		}

		public byte popByte() {
			byte value;
			this.stackPointer++;
			if (this.stackPointer % 4 == 0) {
				value = (byte) this.stack[this.stack.Count];
				this.stack.RemoveAt (this.stack.Count);
			} else {
				uint end = this.stack[this.stack.Count];
				end >>= ((this.stackPointer - 1) << 3);
				value = (byte) end;
				end &= ~((BYTE) << (this.stackPointer - 1) % 4);
				this.stack.Add (end);
			}
			return value;
		}

		public ushort popShort() {
			if (this.stackPointer % 2 != 0) {
				throw new StackException();
			}
			ushort value;
			this.stackPointer += 2;
			if (this.stackPointer % 4 == 0) {
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
			if (this.stackPointer % 4 != 0) {
				throw new StackException();
			}
			return this.stack[this.stack.Count];
		}

		public byte peekByte(int offset) {
			int index = (this.stackPointer + offset);
			index /= 4;
			uint tarGet = this.stack[index];
			return (byte) (tarGet >> (8 * (index % 4)));
		}

		public ushort peekShort(int offset)  {
			int index = (this.stackPointer + offset);
			if (index % 2 != 0) {
				throw new StackException();
			}
			index /= 4;
			uint tarGet = this.stack[index];
			return (ushort) (tarGet >> (16 * (index % 2)));
		}

		public uint peekInt(int offset) {
			int index = (this.stackPointer + offset);
			if (index % 4 != 0) {
				throw new StackException();
			}
			index /= 4;
			return this.stack[index];
		}

		public void setByte(int offset, byte data) {
			int index = (this.stackPointer + offset);
			int temp_index = index/4;
			uint tarGet = this.stack[temp_index];
			tarGet &= ~((BYTE) << index % 4);
			tarGet += (uint) (data << (8 * (index % 4)));
			this.stack[temp_index] = tarGet;
		}

		public void setShort(int offset, ushort data) {
			int index = (this.stackPointer + offset);
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
			int index = (this.stackPointer + offset);
			if (index % 4 != 0) {
				throw new StackException();
			}
			index /= 4;
			this.stack[index] = data;
		}
	}

}

