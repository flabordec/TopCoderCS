using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode
{
    public class Solution_DailyTemperatures
    {
        public int[] DailyTemperatures(int[] T)
        {
            List<int>[] tempMapping = new List<int>[101 - 30];
            for (int i = 0; i < tempMapping.Length; i++)
                tempMapping[i] = new List<int>();

            for (int i = 0; i < T.Length; i++)
            {
                int t = T[i] - 30;
                tempMapping[t].Add(i);
            }

            //for (int i = 0; i < tempMapping.Length; i++)
            //{
            //    if (tempMapping[i].Any())
            //        Console.WriteLine($"{i} => {string.Join(", ", tempMapping[i])}");
            //}

            int[] temps = new int[T.Length];
            for (int i = 0; i < T.Length; i++)
            {
                int t = T[i] - 30;
                //Console.WriteLine("-------------");
                //Console.WriteLine($"Finding index {i} temperature {t}");

                int best = int.MaxValue;
                for (int j = t + 1; j < tempMapping.Length; j++)
                {
                    if (tempMapping[j].Any())
                    {
                        //Console.WriteLine($"Found temperature {j}");
                        int ni = BinarySearch(tempMapping[j], i);
                        //Console.WriteLine($"Found next index {tempMapping[j][ni]} from index {i}");
                        if (tempMapping[j][ni] - i > 0)
                        {
                            best = Math.Min(best, tempMapping[j][ni] - i);
                        }
                        else if (tempMapping[j].Count > ni + 1 && tempMapping[j][ni + 1] - i > 0)
                        {
                            best = Math.Min(best, tempMapping[j][ni + 1] - i);
                        }
                    }
                }
                if (best != int.MaxValue)
                    temps[i] = best;
                else
                    temps[i] = 0;

            }
            return temps;
        }

        public int BinarySearch(List<int> array, int value)
        {
            //Console.WriteLine($"Searching for {value} in [{string.Join(", ", array)}]");

            int l = 0;
            int r = array.Count - 1;
            int mid = -1;
            while (l <= r)
            {
                mid = (l + r) / 2;
                //Console.WriteLine($"Testing {l},{r} => {mid}");
                if (array[mid] < value)
                {
                    l = mid + 1;
                }
                else if (array[mid] > value)
                {
                    r = mid - 1;
                }
                else
                {
                    //Console.WriteLine($"Found {mid}");
                    return mid;
                }
            }
            //Console.WriteLine($"Not found {mid}");
            return mid;
        }
    }
}
