using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.LeetCode.UniquePaths;

namespace Benchmark
{
    /*
    |       Method |  _n |  _m |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
    |------------- |---- |---- |------------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
    |        Magus |  10 |  10 |    296.6 ns |   0.85 ns |   0.75 ns |  1.00 |    0.00 |  0.0739 |      - |     - |     464 B |
    |     Nandhini |  10 |  10 |    104.3 ns |   0.48 ns |   0.45 ns |  0.35 |    0.00 |  0.0139 |      - |     - |      88 B |
    |       Connor |  10 |  10 |    552.0 ns |   1.69 ns |   1.50 ns |  1.86 |    0.01 |  0.1183 |      - |     - |     744 B |
    | ConnorCached |  10 |  10 |    343.8 ns |   1.31 ns |   1.10 ns |  1.16 |    0.00 |  0.1259 |      - |     - |     792 B |
    |        David |  10 |  10 | 24,220.5 ns | 133.79 ns | 118.61 ns | 81.65 |    0.48 |  6.8665 | 0.9460 |     - |  43,256 B |
    |              |     |     |             |           |           |       |         |         |        |       |           |
    |        Magus |  10 | 100 |  2,636.6 ns |  10.90 ns |   9.66 ns |  1.00 |    0.00 |  0.6447 |      - |     - |   4,064 B |
    |     Nandhini |  10 | 100 |    889.1 ns |   2.32 ns |   2.17 ns |  0.34 |    0.00 |  0.0134 |      - |     - |      88 B |
    |       Connor |  10 | 100 |  6,762.2 ns |  31.59 ns |  28.01 ns |  2.56 |    0.01 |  4.1428 |      - |     - |  26,024 B |
    | ConnorCached |  10 | 100 |  3,364.9 ns |  13.73 ns |  12.84 ns |  1.28 |    0.01 |  2.1248 |      - |     - |  13,336 B |
    |        David |  10 | 100 | 24,093.4 ns |  90.86 ns |  84.99 ns |  9.13 |    0.05 |  6.8665 | 0.9460 |     - |  43,256 B |
    |              |     |     |             |           |           |       |         |         |        |       |           |
    |        Magus | 100 |  10 |  2,651.8 ns |   9.81 ns |   9.18 ns |  1.00 |    0.00 |  0.6447 |      - |     - |   4,064 B |
    |     Nandhini | 100 |  10 |  1,136.9 ns |   4.99 ns |   4.67 ns |  0.43 |    0.00 |  0.0706 |      - |     - |     448 B |
    |       Connor | 100 |  10 |  6,701.3 ns |  42.90 ns |  38.03 ns |  2.53 |    0.02 |  4.1428 |      - |     - |  26,024 B |
    | ConnorCached | 100 |  10 |  3,403.5 ns |  21.20 ns |  19.83 ns |  1.28 |    0.01 |  2.1248 |      - |     - |  13,336 B |
    |        David | 100 |  10 | 24,382.7 ns |  83.61 ns |  74.12 ns |  9.19 |    0.04 |  6.8665 | 0.9460 |     - |  43,256 B |
    |              |     |     |             |           |           |       |         |         |        |       |           |
    |        Magus | 100 | 100 | 27,711.3 ns | 222.37 ns | 197.12 ns |  1.00 |    0.00 |  6.3477 |      - |     - |  40,064 B |
    |     Nandhini | 100 | 100 | 11,106.2 ns |  52.05 ns |  46.14 ns |  0.40 |    0.00 |  0.0610 |      - |     - |     448 B |
    |       Connor | 100 | 100 | 16,170.8 ns | 269.95 ns | 252.51 ns |  0.58 |    0.01 | 10.4675 |      - |     - |  65,664 B |
    | ConnorCached | 100 | 100 |  8,592.7 ns |  62.30 ns |  55.23 ns |  0.31 |    0.00 |  5.9814 |      - |     - |  37,616 B |
    |        David | 100 | 100 | 24,086.7 ns | 145.94 ns | 129.37 ns |  0.87 |    0.01 |  6.8665 | 0.9460 |     - |  43,256 B |
    */

    [SimpleJob(RuntimeMoniker.Net60)]
    [MemoryDiagnoser]
    public class BenchmarkUniquePaths
    {
        // We cannot even test large numbers because the trash solution is so trash
        [Params(10, 100)]
        public int _n;
        [Params(10, 100)]
        public int _m;

        [Benchmark(Baseline = true)]
        public void Magus() => new SolutionMagus().UniquePaths(_m, _n);

        [Benchmark]
        public void Nandhini() => new SolutionNandhini().UniquePaths(_m, _n);

        [Benchmark]
        public void Connor() => new SolutionConnor().UniquePaths(_m, _n);

        [Benchmark]
        public void ConnorCached() => new SolutionConnorCached().UniquePaths(_m, _n);

        [Benchmark]
        public void David() => new SolutionDavid().UniquePaths(_m, _n);
    }
}
