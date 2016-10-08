using System;
namespace RebuggerCS
{
	 public interface IALU
	{
		/*Arithmertic*/
		void Add(RegisterFile file, int rd, int rs, int rt);
		void Addi(RegisterFile file, int rt, int rs, int immediate);
		void Addiu(RegisterFile file, int rt, int rs, int immediate);
		void Addu(RegisterFile file, int rt, int rs, int immediate);
		void Mult(RegisterFile file, int rt, int rs);
		void Multu(RegisterFile file, int rt, int rs);
		void Div(RegisterFile file, int rt, int rs);
		void Divu(RegisterFile file, int rt, int rs);
		void Sub(RegisterFile file, int rd, int rs, int rt);
		void Subu(RegisterFile file, int rd, int rs, int rt);

		/*Logic*/
		void And(RegisterFile file, int rd, int rt, int rs);
		void Andi(RegisterFile file, int rt, int rs, int immediate);
		void nor(RegisterFile file, int rd, int rt, int rs);
		void Or(RegisterFile file, int rd, int rt, int rs);
		void Ori(RegisterFile file, int rt, int rs, int immediate);
		void Slt(RegisterFile file, int rd, int rs, int rt);
		void Slti(RegisterFile file, int rt, int rs, int immediate);
		void Sltiu(RegisterFile file, int rt, int rs, int immediate);
		void Sltu(RegisterFile file, int rd, int rs, int rt);

		/*Branching*/
		void Beq(RegisterFile file, int rs, int rt, int addr);
		void Bne(RegisterFile file, int rs, int rt, int addr);

		/*Unconditional Jumping*/
		void J(RegisterFile file, int addr);
		void Jal(RegisterFile file, int addr);
		void Jr(RegisterFile file, int rs);

		/*Data Transfer*/
		void Lbu(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Lhu(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Ll(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Lb(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Lh(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Lui(RegisterFile file, int rt, int immediate);
		void Lw(RegisterFile file, int rt, int rs, int offset);
		void Sb(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Sh(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Sw(RegisterFile file, StackFile stack, int rt, int rs, int offset);
		void Mfhi(RegisterFile file, int rd);
		void Mflo(RegisterFile file, int rd);

		/*Bitwise Shift*/
		void Sll(RegisterFile file, int rd, int rt, int immediate);
		void Srl(RegisterFile file, int rd, int rt, int immediate);
		void Sra(RegisterFile file, int rd, int rt, int immediate);
		void Sllv(RegisterFile file, int rd, int rt, int rs);
		void Srlv(RegisterFile file, int rd, int rt, int rs);
		void Srav(RegisterFile file, int rd, int rt, int rs);

	}
}
