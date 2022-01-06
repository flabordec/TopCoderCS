using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.TheSkylineProblem
{
    public class Solution
    {
        private enum StackOperation
        {
            Push,
            Pop,
        }

        private class Operation
        {
            public StackOperation StackOperation { get; }
            public int Height { get; }

            public Operation(StackOperation stackOperation, int height)
            {
                StackOperation = stackOperation;
                Height = height;
            }
        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var operations = new Dictionary<int, List<Operation>>();
            var indices = new HashSet<int>();

            for (int i = 0; i < buildings.Length; i++)
            {
                int left = buildings[i][0];
                int right = buildings[i][1];
                int height = buildings[i][2];

                AddToDictionary(operations, indices, StackOperation.Push, left, height);
                AddToDictionary(operations, indices, StackOperation.Pop, right, height);
            }

            var sortedIndices = indices.ToList();
            sortedIndices.Sort();

            List<int> heightsStack = new List<int>();
            List<IList<int>> ret = new List<IList<int>>();

            int previousHeight = 0;
            foreach (int ix in sortedIndices)
            {
                foreach (var operation in operations[ix])
                {
                    if (operation.StackOperation == StackOperation.Push)
                    {
                        InsertInOrder(heightsStack, operation.Height);
                    }
                    else if (operation.StackOperation == StackOperation.Pop)
                    {
                        RemoveInOrder(heightsStack, operation.Height);
                    }
                }
                int currentHeight = heightsStack.LastOrDefault();

                if (currentHeight != previousHeight)
                {
                    var currRet = new List<int>() { ix, currentHeight };
                    ret.Add(currRet);
                    previousHeight = currentHeight;
                }
            }

            return ret;
        }

        private void AddToDictionary(Dictionary<int, List<Operation>> operations, HashSet<int> indices, StackOperation operation, int x, int height)
        {
            if (!operations.ContainsKey(x))
                operations.Add(x, new List<Operation>());
            operations[x].Add(new Operation(operation, height));

            indices.Add(x);
        }

        private void InsertInOrder(List<int> values, int newValue)
        {
            int i = 0;
            while (i < values.Count && values[i] < newValue)
            {
                i++;
            }
            values.Insert(i, newValue);
        }

        private void RemoveInOrder(List<int> values, int valueToRemove)
        {
            int ixToRemove = BinarySearch(values, valueToRemove);
            values.RemoveAt(ixToRemove);
        }

        private int BinarySearch(List<int> values, int valueToFind)
        {
            int lo = 0;
            int hi = values.Count - 1;
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) >> 1);
                if (values[mid] == valueToFind)
                {
                    return mid;
                }
                else if (values[mid] < valueToFind)
                {
                    lo = mid + 1;
                }
                else if (values[mid] > valueToFind)
                {
                    hi = mid - 1;
                }
            }
            return ~lo;
        }
    }
}
