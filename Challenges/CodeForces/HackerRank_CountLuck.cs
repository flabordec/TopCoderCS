using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Solution_CountLuck
{
	class State
	{
		public int N { get; }
		public int M { get; }
		public int Length { get; set; }

		public State(int n, int m, int length)
		{
			this.N = n;
			this.M = m;
			this.Length = length;
		}
	}

	private static int[] dN = new[] {0, 0, 1, -1};
	private static int[] dM = new[] {1, -1, 0, 0};

	static void Main(String[] args)
	{
		int T = int.Parse(Console.ReadLine());
		for (int t = 0; t < T; t++)
		{
			string[] NM = Console.ReadLine().Split(' ');
			int N = int.Parse(NM[0]);
			int M = int.Parse(NM[1]);
			char[][] map = new char[N][];

			State startingState = null;
			State endingState = null;
			for (int n = 0; n < N; n++)
			{
				map[n] = Console.ReadLine().ToCharArray();
				for (int m = 0; m < M; m++)
				{
					if (map[n][m] == 'M')
						startingState = new State(n, m, 0);
					else if (map[n][m] == '*')
						endingState = new State(n, m, 0);
				}
			}

			int K = int.Parse(Console.ReadLine());

			BFS(N, M, map, startingState, endingState, K);
		}
	}

	private static void BFS(int N, int M, char[][] map, State startingState, State endingState, int K)
	{
		Queue<State> queue = new Queue<State>();
		queue.Enqueue(startingState);
		while (queue.Any())
		{
			State curr = queue.Dequeue();

			if (curr.N == endingState.N && curr.M == endingState.M)
			{
				if (curr.Length == K)
				{
					Console.WriteLine("Impressed");
					return;
				}
				else
				{
					Console.WriteLine("Oops!");
					return;
				}
			}

			map[curr.N][curr.M] = (char)('0' + curr.Length);
			//for (int n = 0; n < N; n++)
			//	Console.Error.WriteLine(new String(map[n]));
			//Console.Error.WriteLine("============");

			var states = new List<State>();
			for (int d = 0; d < dN.Length; d++)
			{
				int nextN = curr.N + dN[d];
				int nextM = curr.M + dM[d];

				if (curr.Length == K + 1)
					continue;
				if (nextN < 0 || nextN >= N)
					continue;
				if (nextM < 0 || nextM >= M)
					continue;
				if (map[nextN][nextM] != '.' && map[nextN][nextM] != '*')
					continue;

				State next = new State(nextN, nextM, curr.Length);
				states.Add(next);
			}

			if (states.Count == 1)
			{
				queue.Enqueue(states.Single());
			}
			else
			{
				foreach (State state in states)
				{
					state.Length++;
					queue.Enqueue(state);
				}
			}
		}

		Console.WriteLine("Oops!");
		return;
	}
}
