using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.DistributeCoinsInBinaryTree
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
        public int DistributeCoins(TreeNode root)
        {
            CountCoins(root, out _, out int movesNeeded);
            return movesNeeded;
        }

        public void CountCoins(TreeNode curr, out int excess, out int movesNeeded)
        {
            if (curr == null)
            {
                excess = 0;
                movesNeeded = 0;
                return;
            }

            CountCoins(curr.left, out int excessLeft, out int movesLeft);
            CountCoins(curr.right, out int excessRight, out int movesRight);

            excess = excessLeft + excessRight + (curr.val - 1);
            movesNeeded = movesLeft + movesRight + Math.Abs(excess);
        }
    }
}