using System;
using System.Collections.Generic;

namespace RebuggerCS
{
	public class Processor
	{
		//General purpose registers
		private StandardRegisterFile gpRegisters;
		//Special purpose registers
		private SpecialRegisterFile sRegisters;
		//Stack
		private StackFile stack;

		/*I don't know what of these we need, I haven't totally read through them yet*/
		private FileParser parser;
		private InstructionMapper mapper;

		//Keeps track of current line in code;
		private Int32 line;
		private List<Int32> breaks;

		private Boolean continueSignal;
		private Boolean stopSignal;

		//Properties
		public StandardRegisterFile GPRegisters { get {return this.gpRegisters;}}
		public SpecialRegisterFile SRegisters { get {return this.sRegisters;}}
		public StackFile Stack { get {return this.stack;}}
		public Int32 Line { get {return this.line;}}
		public List<Int32> Breaks { get {return this.breaks;}}

		public Processor ()
		{
			gpRegisters = new StandardRegisterFile();
			sRegisters = new SpecialRegisterFile();
			stack = new StackFile(gpRegisters);
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

		//Called to continue after break
		public void RecieveStopSignal()
		{
			stopSignal = false;
		}

		public void ExecuteCode()
		{
			while (!breaks.Contains(line) || continueSignal || !stopSignal)
			{
				if (breaks.Contains(line)) { continueSignal = false;}
				if (!stopSignal) { stopSignal = true;}
				mapper.ExecuteInstruction();
			}
		}

		/*TODO Add the serializer code*/
	}
}

