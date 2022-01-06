using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReadingBooks
{
	public int countBooks(string[] readParts)
	{
		int introduction = -1;
		int story = -1;
		int edification = -1;
		int count = 0;
		int index = 0;
		foreach (string readPart in readParts)
		{
			if (readPart.Equals("introduction"))
			{
				if (story < introduction)
					story = -1;
				if (edification < introduction)
					edification = -1;
				introduction = index;
			}
			if (readPart.Equals("story"))
			{
				if (introduction < story)
					introduction = -1;
				if (edification < story)
					edification = -1;

				story = index;
			}
			if (readPart.Equals("edification"))
			{
				if (introduction < edification)
					introduction = -1;
				if (story < edification)
					story = -1;

				edification = index;
			}

			Console.WriteLine("{0} => i>{1} s>{2} e>{3}", readPart, introduction, story, edification);
			if (introduction >= 0 && story >= 0 && edification >= 0)
			{
				Console.WriteLine("Counts");
				count++;
				introduction = -1;
				story = -1;
				edification = -1;
			}
			index++;
		}
		return count;
	}
}
