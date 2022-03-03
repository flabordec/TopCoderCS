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
    |      Method |   _n |   _m |     Mean |   Error |  StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------ |----- |----- |---------:|--------:|--------:|------:|--------:|------:|------:|------:|----------:|
    | NPlusMSpace | 5000 | 5000 | 324.0 ms | 5.19 ms | 4.86 ms |  0.93 |    0.02 |     - |     - |     - |     13 KB |
    |      NSpace | 5000 | 5000 | 349.0 ms | 6.61 ms | 6.49 ms |  1.00 |    0.00 |     - |     - |     - |     11 KB |
    */

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkSetMatrixZeroes
    {
        // We cannot even test large numbers because the trash solution is so trash
        [Params(5000)]
        public int _n;
        [Params(5000)]
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

        // Runs out of memory while testing
        //[Benchmark(Baseline = true)]
        //public void MemoryHog() => new SolutionMemoryHog().SetZeroes(_matrix);

        [Benchmark]
        public void NPlusMSpace() => new SolutionNPlusMSpace().SetZeroes(_matrix);

        [Benchmark(Baseline = true)]
        public void NSpace() => new SolutionNSpace().SetZeroes(_matrix);
    }
}
