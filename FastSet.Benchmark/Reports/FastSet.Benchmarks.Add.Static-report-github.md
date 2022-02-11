``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1526 (21H2)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-OXCKMP : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

IterationCount=5  LaunchCount=1  WarmupCount=5  

```
|  Method | Iterations |              Mean | Ratio |       Allocated |
|-------- |----------- |------------------:|------:|----------------:|
| FastSet |          1 |          19.69 ns |  0.73 |            80 B |
| HashSet |          1 |          27.05 ns |  1.00 |           168 B |
|         |            |                   |       |                 |
| FastSet |        100 |         452.26 ns |  0.76 |            88 B |
| HashSet |        100 |         597.63 ns |  1.00 |         1,832 B |
|         |            |                   |       |                 |
| FastSet |      10000 |      39,199.78 ns |  0.44 |         1,328 B |
| HashSet |      10000 |      88,243.99 ns |  1.00 |       161,781 B |
|         |            |                   |       |                 |
| FastSet |    1000000 |   3,870,848.24 ns |  0.42 |       125,086 B |
| HashSet |    1000000 |   9,051,529.69 ns |  1.00 |    18,603,236 B |
|         |            |                   |       |                 |
| FastSet |  100000000 | 403,221,640.00 ns |  0.49 |    12,503,232 B |
| HashSet |  100000000 | 816,822,275.00 ns |  1.00 | 1,600,001,048 B |
