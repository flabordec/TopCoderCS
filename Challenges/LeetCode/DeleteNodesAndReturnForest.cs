using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.DeleteNodesAndReturnForest
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
        class State
        {
            public TreeNode Node { get; }
            public bool ShouldAdd { get; }

            public State(TreeNode node, bool shouldAdd)
            {
                Node = node;
                ShouldAdd = shouldAdd;
            }
        }

        private bool ShouldDelete(int val, int[] toDelete)
        {
            return Array.BinarySearch(toDelete, val) >= 0;
        }

        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            Array.Sort(to_delete);

            var treeNodes = new List<TreeNode>();
            var queue = new Queue<State>();
            queue.Enqueue(new State(root, true));
            while (queue.Any())
            {
                var curr = queue.Dequeue();
                var node = curr.Node;
                bool nextShouldAdd = curr.ShouldAdd;
                if (curr.ShouldAdd && !ShouldDelete(node.val, to_delete))
                {
                    treeNodes.Add(curr.Node);
                    nextShouldAdd = false;
                }

                if (node.left != null)
                {
                    var left = node.left;
                    if (ShouldDelete(left.val, to_delete))
                    {
                        node.left = null;
                        queue.Enqueue(new State(left, true));
                    } 
                    else
                    {
                        queue.Enqueue(new State(left, nextShouldAdd));
                    }
                    
                }

                if (node.right != null)
                {
                    var right = node.right;
                    if (ShouldDelete(right.val, to_delete))
                    {
                        node.right = null;
                        queue.Enqueue(new State(right, true));
                    }
                    else
                    {
                        queue.Enqueue(new State(right, nextShouldAdd));
                    }
                }
            }
            return treeNodes;
        }
    }
}
