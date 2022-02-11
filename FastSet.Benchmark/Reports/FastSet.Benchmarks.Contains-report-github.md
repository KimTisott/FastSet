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
| FastSet |          1 |            36.11 ns |  0.61 |           120 B |
| HashSet |          1 |            59.44 ns |  1.00 |           208 B |
|         |            |                     |       |                 |
| FastSet |        100 |           958.00 ns |  0.49 |           192 B |
| HashSet |        100 |         1,943.21 ns |  1.00 |         6,040 B |
|         |            |                     |       |                 |
| FastSet |      10000 |        86,561.74 ns |  0.38 |         4,424 B |
| HashSet |      10000 |       227,389.28 ns |  1.00 |       538,696 B |
|         |            |                     |       |                 |
| FastSet |    1000000 |     8,350,605.00 ns |  0.29 |       262,634 B |
| HashSet |    1000000 |    28,552,517.50 ns |  1.00 |    43,111,656 B |
|         |            |                     |       |                 |
| FastSet |  100000000 |   926,355,120.00 ns |  0.32 |    33,556,200 B |
| HashSet |  100000000 | 2,912,273,980.00 ns |  1.00 | 6,136,884,664 B |
