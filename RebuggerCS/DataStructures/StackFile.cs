using System;
using System.Collections.Generic;

namespace RebuggerCS
{
	public class StackFile {
		const int BYTE = 255;
		const int WORD = 65535;

		private List<Int32> stack;
		private int stackPointer;

		public StackFile() {
			this.stack = new List<Int32> ();
			this.stackPointer = 64000;
		}

		public void changeStackPointer(int difference) {
			if (difference < 0) {
				int someThing = stackPointer % 4;
				difference -= someThing;
				stackPointer -= difference;
				while (difference >= 0) {
					this.stack.Add(0);
					difference -= 4;
				}
			} else {
				while (difference >= 4) {
					difference -= 4;
					stackPointer += 4;
					this.stack.RemoveAt(this.stack.Count);
				}
				stackPointer -= difference;
			}
		}

		public void pushByte(byte value) {
			this.stackPointer -= 1;
			if (stackPointer % 4 == 3) {
				this.stack.Add((int) value);
			} else {
				int end = this.stack.RemoveAt(this.stack.Count);
				value <<= ((stackPointer + 2 % 4) << 3);
				end += value;
				this.stack.Add(end);
			}
		}

		public void pushShort(ushort value) {

			// Align
			if (this.stackPointer % 2 == 1)
				this.stackPointer -= 1;

			this.stackPointer -= 2;
			if (stackPointer % 4 == 2) {
				this.stack.Add((int) value);
			} else {
				int end = this.stack.RemoveAt(this.stack.Count);
				value <<= 16;
				end += value;
				this.stack.Add(end);
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
				value = (byte) this.stack.RemoveAt(this.stack.Count);
			} else {
				int end = this.stack.RemoveAt(this.stack.Count);
				this.stack.Add (end);
				end >>= ((this.stackPointer - 1) << 3);
				value = (byte) end;
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
				value = (ushort) this.stack.RemoveAt(this.stack.Count);
			} else {
				int end = this.stack.RemoveAt(this.stack.Count);
				this.stack.Add (end);
				end >>= (16);
				value = (ushort) end;
			}
			return value;
		}

		public int popInt() {
			if (this.stackPointer % 4 != 0) {
				throw new StackException();
			}
			return this.stack.RemoveAt(this.stack.Count);
		}

		public byte peekByte(int offset) {
			int index = (this.stackPointer + offset);
			index /= 4;
			int tarGet = this.stack.RemoveAt(index);
			this.stack.Insert (index, tarGet);
			return (byte) (tarGet >> (8 * (index % 4)));
		}

		public ushort peekShort(int offset)  {
			int index = (this.stackPointer + offset);
			if (index % 2 != 0) {
				throw new StackException();
			}
			index /= 4;
			int tarGet = this.stack.RemoveAt(index);
			this.stack.Insert (index, tarGet);
			return (ushort) (tarGet >> (16 * (index % 2)));
		}

		public uint peekInt(int offset) {
			int index = (this.stackPointer + offset);
			if (index % 4 != 0) {
				throw new StackException();
			}
			index /= 4;
			int tarGet = this.stack.RemoveAt(index);
			this.stack.Insert (index, tarGet);
			return tarGet;
		}

		public void setByte(int offset, byte data) {
			int index = (this.stackPointer + offset);
			int temp_index = index/4;
			int tarGet = this.stack.RemoveAt(temp_index);
			tarGet &= ~((BYTE) << index % 4);
			tarGet += (data << (8 * (index % 4)));
			this.stack.Insert(temp_index, tarGet);
		}

		public void setShort(int offset, ushort data) {
			int index = (this.stackPointer + offset);
			if (index % 2 != 0) {
				throw new StackException();
			}
			index /= 4;
			int tarGet = this.stack.RemoveAt(index);
			tarGet &= ~((WORD << (8*index)));
			tarGet += (data << (8*index));
			this.stack.Insert(index, tarGet);
		}

		public void setInt(int offset, uint data) {
			int index = (this.stackPointer + offset);
			if (index % 4 != 0) {
				throw new StackException();
			}
			index /= 4;
			this.stack.Insert(index, data);
		}
	}

}

