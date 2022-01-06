using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ColorfulTilesEasy
{
	public int theMin(string room)
	{
		int count = 0;
		for (int i = 1; i < room.Length; i++)
		{
			if (room[i] == room[i - 1])
			{
				count++;
				i++;
			}
		}
		return count;
	}
}
