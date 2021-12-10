``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT


```
|               Method | numero |        Mean |     Error |    StdDev |
|--------------------- |------- |------------:|----------:|----------:|
|  **ObterDivisoresBruto** |      **1** |    **19.55 ns** |  **0.158 ns** |  **0.132 ns** |
| ObterDivisoresPadrao |      1 |   198.78 ns |  3.971 ns |  4.078 ns |
|  **ObterDivisoresBruto** |     **11** |    **89.47 ns** |  **0.569 ns** |  **0.532 ns** |
| ObterDivisoresPadrao |     11 |   361.90 ns |  6.405 ns |  6.578 ns |
|  **ObterDivisoresBruto** |     **30** |   **166.01 ns** |  **2.301 ns** |  **1.921 ns** |
| ObterDivisoresPadrao |     30 |   832.49 ns | 15.916 ns | 17.690 ns |
|  **ObterDivisoresBruto** |    **641** | **3,152.00 ns** | **17.911 ns** | **16.754 ns** |
| ObterDivisoresPadrao |    641 | 1,298.82 ns | 22.476 ns | 19.925 ns |
|  **ObterDivisoresBruto** |   **1510** | **4,205.03 ns** | **25.323 ns** | **23.687 ns** |
| ObterDivisoresPadrao |   1510 | 1,259.97 ns |  7.069 ns |  6.266 ns |
|  **ObterDivisoresBruto** |   **1511** | **7,356.95 ns** | **32.185 ns** | **26.876 ns** |
| ObterDivisoresPadrao |   1511 | 2,512.88 ns | 22.751 ns | 20.168 ns |
