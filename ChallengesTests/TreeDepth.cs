using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCSTest
{
	public static class TreeDepth
	{
		public static List<int> GetLevel(Node node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			int depth = 0;
			while (node.Parent != null)
			{
				node = node.Parent;
				depth++;
			}

			List<int> results = new List<int>();
			Queue<Case> visit = new Queue<Case>();
			visit.Enqueue(new Case(node, 0));
			while (visit.Any())
			{
				Case curr = visit.Dequeue();

				if (curr.Depth == depth)
					results.Add(curr.Node.Value);

				if (curr.Depth < depth)
				{
					if (curr.Node.Left != null)
						visit.Enqueue(new Case(curr.Node.Left, curr.Depth + 1));
					if (curr.Node.Right != null)
						visit.Enqueue(new Case(curr.Node.Right, curr.Depth + 1));
				}
			}
			return results;
		}
	}

	public class Case
	{
		public Node Node { get; private set; }
		public int Depth { get; private set; }

		public Case(Node node, int depth)
		{
			this.Node = node;
			this.Depth = depth;
		}
	}

	public class Node
	{
		public Node Parent { get; private set; }

		private Node mLeft;
		public Node Left
		{
			get { return mLeft; }
			set
			{
				this.mLeft = value;
				if (value != null)
					value.Parent = this;
			}
		}
		private Node mRight;
		public Node Right
		{
			get { return mRight; }
			set
			{
				this.mRight = value;
				if (value != null)
					value.Parent = this;
			}
		}
		public int Value { get; set; }

		public Node(int value)
		{
			this.Value = value;
		}
	}
}
