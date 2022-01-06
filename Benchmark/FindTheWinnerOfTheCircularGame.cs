using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopCoderCS.LeetCode.FindTheWinnerOfTheCircularGame;

namespace Benchmark
{
    /*
    |           Method |  _k |         Mean |      Error |     StdDev |  Ratio | RatioSD |
    |----------------- |---- |-------------:|-----------:|-----------:|-------:|--------:|
    |             List |   5 |    14.495 us |  0.0729 us |  0.0646 us |   1.00 |    0.00 |
    |       LinkedList |   5 |    13.680 us |  0.0841 us |  0.0786 us |   0.94 |    0.01 |
    |        ArrayList |   5 |    87.847 us |  0.7073 us |  0.6616 us |   6.06 |    0.06 |
    | CustomLinkedList |   5 |     4.590 us |  0.0322 us |  0.0269 us |   0.32 |    0.00 |
    |  CompressingList |   5 |     5.051 us |  0.0240 us |  0.0225 us |   0.35 |    0.00 |
    |                  |     |              |            |            |        |         |
    |             List |  50 |    14.643 us |  0.0668 us |  0.0625 us |   1.00 |    0.00 |
    |       LinkedList |  50 |    56.894 us |  0.5379 us |  0.5032 us |   3.89 |    0.03 |
    |        ArrayList |  50 | 1,007.685 us |  3.1920 us |  2.8297 us |  68.80 |    0.36 |
    | CustomLinkedList |  50 |    24.589 us |  0.0994 us |  0.0882 us |   1.68 |    0.01 |
    |  CompressingList |  50 |    31.334 us |  0.0925 us |  0.0865 us |   2.14 |    0.01 |
    |                  |     |              |            |            |        |         |
    |             List | 500 |    14.630 us |  0.0988 us |  0.0876 us |   1.00 |    0.00 |
    |       LinkedList | 500 |   458.178 us |  2.4979 us |  2.3366 us |  31.32 |    0.30 |
    |        ArrayList | 500 | 9,386.016 us | 74.1738 us | 69.3822 us | 641.99 |    5.58 |
    | CustomLinkedList | 500 |   221.447 us |  0.6650 us |  0.5553 us |  15.13 |    0.07 |
    |  CompressingList | 500 |    93.706 us |  0.5112 us |  0.4782 us |   6.41 |    0.04 |
    */

    [SimpleJob(RuntimeMoniker.Net50)]
    public class BenchmarkFindTheWinnerOfTheCircularGame
    {
        public int _n = 500;

        [Params(5, 50, 500)]
        public int _k;

        [Benchmark(Baseline = true)]
        public void List() => new ListSolution().FindTheWinner(_n, _k);

        [Benchmark]
        public void LinkedList() => new LinkedListSolution().FindTheWinner(_n, _k);

        [Benchmark]
        public void ArrayList() => new ArraySolution().FindTheWinner(_n, _k);

        [Benchmark]
        public void CustomLinkedList() => new CustomLinkedListSolution().FindTheWinner(_n, _k);

        [Benchmark]
        public void CompressingList() => new CompressingListSolution().FindTheWinner(_n, _k);
    }
}
