using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TopCoderCSTest.AcmBased;
using Xunit;

namespace TopCoderCSTest
{
    public interface IAcmStyle
    {
        void Solve(StreamReader input, StreamWriter output);
    }

    public class AcmBasedTester
    {
        [Fact]
        public void CupcakeFactory()
        {
            RunTests<CupcakeFactory>();
        }

        private void RunTests<T>()
            where T : IAcmStyle
        {
            string testName = typeof(T).Name;

            string inputsPath = Path.Combine(testName, "Inputs");
            string outputsPath = Path.Combine(testName, "Outputs");
            var inputFiles = Directory.EnumerateFiles(inputsPath).GetEnumerator();
            var outputFiles = Directory.EnumerateFiles(outputsPath).GetEnumerator();

            Encoding utf8 = new UTF8Encoding(false, true);

            while (inputFiles.MoveNext() && outputFiles.MoveNext())
            {
                IAcmStyle instance = Activator.CreateInstance<T>();

                string inputFile = inputFiles.Current;
                string outputFile = outputFiles.Current;

                Console.WriteLine($"Testing {inputFile} with output {outputFile}");


                FileStream inputStream = File.OpenRead(inputFile);
                var outputStream = new MemoryStream();
                var streamReader = new StreamReader(inputStream, utf8);
                var streamWriter = new StreamWriter(outputStream, utf8);
                instance.Solve(streamReader, streamWriter);
                streamWriter.Flush();
                
                string expectedOutput = File.ReadAllText(outputFile, utf8);
                outputStream.Seek(0, SeekOrigin.Begin);
                string actualOutput = utf8.GetString(outputStream.ToArray());
                Assert.Equal(expectedOutput, actualOutput);
            }
        }
    }
}
