using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParallelProgramming
{
	public int minTime(int[] time, string[] prec)
	{
		int[] newTimes = new int[time.Length];
		bool[] done = new bool[time.Length];

		char[][] precArr = (from p in prec
							select p.ToCharArray()).ToArray();
		
		bool progress = true;
		int max = 0;
		
		while (progress)
		{
			// see if I can make any progress with any processes
			progress = false;

			if (done.All(b => b))
				return max;

			for (int i = 0; i < time.Length; i++)
			{
				// If this process already ran then don't run it
				if (done[i])
					continue;

				// If I don't depend on anything else then I can run
				bool canStart = true;
				for (int j = 0; j < time.Length; j++)
				{
					if (precArr[i][j] == 'Y')
						canStart = false;
				}

				if (canStart)
				{
					done[i] = true;

					// I made some progress in this move
					progress = true;

					// add the time it takes for this process to execute to the total time of 
					// this process
					newTimes[i] += time[i];
					if (max < newTimes[i])
						max = newTimes[i];

					// and for any processes that depend on it, add the time 
					for (int j = 0; j < time.Length; j++)
					{
						if (precArr[j][i] == 'Y')
						{
							precArr[j][i] = 'N';
							newTimes[j] = Math.Max(newTimes[i], newTimes[j]);
						}
					}
				}
			}

			if (!progress)
				return -1;
		}
		return max;
		
	}
}

