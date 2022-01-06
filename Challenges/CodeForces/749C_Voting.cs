using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Voting_749C
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		string s = Console.ReadLine();

		var str = new LinkedList<char>();

		int rs = 0;
		int ds = 0;
		for (int i = 0; i < n; i++)
		{
			str.AddLast(s[i]);
			if (s[i] == 'R')
				rs++;
			else if (s[i] == 'D')
				ds++;
		}

		int count = 0;
		LinkedListNode<char> next = str.First;
		LinkedListNode<char> curr = null;
		while (rs > 0 && ds > 0)
		{
			curr = next;
			next = Next(next);

			if (curr.Value == 'R')
			{
				if (count >= 0)
				{
					count++;
				}
				else
				{
					count++;
					str.Remove(curr);
					rs--;
				}
			}
			else if (curr.Value == 'D')
			{
				if (count <= 0)
				{
					count--;
				}
				else
				{
					count--;
					str.Remove(curr);
					ds--;
				}
			}
		}
		if (rs > 0)
			Console.WriteLine('R');
		else if (ds > 0)
			Console.WriteLine('D');
	}

	private static LinkedListNode<char> Next(LinkedListNode<char> node)
	{
		if (node.List.Count == 1)
			return null;
		else if (node.Next == null)
			return node.List.First;
		else
			return node.Next;
	}
}