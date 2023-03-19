using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.BinaryTreeZigzagLevelOrderTraversal
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class State
    {
        public TreeNode Node { get; }
        public int Level { get; }

        public State(TreeNode node, int level)
        {
            Node = node;
            Level = level;
        }
    }

    public class Solution
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<State>();
            queue.Enqueue(new State(root, 0));
            while (queue.Any())
            {
                var curr = queue.Dequeue();

                if (curr.Level == result.Count)
                {
                    result.Add(new List<int>());
                }

                if ((curr.Level & 1) == 0)
                {
                    result[curr.Level].Add(curr.Node.val);
                }
                else
                {
                    result[curr.Level].Insert(0, curr.Node.val);
                }

                if (curr.Node.left != null)
                {
                    queue.Enqueue(new State(curr.Node.left, curr.Level + 1));
                }

                if (curr.Node.right != null)
                {
                    queue.Enqueue(new State(curr.Node.right, curr.Level + 1));
                }
            }

            return result;
        }
    }
}
