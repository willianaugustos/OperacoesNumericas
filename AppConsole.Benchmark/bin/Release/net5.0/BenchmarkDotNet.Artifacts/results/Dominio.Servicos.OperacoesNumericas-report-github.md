``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT


```
|               Method | numero |        Mean |      Error |     StdDev |
|--------------------- |------- |------------:|-----------:|-----------:|
|  **ObterDivisoresBruto** |      **1** |    **18.91 ns** |   **0.116 ns** |   **0.108 ns** |
| ObterDivisoresPadrao |      1 |          NA |         NA |         NA |
|  **ObterDivisoresBruto** |     **11** |    **94.28 ns** |   **0.420 ns** |   **0.351 ns** |
| ObterDivisoresPadrao |     11 |          NA |         NA |         NA |
|  **ObterDivisoresBruto** |     **30** |   **180.51 ns** |   **2.032 ns** |   **1.900 ns** |
| ObterDivisoresPadrao |     30 |          NA |         NA |         NA |
|  **ObterDivisoresBruto** |    **641** | **2,986.99 ns** |  **33.510 ns** |  **29.706 ns** |
| ObterDivisoresPadrao |    641 |          NA |         NA |         NA |
|  **ObterDivisoresBruto** |   **1510** | **4,329.32 ns** |  **86.200 ns** | **109.015 ns** |
| ObterDivisoresPadrao |   1510 |          NA |         NA |         NA |
|  **ObterDivisoresBruto** |   **1511** | **7,063.89 ns** | **140.714 ns** | **138.200 ns** |
| ObterDivisoresPadrao |   1511 |          NA |         NA |         NA |

Benchmarks with issues:
  OperacoesNumericas.ObterDivisoresPadrao: DefaultJob [numero=1]
  OperacoesNumericas.ObterDivisoresPadrao: DefaultJob [numero=11]
  OperacoesNumericas.ObterDivisoresPadrao: DefaultJob [numero=30]
  OperacoesNumericas.ObterDivisoresPadrao: DefaultJob [numero=641]
  OperacoesNumericas.ObterDivisoresPadrao: DefaultJob [numero=1510]
  OperacoesNumericas.ObterDivisoresPadrao: DefaultJob [numero=1511]
