using System;
using System.Collections.Generic;

namespace RebuggerCS
{
	public class Processor
	{
		//General purpose registers
		private RegisterFile gpRegisters;
		//Special purpose registers
		private RegisterFile sRegisters;
		//Stack
		private StackFile stack;

		/*I don't know what of these we need, I haven't totally read through them yet*/
		private FileParser parser;
		private InstructionMapper mapper;

		//Keeps track of current line in code;
		private Int32 line;
		private List<Int32> breaks;

		private Boolean continueSignal;

		public Processor ()
		{
			gpRegisters = new StandardRegisterFile();
			sRegisters = new SpecialRegisterFile();
			stack = new StackFile();
			line = 0;
			continueSignal = false;
		}

		public void RecieveCode(String[] code, Int32[] stopPoints)
		{
			parser = new FileParser(code);
			breaks = new List<int>(stopPoints);
		}

		public void ProcessCode()
		{
			parser.parse();
			mapper = new InstructionMapper(parser.Labels, parser.RO_Data);
		}

		//Called to continue after break
		public void RecieveContinueSignal()
		{
			continueSignal = true;
		}

		public void ExecuteCode()
		{
			while (!breaks.Contains(line)||continueSignal)
			{
				if (continueSignal) { continueSignal = false;}
				mapper.ExecuteInstruction();
			}
		}
	}
}

