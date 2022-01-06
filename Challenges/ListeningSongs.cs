using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListeningSongs
{
	public int listen(int[] durations1, int[] durations2, int minutes, int T)
	{
		int total = 0;

		Array.Sort(durations1);
		Array.Sort(durations2);

		Queue<int> durations1Q = new Queue<int>(durations1);
		Queue<int> durations2Q = new Queue<int>(durations2);

		int seconds = minutes * 60;

		// Add the minimum required time
		int time = 0;
		for (int i = 0; i < T; i++)
		{
			if (!durations1Q.Any() || !durations2Q.Any())
				return -1;

			int duration1 = durations1Q.Peek();
			int duration2 = durations2Q.Peek();

			Console.WriteLine("Duration 1 {0}, Duration 2 {0}", duration1, duration2);

			time += durations1Q.Dequeue() + durations2Q.Dequeue();
			total += 2;
		}

		if (time > seconds)
			return -1;

		int i1 = T;
		int i2 = T;
		while (durations1Q.Any() && durations2Q.Any() && time < seconds)
		{
			int duration1 = durations1Q.Peek();
			int duration2 = durations2Q.Peek();

			if (duration1 < duration2)
				time += durations1Q.Dequeue();
			else
				time += durations2Q.Dequeue();

			if (time <= seconds)
				total++;
		}

		while (durations1Q.Any() && time < seconds)
		{
			time += durations1Q.Dequeue();
			
			if (time <= seconds)
				total++;
		}

		while (durations2Q.Any() && time < seconds)
		{
			time += durations2Q.Dequeue();
			
			if (time <= seconds)
				total++;
		}

		return total;
	}
}

