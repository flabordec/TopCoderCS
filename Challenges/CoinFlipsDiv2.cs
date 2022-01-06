using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CoinFlipsDiv2
{
	public int countCoins(string state)
	{
		int count = 0;
		for (int i = 0; i < state.Length; i++)
		{
			bool interesting = false;
			if (i > 0)
				interesting |= (state[i-1] != state[i]);
			
			if (i < state.Length - 1)
				interesting |= (state[i+1] != state[i]);

			if (interesting)
				count++;
		}
		return count;
	}
}
