using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Alliteration
	{
		public int count(string[] words)
		{
			char curr = '_';
			int count = 0;
			int i = 0;
			bool counted = false;
			while (i < words.Length)
			{
				char c = char.ToLower(words[i][0]);
				if (c == curr && !counted)
				{
					count++;
					counted = true;
				}
				if (c != curr)
				{
					curr = c;
					counted = false;
				}
				i++;
			}
			return count;
		}
	}