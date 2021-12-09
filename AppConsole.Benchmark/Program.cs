using BenchmarkDotNet.Running;
using System;

namespace AppConsole.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Dominio.Servicos.OperacoesNumericas>();
            Console.Read();
        }
    }
}
