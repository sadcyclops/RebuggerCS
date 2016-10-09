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

        public InstructionMapper(Dictionary<String, Int32> label, Dictionary<String, Object> ROData)  {
            this.labels = label;
            this.RO_Data = ROData;
        }

        public void ExecuteInstruction(List<String> line) {
            if (line.Count == 0) return;

            //Get the instruction from the line object
            String instruction = line[0];

            int offset = -1;
            List<int> arguments = new List<int>();
            while (line.Count > 0)  {
                arguments.Add(ParseArgument(line[0], offset));
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
				throw new IllegalOpcodeException ();
			}
        }

        private Int32 ParseArgument(String argument, int offset) {
            //this is a regist
			int result = 0;
			if (argument.IndexOf ('$') == 0) {
                return ParseRegister(argument);
            } else if (argument.Contains("(")) {
                offset = argument[0];
                //remove the parans around the register
                String register = argument.Replace("(","");
				register = register.Replace(")","");
                //remove the first offset
                register = register.Remove(0,1);
                return ParseRegister(register);
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
            if (register.Contains("s"))
				return Int32.Parse(register.Substring(2,1)) + 16;
            if (register.Contains("k"))
				return Int32.Parse(register.Substring(2,1)) + 26;
            if (register == "$gp")
                return 28;
            if (register == "$sp")
                return 29;
            if (register == "$fp")
                return 30;
            if (register == "$ra")
                return 31;
            throw new ParserException();
        }

		private void SetRCommands()
		{
			//add
			this.Rcommands.Add("add", new AddCommand());
			//addu
			//sub
			//subu
			//mult
			//multu
			//div
			//divu
			//mfhi
			//mflo
			//mfcz
			//mtcz
			//and
			//or
			//xor
			//nor
			//slt
			//sltu
			//sll
			//srl
			//sra
			//sllv
			//srlv
			//srav
		}

		private void SetICommands()
		{
			//addi
			//addiu
			//lw
			//lh
			//lhu
			//lb
			//lbu
			//sw
			//sh
			//sb
			//lui
			//andi
			//ori
			//xori
			//slti
			//beq
			//bne
			//jr
		}

		private void SetJCommands()
		{
			//j
			//jal
		}

		private void SetCommands()
		{
			SetICommands();
			SetJCommands();
			SetRCommands();
		}

    }
}

