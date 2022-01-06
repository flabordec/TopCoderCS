using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OmegaUp_DocTechWhereUsed_FastNoMem
{
	public class Node
	{
		public int Id { get; }
		public char Type { get; }
		private long[] WhereUsed { get; }

		/// <inheritdoc />
		public Node(int id, char type)
		{
			this.Id = id;
			this.Type = type;
			this.WhereUsed = new long[80];
			if (this.Type == 'M')
				TurnOn(id);
		}

		public void TurnOn(int ix)
		{
			int box = ix / 64;
			int i = ix % 64;
			WhereUsed[box] |= (1L << i);
		}

		public void Union(Node other)
		{
			for (int i = 0; i < this.WhereUsed.Length; i++)
			{
				this.WhereUsed[i] |= other.WhereUsed[i];
			}
		}

		public int Count()
		{
			int count = 0;
			for (int i = 0; i < this.WhereUsed.Length; i++)
			{
				long value = this.WhereUsed[i];
				while (value != 0)
				{
					count++;
					value &= value - 1;
				}
			}
			if (this.Type == 'M')
				count--;
			return count;
		}
	}

	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		string readLine = Console.ReadLine();
		char[] types = readLine.Trim().Split(' ').Select(s => s[0]).ToArray();
		int l = int.Parse(Console.ReadLine());

		Node[] nodes = new Node[n];
		for (int i = 0; i < n; i++)
			nodes[i] = new Node(i, types[i]);

		for (int i = 0; i < l; i++)
		{
			string line = Console.ReadLine();
			string[] splitLine = line.Split(' ');
			if (splitLine[0].Equals("L"))
			{
				int from = int.Parse(splitLine[1]);
				int to = int.Parse(splitLine[2]);
				nodes[to].Union(nodes[from]);

			}
			else if (splitLine[0].Equals("Q"))
			{
				int id = int.Parse(splitLine[1]);
				Console.WriteLine(nodes[id].Count());
			}
		}
	}
}

class OmegaUp_DocTechWhereUsed_Fast
{
	public class Node : IEquatable<Node>
	{
		public int Id { get; }
		public char Type { get; }
		public HashSet<int> WhereUsed { get; }

		/// <inheritdoc />
		public Node(int id, char type)
		{
			this.Id = id;
			this.Type = type;
			this.WhereUsed = new HashSet<int>();
			if (this.Type == 'M')
				this.WhereUsed.Add(this.Id);
		}


		#region IEquatable

		/// <summary>
		/// Gets the hash code for this Node.
		/// </summary>
		/// <returns>The hash code for this Node.</returns>
		public override int GetHashCode()
		{
			unchecked // Overflow is expected, just wrap
			{
				int hash = 17;
				hash = hash * 486187739 + this.Id.GetHashCode();
				return hash;
			}
		}

		/// <summary>
		/// Returns whether <paramref name="obj"/> is equal to this Node. 
		/// </summary>
		/// <param name="obj">The object to compare against.</param>
		/// <returns>True if the other object is equal to this Node.</returns>
		public override bool Equals(object obj)
		{
			// check other object for null
			if (object.ReferenceEquals(obj, null))
				return false;

			// check to see if the references are exactly the same
			if (object.ReferenceEquals(this, obj))
				return true;

			// If the type doesn't match then we could have similar objects that inherit appear as 
			// if they were equal.
			if (this.GetType() != obj.GetType())
				return false;

			return this.Equals(obj as Node);
		}

		/// <summary>
		/// Returns whether <paramref name="other"/> is equal to this Node. 
		/// </summary>
		/// <param name="other">The object to compare against.</param>
		/// <returns>True if the other object is equal to this Node.</returns>
		public bool Equals(Node other)
		{
			// check other Node for null
			if (object.ReferenceEquals(other, null))
				return false;

			// check to see if the references are exactly the same
			if (object.ReferenceEquals(this, other))
				return true;

			if (!this.Id.Equals(other.Id))
				return false;

			return true;
		}
		#endregion
	}

	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		string readLine = Console.ReadLine();
		char[] types = readLine.Trim().Split(' ').Select(s => s[0]).ToArray();
		int l = int.Parse(Console.ReadLine());

		Node[] nodes = new Node[n];
		for (int i = 0; i < n; i++)
			nodes[i] = new Node(i, types[i]);

		for (int i = 0; i < l; i++)
		{
			string line = Console.ReadLine();
			string[] splitLine = line.Split(' ');
			if (splitLine[0].Equals("L"))
			{
				int from = int.Parse(splitLine[1]);
				int to = int.Parse(splitLine[2]);
				nodes[to].WhereUsed.UnionWith(nodes[from].WhereUsed);
			}
			else if (splitLine[0].Equals("Q"))
			{
				int id = int.Parse(splitLine[1]);
				PrintMap(nodes[id].WhereUsed, id);
			}
		}
	}

	private static void PrintMap(HashSet<int> maps, int id)
	{
		Console.WriteLine(maps.Count(i => i != id));
	}
}

class OmegaUp_DocTechWhereUsed_Slow
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		char[] types = Console.ReadLine().Split(' ').Select(s => s[0]).ToArray();
		int l = int.Parse(Console.ReadLine());

		bool[][] graph = new bool[n][];
		for (int i = 0; i < n; i++)
			graph[i] = new bool[n];

		for (int i = 0; i < l; i++)
		{
			string line = Console.ReadLine();
			string[] splitLine = line.Split(' ');
			if (splitLine[0].Equals("L"))
			{
				int from = int.Parse(splitLine[1]);
				int to = int.Parse(splitLine[2]);
				graph[from][to] = true;
			}
			else if (splitLine[0].Equals("Q"))
			{
				int id = int.Parse(splitLine[1]);

				HashSet<int> seen = new HashSet<int>();
				HashSet<int> maps = new HashSet<int>();
				Queue<int> queue = new Queue<int>();
				queue.Enqueue(id);
				while (queue.Any())
				{
					int curr = queue.Dequeue();
					if (seen.Contains(curr))
						continue;

					seen.Add(curr);
					if (types[curr] == 'M')
						maps.Add(curr);

					for (int prev = 0; prev < n; prev++)
					{
						if (graph[prev][curr])
							queue.Enqueue(prev);
					}
				}
				PrintMap(maps, id);
			}
		}
	}

	private static void PrintMap(HashSet<int> maps, int id)
	{
		Console.WriteLine(maps.Count - 1);
	}
}