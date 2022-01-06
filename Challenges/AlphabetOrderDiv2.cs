using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AlphabetOrderDiv2
{
	private Dictionary<char, Node> Nodes { get; set; }

	private class Node : IEquatable<Node>
	{
		public char C { get; }
		public HashSet<Node> Children { get; }

		public Node(char c)
		{
			this.C = c;
			this.Children = new HashSet<Node>();
		}

		public override string ToString()
		{
			return this.C.ToString();
		}

		#region IEquatable
		public override int GetHashCode()
		{
			return this.C.GetHashCode();
		}

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

		public bool Equals(Node other)
		{
			return (this.C == other.C);
		}
		#endregion
	}

	public string isOrdered(string[] words)
	{
		this.Nodes = new Dictionary<char, Node>();
		foreach (string word in words)
		{
			Node parentNode = null;
			Node currentNode;
			foreach (char c in word)
			{
				if (this.Nodes.ContainsKey(c))
					currentNode = this.Nodes[c];
				else
				{
					currentNode = new Node(c);
					this.Nodes.Add(c, currentNode);
				}

				if (parentNode != null && !object.ReferenceEquals(parentNode, currentNode))
				{
					parentNode.Children.Add(currentNode);
				}

				parentNode = currentNode;
			}
		}

		HashSet<Node> allNodes = new HashSet<Node>(Nodes.Values);
		foreach (Node node in Nodes.Values)
		{
			foreach (Node child in node.Children)
				allNodes.Remove(child);
		}

		HashSet<Node> startNodes = new HashSet<Node>(allNodes);
		HashSet<Node> visited = new HashSet<Node>();
		while (startNodes.Any())
		{
			Node current = startNodes.First();
			startNodes.Remove(current);
			visited.Add(current);

			current.Children.Clear();
			foreach (Node next in Nodes.Values)
			{
				if (visited.Contains(next))
					continue;

				if (!Nodes.Values.Any(n => n.Children.Contains(next)))
					startNodes.Add(next);
			}
		}
		if (Nodes.Values.Any(n => n.Children.Any()))
			return "Impossible";
		else
			return "Possible";

	}
}
