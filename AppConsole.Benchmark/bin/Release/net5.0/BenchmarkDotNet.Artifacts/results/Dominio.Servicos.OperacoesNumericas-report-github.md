``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT


```
|              Method | numero |        Mean |    Error |   StdDev |
|-------------------- |------- |------------:|---------:|---------:|
| **ObterDivisoresBruto** |      **1** |    **21.34 ns** | **0.219 ns** | **0.194 ns** |
|      ObterDivisores |      1 |   198.78 ns | 1.697 ns | 1.587 ns |
| **ObterDivisoresBruto** |     **11** |   **101.12 ns** | **1.419 ns** | **1.327 ns** |
|      ObterDivisores |     11 |   360.45 ns | 4.968 ns | 4.647 ns |
| **ObterDivisoresBruto** |     **30** |   **226.98 ns** | **1.102 ns** | **1.031 ns** |
|      ObterDivisores |     30 |   846.57 ns | 7.562 ns | 7.073 ns |
| **ObterDivisoresBruto** |    **641** | **1,717.27 ns** | **9.196 ns** | **8.152 ns** |
|      ObterDivisores |    641 | 1,215.04 ns | 9.238 ns | 8.189 ns |
