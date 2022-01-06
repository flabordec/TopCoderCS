using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PrefixFreeSets
{
	class TreeNode
	{
		Dictionary<char, TreeNode> Children { get; set; }

		public TreeNode()
		{
			this.Children = new Dictionary<char, TreeNode>();
		}

		public TreeNode GetNode(char c)
		{
			if (!this.Children.ContainsKey(c))
				this.Children.Add(c, new TreeNode());

			return this.Children[c];
		}

		public int NumberOfLeaves()
		{
			if (this.Children.Count == 0)
			{
				return 1;
			}
			else
			{
				int count = 0;
				foreach (TreeNode child in this.Children.Values)
					count += child.NumberOfLeaves();
				return count;
			}
		}
	}

	public int maxElements(string[] words)
	{
		TreeNode root = new TreeNode();
		foreach (string word in words)
		{
			TreeNode curr = root;
			foreach (char c in word)
				curr = curr.GetNode(c);
		}

		return root.NumberOfLeaves();
	}
}
