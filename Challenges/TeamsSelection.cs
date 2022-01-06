using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TeamsSelection
{
	public string simulate(int[] preference1, int[] preference2)
	{
		int[] selected = new int[preference1.Length];
		bool turn1 = true;

		int index1 = -1;
		int index2 = -1;
		int playerIx = 0;
		for (int i = 0; i < selected.Length; i++)
		{
			if (turn1)
			{
				do
				{
					index1++;
					playerIx = preference1[index1] - 1;
				} while (selected[playerIx] != 0);

				selected[playerIx] = 1;
			}
			else
			{
				do
				{
					index2++;
					playerIx = preference2[index2] - 1;
				} while (selected[playerIx] != 0);

				selected[playerIx] = 2;
			}
			turn1 = !turn1;
		}

		StringBuilder result = new StringBuilder();
		for (int i = 0; i < selected.Length; i++)
			result.Append(selected[i]);
		return result.ToString();
	}
}
