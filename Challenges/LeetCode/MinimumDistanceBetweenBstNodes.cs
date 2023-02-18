using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.MinimumDistanceBetweenBstNodes
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
        public int MinDiffInBST(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            List<int> values = new List<int>();
            values.Add(root.val);
            queue.Enqueue(root);
            while (queue.Any())
            {
                var curr = queue.Dequeue();

                if (curr.right != null)
                {
                    values.Add(curr.right.val);
                    queue.Enqueue(curr.right);
                }

                if (curr.left != null)
                {
                    values.Add(curr.left.val);
                    queue.Enqueue(curr.left);
                }

            }

            values.Sort();

            int result = int.MaxValue;
            int prev = values.First();
            foreach (var value in values.Skip(1))
            {
                if (prev != value)
                {
                    result = Math.Min(result, Math.Abs(value - prev));
                    prev = value;
                }
            }
            return result;
        }
    }
}
