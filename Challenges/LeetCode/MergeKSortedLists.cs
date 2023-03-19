using Challenges.LeetCode.AddTwoNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.MergeKSortedLists
{

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            var queue = new PriorityQueue<ListNode, int>();
            foreach (var list in lists)
            {
                if (list != null)
                    queue.Enqueue(list, list.val);
            }

            ListNode head = new ListNode();
            ListNode curr = head;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                var next = new ListNode(node.val);
                curr.next = next;
                curr = next;

                if (node.next != null)
                {
                    queue.Enqueue(node.next, node.next.val);
                }
            }
            return head.next;
        }
    }
}