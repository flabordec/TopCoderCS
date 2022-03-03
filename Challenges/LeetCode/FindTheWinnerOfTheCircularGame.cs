using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.FindTheWinnerOfTheCircularGame
{
    public class ListSolution
    {
        public int FindTheWinner(int n, int k)
        {
            var numbers = new List<int>(Enumerable.Range(1, n));
            int ix = 0;
            while (numbers.Count > 1)
            {
                ix = (ix + k - 1) % numbers.Count;
                numbers.RemoveAt(ix);
            }
            return numbers[0];
        }
    }

    public class LinkedListSolution
    {
        public int FindTheWinner(int n, int k)
        {
            var numbers = new LinkedList<int>(Enumerable.Range(1, n));
            LinkedListNode<int> node = numbers.First;
            LinkedListNode<int> del = null;
            int lv = 0;
            while (numbers.Count > 1)
            {
                for (int i = 0; i < (k - 1); i++)
                {
                    node = Next(node);
                }
                lv = node.Value;
                del = node;
                node = Next(node);
                numbers.Remove(del);
            }
            return numbers.First.Value;
        }

        public LinkedListNode<int> Next(LinkedListNode<int> node)
        {
            if (node.Next != null)
                return node.Next;
            else
                return node.List.First;
        }
    }

    public class ArraySolution
    {
        public int FindTheWinner(int n, int k)
        {
            var numbers = new bool[n];
            int ix = 0;
            int lv = 0;
            int count = n;
            while (count > 1)
            {
                for (int i = 0; i < k - 1; i++)
                {
                    Next(numbers, ref ix);
                }

                numbers[ix] = true;
                count--;

                Next(numbers, ref ix);
                lv = ix;
            }
            return lv + 1;
        }

        public void Next(bool[] numbers, ref int ix)
        {
            do
            {
                ix = (ix + 1) % numbers.Length;
            } while (numbers[ix]);
        }
    }

    public class CustomLinkedListSolution
    {
        public class Node
        {
            public Node Next { get; set; }
            public int Value { get; }

            public Node(int value)
            {
                Value = value;
            }
        }

        public int FindTheWinner(int n, int k)
        {
            if (n == 1)
                return 1;

            Node head = new Node(1);
            Node prev = head;
            Node curr = null;
            for (int i = 2; i <= n; i++)
            {
                curr = new Node(i);
                prev.Next = curr;
                prev = curr;
            }

            curr.Next = head;

            Node tail = curr;
            prev = tail;
            curr = head;

            int count = n;
            while (count > 1)
            {
                for (int i = 0; i < (k - 1); i++)
                {
                    prev = curr;
                    curr = curr.Next;
                }

                prev.Next = curr.Next;
                curr = curr.Next;
                count--;
            }
            return curr.Value;
        }
    }

    public class CompressingListSolution
    {
        public int FindTheWinner(int n, int k)
        {
            int[] numbers = Enumerable.Range(1, n).ToArray();

            int ix = 0;
            int count = n;
            int currentCount = n;
            while (count > 1)
            {
                ix = (ix + k - 1);
                CompressIfRequired(numbers, count, ref currentCount, ref ix);

                numbers[ix] = -1;
                count--;

                ix++;
                CompressIfRequired(numbers, count, ref currentCount, ref ix);
            }
            return numbers.First(x => x > 0);
        }

        public void CompressIfRequired(int[] numbers, int count, ref int currentCount, ref int ix)
        {
            if (ix >= currentCount)
            {
                int next = 0;
                for (int i = 0; i < count; i++)
                {
                    while (numbers[next] == -1)
                    {
                        next++;
                    }
                    numbers[i] = numbers[next];
                    next++;
                }
                int loops = ((ix - currentCount) / currentCount);
                ix = (ix + loops) % currentCount;
                currentCount = count;
            }
        }
    }
}
