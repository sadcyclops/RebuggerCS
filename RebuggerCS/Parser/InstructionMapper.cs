using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RebuggerCS
{
	public class InstructionMapper
	{
        private Dictionary<String, Int32> labels;
		private Dictionary<String, Object> RO_Data;
        public InstructionMapper(Dictionary<String, Int32> label, Dictionary<String, Object> ROData)  {
            this.labels = label;
            this.RO_Data = ROData;
        }

        public void MapInstruction(List<String> line) {
            if (line.Count == 0) return;

            //Get the instruction from the line object
            String instruction = line.RemoveAt(0);

            int offset = -1;
            List<int> arguments = new List<int>();
            while (line.Count > 0)  {
                arguments.add(ParseArgument(line.RemoveAt(0), out offset));
                if (line.Count == 0 && offset > -1)
                    arguments.add(offset);
                else if (line.Count > 0 && offset > -1)
                    throw new ParserException();
            }

            

        }

        private Int32 ParseArgument(String argument, out offset) {
            //this is a regist
            if (argument[0] == '$') {
                return ParseRegister(argument);
            } else if (argument.Contains("(")) {
                int offset = argument[0];
                //remove the parans around the register
                String register = argument.Replace('(');
                register = register.Replcae(')');
                //remove the first offset
                register = register.Remove(0,1);
                return ParseRegister(register);
            } else if (int.TryParse(argument))    {
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
                return int.Parse(register[2]) + 1;
            if (register.Contains("a"))
                return int.Parse(register[2]) + 4;
            if (register.Contains("t")) {
                int regNum = int.Parse(register[2]);
                return regNum > 7 ? regNum + 24 : regNum + 8;
            }
                return int.Parse(register[2]) + 8;
            if (register.Contains("s"))
                return int.Parse(register[2]) + 16;
            if (register.Contains("k"))
                return int.Parse(register[2]) + 26;
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
    }
}

