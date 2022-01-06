using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Solution_BreadthFirstSearchShortestReach
{
	class State
	{
		public int N { get; }
		public int Length { get; }

		public State(int n, int length)
		{
			this.N = n;
			this.Length = length;
		}
	}

	static void Main(String[] args)
	{
		int Q = int.Parse(Console.ReadLine());
		for (int q = 0; q < Q; q++)
		{
			string[] NM = Console.ReadLine().Split(' ');
			int N = int.Parse(NM[0]);
			int M = int.Parse(NM[1]);
			var map = new bool[N][];
			for (int i = 0; i < N; i++)
				map[i] = new bool[N];

			for (int t = 0; t < M; t++)
			{
				string[] uv = Console.ReadLine().Split(' ');
				int u = int.Parse(uv[0]) - 1;
				int v = int.Parse(uv[1]) - 1;
				map[u][v] = true;
				map[v][u] = true;
			}

			int S = int.Parse(Console.ReadLine()) - 1;

			var queue = new Queue<State>();
			var results = new int[N];
			for (int i = 0; i < N; i++)
				results[i] = -1;
			queue.Enqueue(new State(S, 0));
			
			while (queue.Any())
			{
				State curr = queue.Dequeue();
				if (results[curr.N] != -1)
					continue;
				results[curr.N] = curr.Length;

				for (int next = 0; next < N; next++)
				{
					if (map[curr.N][next] == true)
						queue.Enqueue(new State(next, curr.Length + 1));
				}
			}

			for (int i = 0; i < N; i++)
			{
				if (i != S)
				{
					if (results[i] != -1)
						Console.Write(results[i] * 6 + " ");
					else 
						Console.Write(results[i] + " ");
				}
			}
			Console.WriteLine();
		}
	}
	
}
