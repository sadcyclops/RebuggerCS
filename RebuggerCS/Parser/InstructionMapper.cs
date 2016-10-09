using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RebuggerCS
{
	public class InstructionMapper
	{
        private Dictionary<String, Int32> labels;
		private Dictionary<String, Object> RO_Data;

		private Dictionary<String, ALUCommand> Rcommands = new Dictionary<String, ALUCommand> ();
		private Dictionary<String, ALUCommand> Jcommands = new Dictionary<String, ALUCommand> ();
		private Dictionary<String, ALUCommand> Icommands = new Dictionary<String, ALUCommand> ();

		private StandardRegisterFile file;
		private SpecialRegisterFile special;
		private StackFile stack;

		public InstructionMapper(Dictionary<String, Int32> label, Dictionary<String, Object> ROData, StandardRegisterFile parFile, SpecialRegisterFile parSpecial, StackFile parStack)  {
            this.labels = label;
            this.RO_Data = ROData;
			file = parFile;
			special = parSpecial;
			stack = parStack;
			SetCommands();
        }

        public void ExecuteInstruction(String unsplitLine) {
			List<String> line = new List<String>(unsplitLine.Split(' '));
            if (line.Count == 0) return;

            //Get the instruction from the line object
            String instruction = line[0];
			line.RemoveAt(0);

            int offset = -1;
            List<int> arguments = new List<int>();
            while (line.Count > 0)  {
                arguments.Add(ParseArgument(line[0], ref offset));
				line.RemoveAt(0);
                if (line.Count == 0 && offset > -1)
                    arguments.Add(offset);
                else if (line.Count > 0 && offset > -1)
                    throw new ParserException();
            }

			if (Rcommands.ContainsKey (instruction)) {
				this.Rcommands [instruction].Execute (arguments);
			} else if (Icommands.ContainsKey (instruction)) {
				this.Icommands [instruction].Execute (arguments);
			} else if (Jcommands.ContainsKey (instruction)) {
				this.Jcommands [instruction].Execute (arguments);
			} else {
				throw new IllegalOpcodeException();
			}
        }

        private Int32 ParseArgument(String argument, ref int offset) {
            //this is a regist
			int result = 0;
			if (argument.IndexOf ('$') == 0) {
                return ParseRegister(argument);
            } else if (argument.Contains("(")) {
				String[] parts = Regex.Split(argument,"[()]");
				offset = Int32.Parse(parts[0]);
                return ParseRegister(parts[1]);
			} else if (Int32.TryParse(argument, out result)) {
                return int.Parse(argument);
            } else {
                if (labels.ContainsKey(argument))
                    return labels[argument];
            }
            throw new ParserException();
        }

        private Int32 ParseRegister(String register)  {
            if (register == "$zero")    
                return 0;
            if (register == "$at")
                return 1;
            if (register.Contains("v")) 
				return Int32.Parse(register.Substring(2,1)) + 1;
            if (register.Contains("a"))
					return Int32.Parse(register.Substring(2,1)) + 4;
            if (register.Contains("t")) {
				int regNum = Int32.Parse(register.Substring(2,1));
                return regNum > 7 ? regNum + 24 : regNum + 8;
            }
			if (register == "$sp")
				return 29;
            if (register.Contains("s"))
				return Int32.Parse(register.Substring(2,1)) + 16;
            if (register.Contains("k"))
				return Int32.Parse(register.Substring(2,1)) + 26;
            if (register == "$gp")
                return 28;
            if (register == "$fp")
                return 30;
            if (register == "$ra")
                return 31;
            throw new ParserException();
        }

		private void SetRCommands()
		{
			//add
			this.Rcommands.Add("add", new AddCommand(file, special, stack));
			//addu
			this.Rcommands.Add("addu", new AddUCommand(file, special, stack));
			//sub
			this.Rcommands.Add("sub", new SubCommand(file, special, stack));
			//subu
			this.Rcommands.Add("subu", new SubUCommand(file, special, stack));
			//mult
			this.Rcommands.Add("mult", new MultCommand(file, special, stack));
			//multu
			this.Rcommands.Add("multu", new MultUCommand(file, special, stack));
			//div
			this.Rcommands.Add("div", new DivCommand(file, special, stack));
			//divu
			this.Rcommands.Add("divu", new DivUCommand(file, special, stack));
			//mfhi
			this.Rcommands.Add("mfhi", new MfhiCommand(file, special, stack));
			//mflo
			this.Rcommands.Add("mflo", new MfloCommand(file, special, stack));
			//and
			this.Rcommands.Add("and", new AndCommand(file, special, stack));
			//or
			this.Rcommands.Add("or", new OrCommand(file, special, stack));
			//xor
			this.Rcommands.Add("xor", new XorCommand(file, special, stack));
			//nor
			this.Rcommands.Add("nor", new NorCommand(file, special, stack));
			//slt
			this.Rcommands.Add("slt", new SltCommand(file, special, stack));
			//sltu
			this.Rcommands.Add("sltu", new SltuCommand(file, special, stack));
			//sll
			this.Rcommands.Add("sll", new SllCommand(file, special, stack));
			//srl
			this.Rcommands.Add("srl", new SrlCommand(file, special, stack));
			//sra
			this.Rcommands.Add("sra", new SraCommand(file, special, stack));
			//sllv
			this.Rcommands.Add("sllv", new SllvCommand(file, special, stack));
			//srlv
			this.Rcommands.Add("srlv", new SrlvCommand(file, special, stack));
			//srav
			this.Rcommands.Add("srav", new SravCommand(file, special, stack));
			//jr
			this.Rcommands.Add("jr", new JrCommand(file,special,stack));
		}

		private void SetICommands()
		{
			//addi
			this.Icommands.Add("addi", new AddICommand(file,special,stack));
			//addiu
			this.Icommands.Add("addiu", new AddIUCommand(file, special, stack));
			//lw
			this.Icommands.Add("lw", new LwCommand(file, special, stack));
			//lh
			this.Icommands.Add("lh", new LhCommand(file, special, stack));
			//lhu
			this.Icommands.Add("lhu", new LhuCommand(file, special, stack));
			//lb
			this.Icommands.Add("lb", new LbCommand(file, special, stack));
			//lbu
			this.Icommands.Add("lbu", new LbuCommand(file, special, stack));
			//sw
			this.Icommands.Add("sw",new SwCommand(file, special, stack));
			//sh
			this.Icommands.Add("sh",new ShCommand(file, special, stack));
			//sb
			this.Icommands.Add("sb", new SbCommand(file, special, stack));
			//lui
			this.Icommands.Add("lui", new LuiCommand(file, special, stack));
			//andi
			this.Icommands.Add("andi", new AndICommand(file, special, stack));
			//ori
			this.Icommands.Add("ori", new OrICommand(file, special, stack));
			//xori
			this.Icommands.Add("xori", new XorICommand(file, special, stack));
			//slti
			this.Icommands.Add("slti", new SltiCommand(file, special, stack));
			//sltiu
			this.Icommands.Add("sltiu", new SltiuCommand(file, special, stack));
			//beq
			this.Icommands.Add("beq", new BeqCommand(file, special, stack));
			//bne
			this.Icommands.Add("bne", new BneCommand(file, special, stack));
		}

		private void SetJCommands()
		{
			//j
			this.Jcommands.Add("j", new JCommand(file, special, stack));
			//jal
			this.Jcommands.Add("jal", new JalCommand(file, special, stack));
		}

		private void SetCommands()
		{
			SetICommands();
			SetJCommands();
			SetRCommands();
		}

    }
}

