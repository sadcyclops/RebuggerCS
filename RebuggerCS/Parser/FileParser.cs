using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RebuggerCS
{
	public class FileParser
	{
		private String[] block;
		private Dictionary<String, Int32> labels;
		private Dictionary<String, Object> ROData;

		public FileParser(String[] input)
		{
			this.block = input;

		}

		public Dictionary<String, Int32> Labels { get { return labels; } }
		public Dictionary<String, Object> RO_Data { get { return ROData; } }

		public void ClearComments()
		{
			for (int i = 0; i < block.Length; i++)
			{ block[i] = block[i].Split('#')[0]; }
		}

		public void GetData()
		{
			Boolean isData = true;
			Regex rgx = new Regex(@".*:.*");
			for (int i = 0; i < block.Length; i++)
			{
				if (!isData)
				{
					isData = block[i].Trim().Equals(".text");
				}
				else
				{
					if (rgx.IsMatch(this.block[i]))
					{
						String[] things = block[i].Split(':');
						ROData.Add(things[0], things[1]);
					}
				}
			}
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
						labels.Add(block[i].Split(':')[0], i + 1);
					}
				}
			}
		}

		public void parse()
		{
			this.ClearComments();
			this.GetData();
			this.GetLabels();
		}
	}
}
