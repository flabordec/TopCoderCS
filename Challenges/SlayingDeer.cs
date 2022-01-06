using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SlayingDeer
{
	public int getTime(int A, int B, int C)
	{
		if (C == 0)
			return 0;

		if ((B * 30) >= (A * 45))
			return -1;

		int totalTime = 0;
		while (true)
		{
			// If I'm making progress
			if (A > B)
			{
				int time = C / (A - B);
				if (C % (A - B) > 0)
					time++;

				if (time >= 0 && time <= 30)
					return totalTime + (int)time;
			}

			C = C + (B * 30) - (A * 30);
			totalTime += 30;

			if (C - (A * 15) > 0)
			{
				C = C - (A * 15);
				totalTime += 15;
			}
			else
			{
				int time = (C / A);
				if (C % A > 0)
					time++;
				return totalTime + time;
			}
		}
	}
}
