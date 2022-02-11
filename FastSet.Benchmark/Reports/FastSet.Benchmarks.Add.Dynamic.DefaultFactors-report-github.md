``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1526 (21H2)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-QIBBAB : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

IterationCount=5  LaunchCount=1  WarmupCount=5  

```
|  Method | Iterations |                Mean | Ratio |       Allocated |
|-------- |----------- |--------------------:|------:|----------------:|
| FastSet |          1 |            18.10 ns |  0.69 |            80 B |
| HashSet |          1 |            26.42 ns |  1.00 |           168 B |
|         |            |                     |       |                 |
| FastSet |        100 |           645.13 ns |  0.56 |           208 B |
| HashSet |        100 |         1,152.21 ns |  1.00 |         6,000 B |
|         |            |                     |       |                 |
| FastSet |      10000 |        57,118.35 ns |  0.37 |         4,384 B |
| HashSet |      10000 |       156,425.28 ns |  1.00 |       538,656 B |
|         |            |                     |       |                 |
| FastSet |    1000000 |     5,782,393.98 ns |  0.28 |       524,787 B |
| HashSet |    1000000 |    20,711,737.19 ns |  1.00 |    43,111,526 B |
|         |            |                     |       |                 |
| FastSet |  100000000 |   574,871,225.00 ns |  0.28 |    33,556,160 B |
| HashSet |  100000000 | 2,058,763,225.00 ns |  1.00 | 6,136,884,336 B |
