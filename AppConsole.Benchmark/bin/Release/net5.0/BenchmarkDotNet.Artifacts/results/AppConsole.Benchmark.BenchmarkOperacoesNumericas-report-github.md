``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT


```
|                     Method | numero |       Mean |    Error |   StdDev |
|--------------------------- |------- |-----------:|---------:|---------:|
|             ObterDivisores |    360 |   696.6 ns |  9.27 ns |  8.67 ns |
| ObterDivisoresNaoOtimizado |    360 | 1,174.4 ns | 14.19 ns | 13.27 ns |
