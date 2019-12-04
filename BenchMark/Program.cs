using System;
using BenchmarkDotNet.Running;

namespace BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            switch (args[0])
            {
                case "1":
                    Console.WriteLine("Running Enum Extension Vs StringArray Benchmark");
                    var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
                    break;
                case "2":
                    Console.WriteLine("Running string combine Enum Extension Vs StringArray Benchmark");
                    break;
                default:
                    break;
            }


        }
    }
}
