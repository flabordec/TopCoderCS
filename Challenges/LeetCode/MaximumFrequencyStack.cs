using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.MaximumFrequencyStack
{
    public class FreqStack
    {
        private List<int> Values { get; } = new List<int>();
        // N -> # of times in stack
        private Dictionary<int, int> Counts { get; } = new Dictionary<int, int>();
        private Dictionary<int, HashSet<int>> ReverseCounts { get; } = new Dictionary<int, HashSet<int>>();
        private int MaximumCount { get; set; }

        public FreqStack()
        {

        }

        public void Push(int x)
        {
            Values.Add(x);

            if (!Counts.ContainsKey(x))
                Counts.Add(x, 0);
            Counts[x]++;

            int count = Counts[x];
            MaximumCount = Math.Max(count, MaximumCount);

            if (!ReverseCounts.ContainsKey(count))
            {
                ReverseCounts.Add(count, new HashSet<int>());
            }
            if (count > 1)
            {
                ReverseCounts[count - 1].Remove(x);
            }
            ReverseCounts[count].Add(x);
        }

        public int Pop()
        {
            int maxCount = MaximumCount;
            HashSet<int> maxValues = ReverseCounts[maxCount];

            int i = Values.FindLastIndex(v => maxValues.Contains(v));
            int valueToRemove = Values[i];
            Counts[valueToRemove]--;

            ReverseCounts[maxCount].Remove(valueToRemove);
            if (!ReverseCounts[maxCount].Any())
            {
                ReverseCounts.Remove(maxCount);
                MaximumCount--;
            }
            if (maxCount > 1)
            {
                ReverseCounts[maxCount - 1].Add(valueToRemove);
            }

            Values.RemoveAt(i);
            return valueToRemove;
        }
    }

    /**
     * Your FreqStack object will be instantiated and called as such:
     * FreqStack obj = new FreqStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     */
}
