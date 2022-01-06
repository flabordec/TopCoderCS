using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.FirstMissingPositiveInteger;

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        bool[] possibleAnswers = new bool[nums.Length + 2];
        possibleAnswers[0] = true;
        foreach (var num in nums)
        {
            if (num >= 0 && num < possibleAnswers.Length)
            {
                possibleAnswers[num] = true;
            }
        }
        for (int i = 1; i < possibleAnswers.Length; i++)
        {
            if (possibleAnswers[i] == false)
                return i;
        }
        return -1;
    }

    public int FirstMissingPositiveBinarySearch(int[] nums)
    {
        List<int> possibleAnswers = Enumerable.Range(1, nums.Length + 1).ToList();
        foreach (var num in nums)
        {
            int index = possibleAnswers.BinarySearch(num);
            if (index >= 0)
            {
                possibleAnswers.RemoveAt(index);
            }
        }
        return possibleAnswers.First();
    }
}