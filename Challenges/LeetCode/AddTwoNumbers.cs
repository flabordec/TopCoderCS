using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.AddTwoNumbers
{

	// Definition for singly-linked list.
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			int carry = 0;

			ListNode result = null;
			ListNode currNode = null;
			ListNode n1 = l1;
			ListNode n2 = l2;
			while (n1 != null || n2 != null)
			{
				int currValue = 0;
				if (n1 != null)
					currValue += n1.val;
				if (n2 != null)
					currValue += n2.val;
				currValue += carry;

				carry = 0;
				if (currValue >= 10)
				{
					currValue -= 10;
					carry += 1;
				}

				ListNode next = new ListNode(currValue);
				// If the head is not set, set it
				if (result == null)
					result = next;
				if (currNode != null)
					currNode.next = next;
				currNode = next;

				if (n1 != null)
					n1 = n1.next;
				if (n2 != null)
					n2 = n2.next;
			}

			if (carry != 0)
			{
				ListNode next = new ListNode(carry);
				// If the head is not set, set it
				if (result == null)
					result = next;
				if (currNode != null)
					currNode.next = next;
			}

			return result;
		}
	}
}
