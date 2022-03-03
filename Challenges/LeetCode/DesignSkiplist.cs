using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.DesignSkiplist
{
    public class Skiplist
    {
        public class Node
        {
            public int Value { get; }
            public int Level { get; }
            public int Count { get; set; }
            public Node Bottom { get; set; }
            public Node Next { get; set; }

            public Node(int value, int level)
            {
                Value = value;
                Level = level;
                Count = 1;
            }
        }

        private readonly List<Node> _levels;
        private readonly Random _random = new Random(1);

        public Skiplist()
        {
            _levels = new List<Node>();
            Node below = null;
            for (int i = 0; i < 5; i++)
            {
                _levels.Add(null);
                _levels[i] = new Node(-1, i);
                _levels[i].Bottom = below;
                below = _levels[i];
            }
        }

        private bool InnerSearch(int num, Node curr)
        {
            if (curr.Bottom == null)
            {
                while (
                    curr.Next != null &&
                    curr.Next.Value <= num)
                {
                    curr = curr.Next;
                }
                return curr.Value == num;
            }
            else
            {
                while (
                    curr.Next != null &&
                    curr.Next.Value <= num)
                {
                    curr = curr.Next;
                }

                return InnerSearch(num, curr.Bottom);
            }
        }

        public bool Search(int target)
        {
            return InnerSearch(target, _levels.Last());
        }

        private void InnerAdd(int num, Node curr, out Node added, out bool keepAdding, out int level)
        {
            if (curr.Bottom == null)
            {
                while (
                    curr.Next != null &&
                    curr.Next.Value < num)
                {
                    curr = curr.Next;
                }

                if (curr.Next != null && curr.Next.Value == num)
                {
                    curr.Next.Count++;

                    added = null;
                    keepAdding = false;
                    level = 0;
                }
                else
                {
                    var newNode = new Node(num, 0);

                    var next = curr.Next;
                    newNode.Next = next;
                    curr.Next = newNode;

                    added = newNode;
                    keepAdding = _random.NextDouble() <= 0.5;
                    level = 0;
                }
                return;
            }
            else
            {
                while (
                    curr.Next != null &&
                    curr.Next.Value < num)
                {
                    curr = curr.Next;
                }

                InnerAdd(num, curr.Bottom, out added, out keepAdding, out level);

                if (keepAdding)
                {
                    level++;
                    var newNode = new Node(num, level);

                    newNode.Bottom = added;

                    var next = curr.Next;
                    newNode.Next = next;
                    curr.Next = newNode;

                    added = newNode;
                    keepAdding = _random.NextDouble() <= 0.5;
                }

                return;
            }
        }

        public void Add(int num)
        {
            InnerAdd(num, _levels.Last(), out Node _, out bool _, out int _);
        }

        private bool InnerErase(int num, Node prev, Node curr, out bool removedNode)
        {
            if (curr.Value > num)
            {
                curr = prev.Next;
            }
            while (prev.Next != curr)
            {
                prev = prev.Next;
            }

            if (curr.Bottom == null)
            {
                while (
                    curr.Next != null &&
                    curr.Next.Value <= num)
                {
                    prev = curr;
                    curr = curr.Next;
                }

                if (curr.Value == num)
                {
                    if (curr.Count > 1)
                    {
                        removedNode = false;
                        curr.Count--;
                        return true;
                    }
                    else
                    {
                        removedNode = true;
                        prev.Next = curr.Next;
                        return true;
                    }
                }
                else
                {
                    removedNode = false;
                    return false;
                }
            }
            else
            {
                while (
                    curr.Next != null &&
                    curr.Next.Value <= num)
                {
                    prev = curr;
                    curr = curr.Next;
                }

                bool erased = InnerErase(num, prev.Bottom, curr.Bottom, out removedNode);
                if (curr.Value == num &&
                    removedNode)
                {
                    prev.Next = curr.Next;
                }
                return erased;
            }
        }


        public bool Erase(int num)
        {
            for (int i = _levels.Count - 1; i >= 0; i--)
            {
                var prev = _levels[i];
                var curr = _levels[i].Next;
                // If we have any elements in this level
                if (curr != null)
                {
                    return InnerErase(num, prev, curr, out bool _);
                }
            }
            return false;
        }

        public override string ToString()
        {
            var valuesToIndex = new Dictionary<int, int>();
            var builder = new StringBuilder();

            Node currNode = _levels[0];
            while (currNode != null)
            {
                if (!valuesToIndex.ContainsKey(currNode.Value))
                {
                    valuesToIndex.Add(currNode.Value, builder.Length);
                }
                builder.Append($"{currNode.Value} (x{currNode.Count}) ");

                currNode = currNode.Next;
            }
            builder.AppendLine();

            for (int i = 1; i < _levels.Count; i++)
            {
                var lineBuilder = new StringBuilder();
                currNode = _levels[i];
                while (currNode != null)
                {
                    int index = valuesToIndex[currNode.Value];
                    int padding = index - lineBuilder.Length;

                    lineBuilder.Append(new string(' ', padding));

                    builder.Append($"{currNode.Value} (x{currNode.Count}) ");

                    currNode = currNode.Next;
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
