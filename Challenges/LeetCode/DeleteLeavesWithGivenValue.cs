using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.DeleteLeavesWithGivenValue
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
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (!RemoveLeafNodesRecursive(root, target))
            {
                return root;
            }
            else
            {
                Console.WriteLine("Empty");
                return null;
            }
        }

        private bool RemoveLeafNodesRecursive(TreeNode node, int target)
        {
            bool leafNode = true;
            if (node.left != null)
            {
                bool removedLeft = RemoveLeafNodesRecursive(node.left, target);
                if (!removedLeft)
                {
                    leafNode = false;
                }
                else
                {
                    node.left = null;
                }
            }
            if (node.right != null)
            {
                bool removedRight = RemoveLeafNodesRecursive(node.right, target);
                if (!removedRight)
                {
                    leafNode = false;
                }
                else
                {
                    node.right = null;
                }
            }

            if (leafNode && node.val == target)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
