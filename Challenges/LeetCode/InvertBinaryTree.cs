using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.InvertBinaryTree
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
        public TreeNode Current { get; }
        public TreeNode Result { get; }

        public State(TreeNode current, TreeNode result)
        {
            Current = current;
            Result = result;
        }
    }

    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            var queue = new Queue<State>();
            var result = new TreeNode(root.val);
            queue.Enqueue(new State(root, result));
            while (queue.Any())
            {
                var state = queue.Dequeue();

                if (state.Current.right != null)
                {
                    state.Result.left = new TreeNode(state.Current.right.val);
                    queue.Enqueue(new State(state.Current.right, state.Result.left));
                }

                if (state.Current.left != null)
                {
                    state.Result.right = new TreeNode(state.Current.left.val);
                    queue.Enqueue(new State(state.Current.left, state.Result.right));
                }

            }

            return result;
        }
    }
}
