using System;
using System.Collections.Generic;

namespace RebuggerCS
{
	public class StackFile
	{
		const uint BYTE = 255;
		const uint WORD = 65535;

		private List<UInt32> stack;
		public List<UInt32> Stack { get {return stack;}}
		public int StackPointer { get { return stackPointer;} set { stackPointer = value;} }
		private int stackPointer;

		public StackFile() {
			this.stack = new List<UInt32> ();
			stackPointer = 64000;
		}

		public StackFile(List<UInt32> parStack) {
			this.stack = parStack;
			stackPointer = 0;
		}
			
		public void changeStackPointer(int difference) {
			if (difference < 0) {
				this.stackPointer += difference;
				while (difference < -4) {
					this.stack.Add(0);
					difference += 4;
				}
				if (difference < 0) {
					this.stack.Add (0);
				}
			} else {
				while (difference >= 4) {
					difference -= 4;
					this.stackPointer += 4;
					if(this.StackPointer >= 63997) {
						throw new StackException();
					}
					this.stack.RemoveAt(this.stack.Count - 1);
				}
				this.stackPointer -= difference;
			}
		}



		public byte peekByte(int offset) {
			int index = offset;
			int temp_index = (64000 - index)/4;
			if (index % 4 == 0)
				temp_index--;
			uint tarGet = this.stack[temp_index];
			return (byte) (tarGet >> (8 * (index % 4)));
		}

		public ushort peekShort(int offset)  {
			int index = offset;
			if (index % 2 != 0) {
				throw new StackException();
			}
			int adjustment = index % 4;
			index = 64000 - index;
			index /= 4;
			if (adjustment == 0) {
				index--;
			}
			uint tarGet = this.stack[index];
			return (ushort) (tarGet >> (16 * (index % 2)));
		}

		public uint peekInt(int offset) {
			int index = offset;
			if (index % 4 != 0) {
				throw new StackException();
			}
			index = 64000 - index;
			index /= 4;
			index--;
			return this.stack[index];
		}

		public void setByte(int offset, byte data) {
			int index = offset;
			int temp_index = (64000 - index)/4;
			if (index % 4 == 0)
				temp_index--;
			uint tarGet = this.stack[temp_index];
			tarGet &= ~((BYTE) << index % 4);
			tarGet += (uint) (data << (8 * (index % 4)));
			this.stack[temp_index] = tarGet;
		}

		public void setShort(int offset, ushort data) {
			int index = offset;
			if (index % 2 != 0) {
				throw new StackException();
			}
			int adjustment = index % 4;
			index = 64000 - index;
			index /= 4;
			if (adjustment == 0) {
				index--;
			}
			uint tarGet = this.stack[index];
			tarGet &= ~((WORD << (8*adjustment)));
			tarGet += (uint) (data << (8*adjustment));
			this.stack[index] = tarGet;
		}

		public void setInt(int offset, uint data) {
			if (offset % 4 != 0) {
				throw new StackException();
			}
			offset = 64000 - offset;
			offset /= 4;
			offset--;
			this.stack[offset] = data;
		}
	}

}

