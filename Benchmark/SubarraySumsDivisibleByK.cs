using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Engines;
using SubarraySumsDivisibleByK;

namespace Benchmark
{
    /*
    |               Method |  n |        Mean |     Error |    StdDev |
    |--------------------- |--- |------------:|----------:|----------:|
    |      RemaindersArray |  5 |    24.85 ns |  0.120 ns |  0.106 ns |
    | RemaindersDictionary |  5 |   185.67 ns |  0.727 ns |  0.680 ns |
    |   RemaindersForLoops |  5 |    34.29 ns |  0.236 ns |  0.184 ns |
    |      RemaindersArray | 50 |   202.87 ns |  0.667 ns |  0.624 ns |
    | RemaindersDictionary | 50 | 1,302.12 ns |  4.487 ns |  3.978 ns |
    |   RemaindersForLoops | 50 | 2,581.89 ns | 17.075 ns | 14.259 ns |
    */

    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkSubarraySumsDivisibleByK
    {
        // We cannot even test large numbers because the trash solution is so trash
        public int[] nums;
        public int k = 5;

        [Params(5, 50)]
        public int n;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);

            nums = new int[n];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = random.Next(-10000, 10000);
            }
        }

        [Benchmark]
        public void RemaindersArray() => new Solution().SubarraysDivByKRemaindersArray(nums, k);

        [Benchmark]
        public void RemaindersDictionary() => new Solution().SubarraysDivByKRemaindersDict(nums, k);

        [Benchmark]
        public void RemaindersForLoops() => new Solution().SubarraysDivByKForLoops(nums, k);
    }
}
