using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OmegaUp_TestStandDeployment
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		
		var tree = new bool[n][];
		for (int i = 0; i < n; i++)
			tree[i] = new bool[n];

		for (int i = 0; i < n; i++)
		{
			string line = Console.ReadLine();
			string[] splitLine = line.Split(' ');
			int from = int.Parse(splitLine[0]);

			for (int j = 1; j < splitLine.Length; j++)
			{
				int to = int.Parse(splitLine[j]);
				tree[from][to] = true;
			}
		}
		HashSet<int> seen = new HashSet<int>();
		Queue<int> queue = new Queue<int>();
		int w = int.Parse(Console.ReadLine());
		queue.Enqueue(w);
		seen.Add(w);
		while (queue.Any())
		{
			int curr = queue.Dequeue();
			for (int i = 0; i < n; i++)
			{
				if (tree[curr][i] && !seen.Contains(i))
				{
					queue.Enqueue(i);
					seen.Add(i);
				}
			}
		}
		Console.WriteLine(string.Join(" ", seen.OrderBy(i => i)));
	}
}
