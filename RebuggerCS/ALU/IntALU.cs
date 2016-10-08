﻿using System;

namespace RebuggerCS
{
	public class IntALU : IALU
{
		RegisterFile special = SpecialRegisterFile.Instance;
		public void Add(RegisterFile file, int rd, int rs, int rt) {
			file.SetInt(rd,file.GetInt(rs)+file.GetInt(rt));	
		}

		public void Addu(RegisterFile file, int rd, int rs, int rt){
			file.SetUInt(rd, file.GetUInt(rs) + file.GetUInt(rt));
		}

		public void Addi(RegisterFile file, int rt, int rs, int immediate) {
			file.SetInt(rt, (file.GetInt(rs) + immediate));
		}
			
		public void Addiu(RegisterFile file, int rt, int rs, uint immediate) {
			file.SetUInt(rt, file.GetUInt(rs) + immediate);
		}

		public void Mult(RegisterFile file, int rt, int rs) {
			int t = file.GetInt(rt);
			int s = file.GetInt(rs);
			int lo = ((t * s) << 32) >> 32;
			int hi = (s * t) >> 32;
			special.SetInt(1, lo);
			special.SetInt(2, hi);
		}
		
		public void Multu(RegisterFile file, int rt, int rs) {
			uint t = file.GetUInt(rt);
			uint s = file.GetUInt(rs);
			uint lo = ((t * s) << 32) >> 32;
			uint hi = (s * t) >> 32;
			special.SetUInt(2, lo);
			special.SetUInt(3, hi);

		}

		public void Div(RegisterFile file, int rt, int rs) {
			int t = file.GetInt(rt);
			int s = file.GetInt(rs);
			int lo = s / t;
			int hi = s % t;
			special.SetInt(2, lo);
			special.SetInt(3, hi);
		}

		
		public void Divu(RegisterFile file, int rt, int rs) {
			int t = file.GetInt(rt);
			int s = file.GetInt(rs);
			int lo = s / t;
			int hi = s % t;
			special.SetInt(2, lo);
			special.SetInt(3, hi);
		}

		
		public void Sub(RegisterFile file, int rd, int rs, int rt) {
			file.SetInt(rd, file.GetInt(rs) - file.GetInt(rt));

		}

		
		public void Subu(RegisterFile file, int rd, int rs, int rt) {
			file.SetUInt(rd, file.GetUInt(rs) - file.GetUInt(rt));

		}

		
		public void And(RegisterFile file, int rd, int rt, int rs) {
			file.SetUInt(rd, file.GetUInt(rs) & file.GetUInt(rt));

		}

		
		public void Andi(RegisterFile file, int rt, int rs, uint immediate) {
			file.SetUInt(rt, file.GetUInt(rs) & immediate);

		}

		
		public void Nor(RegisterFile file, int rd, int rt, int rs) {
			file.SetUInt(rd, ~(file.GetUInt(rt) | file.GetUInt(rs)));

		}

		
		public void Or(RegisterFile file, int rd, int rt, int rs) {
			file.SetUInt(rd, file.GetUInt(rt) | file.GetUInt(rs));

		}

		
		public void Ori(RegisterFile file, int rt, int rs, int immediate) {
			file.SetInt(rt, (file.GetInt(rt) | immediate));

		}

		public void Xor(RegisterFile file, int rd, int rt, int rs) {
			file.SetUInt(rd, (file.GetUInt(rt) ^ file.GetUInt(rs)));
		}

		public void Xori(RegisterFile file, int rt, int rs, int immediate) {
			file.SetInt(rt, file.GetInt(rs)^immediate);
		}
		
		public void Slt(RegisterFile file, int rd, int rs, int rt) {
			if (file.GetInt(rs) < file.GetInt(rt))
				file.SetInt(rd, 1);
			else
				file.SetInt(rd, 0);

		}

		
		public void Slti(RegisterFile file, int rt, int rs, int immediate) {
			if (file.GetInt(rs) < immediate)
				file.SetInt(rt, 1);
			else
				file.SetInt(rt, 0);
		}

		
		public void Sltiu(RegisterFile file, int rt, int rs, uint immediate) {
			if (file.GetUInt(rs) < immediate)
				file.SetInt(rt, 1);
			else
				file.SetInt(rt, 0);
		}

		
		public void Sltu(RegisterFile file, int rd, int rs, int rt) {
			if (file.GetInt(rs) < file.GetInt(rt))
				file.SetInt(rd, 1);
			else
				file.SetInt(rd, 0);
		}

		
		public void Beq(RegisterFile file, int rs, int rt, int addr) {
			if (file.GetInt(rs) == file.GetInt(rt))
				special.SetInt(0, addr);

		}

		
		public void Bne(RegisterFile file, int rs, int rt, int addr) {
			if (file.GetInt(rs) != file.GetInt(rt))
				special.SetInt(0, addr);

		}

		
		public void J(int addr) {
			special.SetInt(0,addr);
		}

		
		public void Jal(RegisterFile file, int addr) {
			// TODO Auto-generated method stub

		}

		
		public void Jr(RegisterFile file, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void Lbu(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Lhu(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Ll(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Lb(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Lh(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Lui(RegisterFile file, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void Lw(RegisterFile file, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Sb(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Sh(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Sw(RegisterFile file, StackFile stack, int rt, int rs, int offset) {
			// TODO Auto-generated method stub

		}

		
		public void Mfhi(RegisterFile file, int rd) {
			// TODO Auto-generated method stub

		}

		
		public void Mflo(RegisterFile file, int rd) {
			// TODO Auto-generated method stub

		}

		
		public void Sll(RegisterFile file, int rd, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void Srl(RegisterFile file, int rd, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void Sra(RegisterFile file, int rd, int rt, int immediate) {
			// TODO Auto-generated method stub

		}

		
		public void Sllv(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void Srlv(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}

		
		public void Srav(RegisterFile file, int rd, int rt, int rs) {
			// TODO Auto-generated method stub

		}
	}
}

