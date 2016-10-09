using System;
using RebuggerCS;
namespace LETSFUCKTHISSTACKUP
{
	class FUCKMYSTACKUP
	{
		static void Main()
		{
			StandardRegisterFile aReg = new StandardRegisterFile();
			StackFile fuckMe = new StackFile(aReg);

			// pushByte
			fuckMe.pushByte(0);
			fuckMe.pushByte(255);
			fuckMe.pushByte(1);
			fuckMe.pushByte(136);
			byte bPoppedOne = fuckMe.popByte();
			byte bPoppedTwo = fuckMe.popByte();
			int offset = 4;
			byte bPeekedOne = fuckMe.peekByte(offset);
			fuckMe.setByte(offset, bPeekedOne);

			StandardRegisterFile bReg = new StandardRegisterFile();
			StackFile fuckMeAgain = new StackFile(bReg);

			// pushShort
			fuckMeAgain.pushShort(0);
			fuckMeAgain.pushShort(65535);
			fuckMeAgain.pushShort(3194);
			fuckMeAgain.pushShort(134);
			ushort uPoppedOne = fuckMeAgain.popShort();
			ushort uPoppedTwo = fuckMeAgain.popShort();
			int offset2 = 4;
			ushort uPeekedOne = fuckMeAgain.peekShort(offset2);
			fuckMeAgain.setShort(offset2, uPeekedOne);

			StandardRegisterFile cReg = new StandardRegisterFile();
			StackFile fuckMeHarder = new StackFile(cReg);

			// pushInt
			fuckMeHarder.pushInt(0);
			fuckMeHarder.pushInt(4294967295);
			fuckMeHarder.pushInt(1);
			fuckMeHarder.pushInt(856);
			uint iPoppedOne = fuckMeHarder.popInt();
			uint iPoppedTwo = fuckMeHarder.popInt();
			int offset3 = 4;
			uint iPeekedOne = fuckMeHarder.peekInt(offset3);
			fuckMe.setByte(offset, bPeekedOne);

		}

	}

}