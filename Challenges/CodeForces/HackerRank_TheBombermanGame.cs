using System;
using System.Collections.Generic;
using System.IO;
class Solution_TheBombermanGame
{
	static int[] dr = { -1, 1, 0, 0 };
	static int[] dc = { 0, 0, -1, 1 };

	static void Main(String[] args)
	{
		string input = Console.ReadLine();
		string[] values = input.Split(' ');
		int r = int.Parse(values[0]);
		int c = int.Parse(values[1]);
		int n = int.Parse(values[2]);

		if (n == 1)
		{
			for (int i = 0; i < r; i++)
			{
				string line = Console.ReadLine();
				Console.WriteLine(line);
			}
			return;
		}
		else if (n % 2 == 0)
		{
			for (int i = 0; i < r; i++)
			{
				for (int j = 0; j < c; j++)
					Console.Write('O');
				Console.WriteLine();
			}
			return;
		}
		else
		{
			Solve(r, c, n % 4);
		}
	}

	private static void Solve(int r, int c, int n)
	{

		bool[][] exploded = new bool[r][];
		int[][] times = new int[r][];
		for (int i = 0; i < r; i++)
		{
			times[i] = new int[c];
			exploded[i] = new bool[c];
		}

		for (int i = 0; i < r; i++)
		{
			string line = Console.ReadLine();
			for (int j = 0; j < c; j++)
			{
				if (line[j] == 'O')
				{
					times[i][j] = 3;
				}
			}
		}

		for (int time = 2; time < n; time++)
		{
			Console.WriteLine("Time {0}", time);
			Print(r, c, time, times);
			Console.WriteLine();

			for (int i = 0; i < r; i++)
			{
				for (int j = 0; j < c; j++)
				{
					// place a new bomb
					if (times[i][j] <= time)
					{
						times[i][j] = time + 3;
						exploded[i][j] = true;
					}
					else
					{
						exploded[i][j] = false;
					}
				}
			}

			for (int i = 0; i < r; i++)
			{
				for (int j = 0; j < c; j++)
				{
					if (!exploded[i][j])
						continue;

					// set nearby bombs
					for (int d = 0; d < 4; d++)
					{
						int di = i + dr[d];
						int dj = j + dc[d];
						if (di < 0 || di >= r || dj < 0 || dj >= c)
							continue;

						times[di][dj] = Math.Min(times[di][dj], time + 3);
					}
				}
			}
		}

		Print(r, c, n, times);
	}

	private static void Print(int r, int c, int n, int[][] times)
	{
		for (int i = 0; i < r; i++)
		{
			for (int j = 0; j < c; j++)
				Console.Write(times[i][j] > n ? 'O' : '.');
			Console.WriteLine();
		}
	}
}