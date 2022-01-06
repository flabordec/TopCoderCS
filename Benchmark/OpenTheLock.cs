using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopCoderCS.LeetCode.OpenTheLock;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.Net50)]
    public class BenchmarkOpenTheLock
    {
        /*
            |                   Method | _target |        Mean |     Error |    StdDev |  Ratio | RatioSD |
            |------------------------- |-------- |------------:|----------:|----------:|-------:|--------:|
            |                UsingInts |    3467 | 1,277.98 us |  2.975 us |  2.322 us |  30.00 |    0.11 |
            |        UsingIntsAndAStar |    3467 |    98.63 us |  0.223 us |  0.209 us |   2.31 |    0.01 |
            | UsingIntsAndAStarPrecalc |    3467 |    42.63 us |  0.193 us |  0.180 us |   1.00 |    0.00 |
            |             UsingStrings |    3467 | 4,591.20 us | 45.613 us | 42.666 us | 107.69 |    0.99 |
            |                          |         |             |           |           |        |         |
            |                UsingInts |    5555 | 1,391.90 us |  4.001 us |  3.742 us |   0.66 |    0.00 |
            |        UsingIntsAndAStar |    5555 | 6,124.51 us | 20.368 us | 19.052 us |   2.90 |    0.01 |
            | UsingIntsAndAStarPrecalc |    5555 | 2,108.49 us |  7.422 us |  6.942 us |   1.00 |    0.00 |
            |             UsingStrings |    5555 | 4,935.78 us | 38.552 us | 36.062 us |   2.34 |    0.02 |
         */

        [Params("5555", "3467")]
        public string _target;

        [Benchmark]
        public void UsingInts() => new SolutionInts().OpenLock(new string[0], _target);

        [Benchmark]
        public void UsingIntsAndAStar() => new SolutionAStar().OpenLock(new string[0], _target);

        [Benchmark(Baseline = true)]
        public void UsingIntsAndAStarPrecalc() => new SolutionAStarPrecalc().OpenLock(new string[0], _target);

        [Benchmark]
        public void UsingStrings() => new SolutionUsingStrings().OpenLock(new string[0], _target);
    }
}
