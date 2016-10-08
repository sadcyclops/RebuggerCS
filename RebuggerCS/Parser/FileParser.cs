﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RebuggerCS
{
	public class FileParser
	{
		private String[] block;
		private Dictionary<String, Int32> labels;
		private Dictionary<String, Object> RO_Data;

		public FileParser(String[] input)
		{
			this.block = input;
		}

		public void GetLabels()
		{
			Boolean isText = false;
			Regex rgx = new Regex(@".*:.*");
			for (int i = 0; i < block.Length; i++)
			{
				if (!isText)
				{
					isText = block[i].Trim().Equals(".text");
				}
				else
				{
					if (rgx.IsMatch(this.block[i]))
					{
						labels.Add(block[i].Split(':')[0], i+1);
					}
				}
			}
		}
		
		public static String GetWordPrefix(String line)	{
			return line.Split('#')[0];
		}
	}
}
