using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.BinaryTreeMaximumPathSum
{
    /**
     * Definition for a binary tree node.
     */
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
        public int MaxPathSum(TreeNode root)
        {
            int accum;
            int max = root.val;
            RebuildTree(root, out accum, ref max);
            return max;
        }

        public void RebuildTree(TreeNode node, out int accum, ref int max)
        {
            accum = node.val;
            int currMax = node.val;
            if (node.left != null)
            {
                int accumLeft;
                RebuildTree(node.left, out accumLeft, ref max);
                accum = Math.Max(accum, node.val + accumLeft);
                
                if (accumLeft > 0)
                    currMax += accumLeft;
            }

            if (node.right != null)
            {
                int accumRight;
                RebuildTree(node.right, out accumRight, ref max);
                accum = Math.Max(accum, node.val + accumRight);

                if (accumRight > 0)
                    currMax += accumRight;
            }

            max = Math.Max(currMax, max);
        }
    }
}
