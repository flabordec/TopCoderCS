using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.ConstructQuadTree
{
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    public class Solution
    {
        public Node Construct(int[][] grid)
        {
            var node = InnerConstruct(grid, 0, 0, grid.Length);
            return node;
        }

        public Node InnerConstruct(int[][] grid, int firstI, int firstJ, int maxPotentialSize)
        {
            if (firstI >= grid.Length || firstJ >= grid[firstI].Length)
                return null;

            int value = grid[firstI][firstJ];
            bool allEqual = AllEqual(grid, firstI, firstJ, maxPotentialSize);
            if (allEqual)
            {
                return new Node(value == 1, true);
            }
            else
            {
                int step = maxPotentialSize / 2;

                var topLeft = InnerConstruct(grid, firstI, firstJ, step);
                var topRight = InnerConstruct(grid, firstI, firstJ + step, step);
                var bottomLeft = InnerConstruct(grid, firstI + step, firstJ, step);
                var bottomRight = InnerConstruct(grid, firstI + step, firstJ + step, step);

                Node curr = new Node(true, false, topLeft, topRight, bottomLeft, bottomRight);
                return curr;
            }
        }

        public bool AllEqual(int[][] grid, int firstI, int firstJ, int maxSize)
        {
            int value = grid[firstI][firstJ];
            for (int di = 0; di < maxSize; di++)
            {
                for (int dj = 0; dj < maxSize; dj++)
                {
                    int ii = firstI + di;
                    int jj = firstJ + dj;
                    if (grid[ii][jj] != value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
