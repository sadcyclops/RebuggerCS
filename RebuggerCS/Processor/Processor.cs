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
		public String[] codeArray;

		/*I don't know what of these we need, I haven't totally read through them yet*/
		private FileParser parser;
		public InstructionMapper mapper;

		private List<Int32> breaks;

		private Boolean continueSignal;
		private Boolean stopSignal;

		//Properties
		public StandardRegisterFile GPRegisters { get {return this.gpRegisters;}}
		public SpecialRegisterFile SRegisters { get {return this.sRegisters;}}
		public StackFile Stack { get {return this.stack;}}
		public Int32 Line { get {return this.sRegisters.GetInt(0);}}
		public List<Int32> Breaks { get {return this.breaks;}}

		public Processor ()
		{
			stack = new StackFile();
			gpRegisters = new StandardRegisterFile(stack);
			sRegisters = new SpecialRegisterFile();
			continueSignal = false;
			stopSignal = false;
		}

		public Processor(StandardRegisterFile pfile, SpecialRegisterFile pspecial, StackFile pstack)
		{
			gpRegisters = pfile;
			sRegisters = pspecial;
			stack = pstack;
			continueSignal = false;
			stopSignal = false;
		}

		public void RecieveCode(String[] code, Int32[] stopPoints)
		{
			codeArray = code;
			parser = new FileParser(code);
			breaks = new List<int>(stopPoints);
		}

		public void ProcessCode()
		{
			parser.parse();
			mapper = new InstructionMapper(parser.Labels, parser.RO_Data, gpRegisters, sRegisters, stack);
        }


		public void ExecuteCode()
		{
			int index = sRegisters.GetInt(0);				
			if (index < codeArray.Length)
			{
				mapper.ExecuteInstruction(codeArray[index]);				
			}
		}

		/*TODO Add the serializer code*/
	}
}

