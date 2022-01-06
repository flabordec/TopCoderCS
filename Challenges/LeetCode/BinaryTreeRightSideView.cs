using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.BinaryTreeRightSideView
{
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

    public class Solution
    {
        public class State
        {
            public TreeNode Node { get; }
            public int Level { get; }

            public State(TreeNode curr, int level)
            {
                Node = curr;
                Level = level;
            }
        }

        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            var queue = new Queue<State>();
            queue.Enqueue(new State(root, 0));

            while (queue.Any())
            {
                State curr = queue.Dequeue();

                if (result.Count <= curr.Level)
                {
                    result.Add(0);
                }

                result[curr.Level] = curr.Node.val;

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
