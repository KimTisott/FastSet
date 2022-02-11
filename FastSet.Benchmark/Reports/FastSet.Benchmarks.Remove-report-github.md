``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1526 (21H2)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-OXCKMP : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

IterationCount=5  LaunchCount=1  WarmupCount=5  

```
|  Method | Iterations |                Mean | Ratio |       Allocated |
|-------- |----------- |--------------------:|------:|----------------:|
| FastSet |          1 |            39.06 ns |  0.64 |           120 B |
| HashSet |          1 |            60.84 ns |  1.00 |           208 B |
|         |            |                     |       |                 |
| FastSet |        100 |         1,107.09 ns |  0.52 |           192 B |
| HashSet |        100 |         2,122.71 ns |  1.00 |         6,040 B |
|         |            |                     |       |                 |
| FastSet |      10000 |       113,139.87 ns |  0.47 |         4,424 B |
| HashSet |      10000 |       239,808.18 ns |  1.00 |       538,696 B |
|         |            |                     |       |                 |
| FastSet |    1000000 |    11,668,520.62 ns |  0.40 |       262,634 B |
| HashSet |    1000000 |    29,497,806.56 ns |  1.00 |    43,111,656 B |
|         |            |                     |       |                 |
| FastSet |  100000000 | 1,184,087,220.00 ns |  0.40 |    33,556,200 B |
| HashSet |  100000000 | 2,999,696,200.00 ns |  1.00 | 6,136,884,376 B |
