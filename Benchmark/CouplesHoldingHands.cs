using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.LeetCode.CouplesHoldingHands;

namespace Benchmark
{
    /*
    |          Method |    _n |           Mean |        Error |       StdDev |  Ratio | RatioSD |
    |---------------- |------ |---------------:|-------------:|-------------:|-------:|--------:|
    |           Magus |   100 |       112.7 ns |      0.91 ns |      0.85 ns |   1.00 |    0.00 |
    |         ForLoop |   100 |       367.2 ns |      1.73 ns |      1.54 ns |   3.26 |    0.03 |
    |  DictionaryJeff |   100 |     1,322.1 ns |      9.60 ns |      8.98 ns |  11.73 |    0.14 |
    | DictionaryMagus |   100 |     1,367.4 ns |     11.86 ns |     11.10 ns |  12.13 |    0.13 |
    |                 |       |                |              |              |        |         |
    |           Magus |  1000 |     1,474.2 ns |     16.32 ns |     14.47 ns |   1.00 |    0.00 |
    |         ForLoop |  1000 |             NA |           NA |           NA |      ? |       ? |
    |  DictionaryJeff |  1000 |    12,817.4 ns |     51.30 ns |     47.98 ns |   8.70 |    0.10 |
    | DictionaryMagus |  1000 |    13,125.0 ns |    193.36 ns |    180.87 ns |   8.92 |    0.14 |
    |                 |       |                |              |              |        |         |
    |           Magus | 10000 |    25,879.6 ns |     70.96 ns |     66.37 ns |   1.00 |    0.00 |
    |         ForLoop | 10000 | 4,237,872.9 ns | 11,360.37 ns | 10,626.50 ns | 163.75 |    0.50 |
    |  DictionaryJeff | 10000 |   275,785.3 ns |  2,224.67 ns |  1,972.11 ns |  10.66 |    0.07 |
    | DictionaryMagus | 10000 |   273,579.4 ns |  2,606.36 ns |  2,437.99 ns |  10.57 |    0.09 |
    */

    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkCouplesHoldingHands
    {
        [Params(100, 1000, 10000)]
        public int _n;
        public int[] _couples;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);
            _couples = Enumerable.Range(0, _n).ToArray();
            for (int i = _couples.Length - 1; i >= 0; i--)
            {
                int j = random.Next(0, i);
                int temp = _couples[i];
                _couples[i] = _couples[j];
                _couples[j] = temp;
            }
        }

        [Benchmark(Baseline = true)]
        public void Magus() => new Solution().MinSwapsCouples(_couples);

        // Way slower, do not run regularly
        //[Benchmark]
        //public void ForLoop() => new SolutionForLoop().MinSwapsCouples(_couples);

        [Benchmark]
        public void DictionaryJeff() => new SolutionDictionaryJeff().MinSwapsCouples(_couples);

        [Benchmark]
        public void DictionaryMagus() => new SolutionDictionaryJeff().MinSwapsCouples(_couples);
    }
}
