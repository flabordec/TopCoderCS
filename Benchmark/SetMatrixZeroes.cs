using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Engines;
using Challenges.LeetCode.SetMatrixZeroes;

namespace Benchmark
{
    /*
    |      Method |  _n |  _m |            Mean |        Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------ |---- |---- |----------------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
    |   MemoryHog |  10 |  50 |     25,493.8 ns |     92.47 ns |     86.49 ns |  30.38 |    0.18 | 0.1221 |     - |     - |     928 B |
    | NPlusMSpace |  10 |  50 |        815.2 ns |      1.79 ns |      1.49 ns |   0.97 |    0.01 | 0.0229 |     - |     - |     144 B |
    |      NSpace |  10 |  50 |        839.0 ns |      4.72 ns |      4.18 ns |   1.00 |    0.00 | 0.0162 |     - |     - |     104 B |
    |      Clever |  10 |  50 |      1,386.6 ns |      3.33 ns |      2.78 ns |   1.65 |    0.01 | 0.0134 |     - |     - |      88 B |
    |             |     |     |                 |              |              |        |         |        |       |       |           |
    |   MemoryHog |  10 | 200 |    316,089.0 ns |  1,164.83 ns |    972.69 ns |  94.06 |    0.42 |      - |     - |     - |   2,368 B |
    | NPlusMSpace |  10 | 200 |      3,225.8 ns |      8.88 ns |      8.31 ns |   0.96 |    0.00 | 0.0458 |     - |     - |     288 B |
    |      NSpace |  10 | 200 |      3,359.5 ns |     10.44 ns |      9.77 ns |   1.00 |    0.00 | 0.0381 |     - |     - |     248 B |
    |      Clever |  10 | 200 |      5,586.1 ns |     15.99 ns |     14.96 ns |   1.66 |    0.01 | 0.0153 |     - |     - |     112 B |
    |             |     |     |                 |              |              |        |         |        |       |       |           |
    |   MemoryHog | 200 |  50 |  1,801,375.5 ns |  3,935.19 ns |  3,680.98 ns | 111.95 |    0.49 | 1.9531 |     - |     - |  17,649 B |
    | NPlusMSpace | 200 |  50 |     15,472.1 ns |    113.45 ns |    100.57 ns |   0.96 |    0.01 | 0.0305 |     - |     - |     328 B |
    |      NSpace | 200 |  50 |     16,091.8 ns |     69.18 ns |     64.72 ns |   1.00 |    0.00 |      - |     - |     - |     104 B |
    |      Clever | 200 |  50 |     27,390.3 ns |     81.90 ns |     72.60 ns |   1.70 |    0.01 |      - |     - |     - |      88 B |
    |             |     |     |                 |              |              |        |         |        |       |       |           |
    |   MemoryHog | 200 | 200 | 11,140,247.5 ns | 36,439.60 ns | 34,085.63 ns | 153.40 |    1.56 |      - |     - |     - |  46,450 B |
    | NPlusMSpace | 200 | 200 |     68,339.7 ns |    378.64 ns |    295.62 ns |   0.94 |    0.01 |      - |     - |     - |     472 B |
    |      NSpace | 200 | 200 |     72,625.8 ns |    694.39 ns |    649.53 ns |   1.00 |    0.00 |      - |     - |     - |     248 B |
    |      Clever | 200 | 200 |    115,896.4 ns |    247.22 ns |    206.44 ns |   1.60 |    0.02 |      - |     - |     - |     112 B |
    */

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkSetMatrixZeroes
    {
        // We cannot even test large numbers because the trash solution is so trash
        [Params(10, 200)]
        public int _n;
        [Params(50, 200)]
        public int _m;
        
        public int[][] _matrix;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);
            _matrix = new int[_n][];
            for (int i = 0; i < _n; i++)
            {
                _matrix[i] = new int[_m];
                for (int j = 0; j < _m; j++)
                {
                    _matrix[i][j] = random.Next(-2, 2);
                }
            }
        }

        [Benchmark]
        public void MemoryHog() => new SolutionMemoryHog().SetZeroes(_matrix);

        [Benchmark]
        public void NPlusMSpace() => new SolutionNPlusMSpace().SetZeroes(_matrix);

        [Benchmark(Baseline = true)]
        public void NSpace() => new SolutionNSpace().SetZeroes(_matrix);

        [Benchmark]
        public void Clever() => new SolutionClever().SetZeroes(_matrix);
    }
}
