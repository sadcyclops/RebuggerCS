using System;

namespace RebuggerCS
{
	public class IntALU : IALU
{
		public void add(RegisterFile file, int rd, int rs, int rt) {
			file.setInt(rd, file.getInt(rs)+file.getInt(rt));	
		}

		
		public void addi(RegisterFile file, int rt, int rs, int immediate) {
			file.setInt(rt, file.getInt(rs)+immediate);
		}
			
		public void addiu(RegisterFile file, int rt, int rs, int immediate) {
		}

		
		public void addu(RegisterFile file, int rt, int rs, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void mult(RegisterFile file, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void multu(RegisterFile file, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void div(RegisterFile file, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void divu(RegisterFile file, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void sub(RegisterFile file, int rd, int rs, int rt) {
			// TODO Auto-generated method stub

		}

		
		public void subu(RegisterFile file, int rd, int rs, int rt) {
			// TODO Auto-generated method stub

		}

		
		public void and(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void andi(RegisterFile file, int rt, int rs, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void nor(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void or(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void ori(RegisterFile file, int rt, int rs, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void slt(RegisterFile file, int rd, int rs, int rt) {
			// TODO Auto-generated method stub

		}

		
		public void slti(RegisterFile file, int rt, int rs, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void sltiu(RegisterFile file, int rt, int rs, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void sltu(RegisterFile file, int rd, int rs, int rt) {
			// TODO Auto-generated method stub

		}

		
		public void beq(RegisterFile file, int rs, int rt, int addr) {
			// TODO Auto-generated method stub

		}

		
		public void bne(RegisterFile file, int rs, int rt, int addr) {
			// TODO Auto-generated method stub

		}

		
		public void j(RegisterFile file, int addr) {
			// TODO Auto-generated method stub

		}

		
		public void jal(RegisterFile file, int addr) {
			// TODO Auto-generated method stub

		}

		
		public void jr(RegisterFile file, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void lbu(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void lhu(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void ll(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void lb(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void lh(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void lui(RegisterFile file, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void lw(RegisterFile file, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void sb(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void sh(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void sw(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void mfhi(RegisterFile file, int rd) {
			// TODO Auto-generated method stub

		}

		
		public void mflo(RegisterFile file, int rd) {
			// TODO Auto-generated method stub

		}

		
		public void sll(RegisterFile file, int rd, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void srl(RegisterFile file, int rd, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void sra(RegisterFile file, int rd, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void sllv(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void srlv(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void srav(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}
	}
}

