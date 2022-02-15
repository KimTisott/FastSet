# Benchmarks

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1526 (21H2)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-ACSSVR : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

IterationCount=5  LaunchCount=1  WarmupCount=5  

```

- [Add](#add)
  - [Dynamic](#dynamic)
    - [Custom Factors](#custom-factors)
    - [Default Factors](#default-factors)
  - [Static](#static)
- [Contains](#contains)
- [Remove](#remove)

## Add

### Dynamic

#### Custom Factors

Not supported by HashSet.

|  Method | Growth | Load | Iterations |              Mean |    Allocated |
|-------- |------- |----- |----------- |------------------:|-------------:|
| FastSet |      2 |  0.5 |          1 |          18.12 ns |         80 B |
| FastSet |      2 |  0.5 |        100 |         647.34 ns |        208 B |
| FastSet |      2 |  0.5 |      10000 |      57,543.09 ns |      8,504 B |
| FastSet |      2 |  0.5 |    1000000 |   5,845,384.96 ns |    524,787 B |
| FastSet |      2 |  0.5 |  100000000 | 583,286,360.00 ns | 67,110,616 B |
|         |        |      |            |                   |              |
| FastSet |      2 | 0.75 |          1 |          18.71 ns |         80 B |
| FastSet |      2 | 0.75 |        100 |         700.90 ns |        208 B |
| FastSet |      2 | 0.75 |      10000 |      60,208.20 ns |      4,384 B |
| FastSet |      2 | 0.75 |    1000000 |   5,888,722.97 ns |    524,787 B |
| FastSet |      2 | 0.75 |  100000000 | 578,978,880.00 ns | 33,556,160 B |
|         |        |      |            |                   |              |
| FastSet |      2 |    1 |          1 |          18.53 ns |         80 B |
| FastSet |      2 |    1 |        100 |         630.58 ns |        152 B |
| FastSet |      2 |    1 |      10000 |      57,300.21 ns |      4,384 B |
| FastSet |      2 |    1 |    1000000 |   5,770,361.72 ns |    262,595 B |
| FastSet |      2 |    1 |  100000000 | 574,389,460.00 ns | 33,556,160 B |
|         |        |      |            |                   |              |
| FastSet |      5 |  0.5 |          1 |          18.19 ns |         80 B |
| FastSet |      5 |  0.5 |        100 |         651.46 ns |        256 B |
| FastSet |      5 |  0.5 |      10000 |      57,057.20 ns |      3,312 B |
| FastSet |      5 |  0.5 |    1000000 |   5,748,039.84 ns |    390,929 B |
| FastSet |      5 |  0.5 |  100000000 | 572,855,940.00 ns | 48,829,272 B |
|         |        |      |            |                   |              |
| FastSet |      5 | 0.75 |          1 |          17.88 ns |         80 B |
| FastSet |      5 | 0.75 |        100 |         604.73 ns |        128 B |
| FastSet |      5 | 0.75 |      10000 |      57,091.80 ns |      3,312 B |
| FastSet |      5 | 0.75 |    1000000 |   5,719,596.48 ns |    390,929 B |
| FastSet |      5 | 0.75 |  100000000 | 579,469,500.00 ns | 48,829,272 B |
|         |        |      |            |                   |              |
| FastSet |      5 |    1 |          1 |          19.87 ns |         80 B |
| FastSet |      5 |    1 |        100 |         613.15 ns |        128 B |
| FastSet |      5 |    1 |      10000 |      58,491.63 ns |      3,312 B |
| FastSet |      5 |    1 |    1000000 |   5,744,415.04 ns |    390,929 B |
| FastSet |      5 |    1 |  100000000 | 594,256,880.00 ns | 48,829,272 B |
|         |        |      |            |                   |              |
| FastSet |     10 |  0.5 |          1 |          17.90 ns |         80 B |
| FastSet |     10 |  0.5 |        100 |         614.32 ns |        144 B |
| FastSet |     10 |  0.5 |      10000 |      57,334.65 ns |      4,592 B |
| FastSet |     10 |  0.5 |    1000000 |   5,752,607.42 ns |    444,683 B |
| FastSet |     10 |  0.5 |  100000000 | 579,297,380.00 ns | 44,445,480 B |
|         |        |      |            |                   |              |
| FastSet |     10 | 0.75 |          1 |          18.14 ns |         80 B |
| FastSet |     10 | 0.75 |        100 |         607.48 ns |        144 B |
| FastSet |     10 | 0.75 |      10000 |      57,486.59 ns |      4,592 B |
| FastSet |     10 | 0.75 |    1000000 |   5,772,828.28 ns |    444,683 B |
| FastSet |     10 | 0.75 |  100000000 | 576,111,980.00 ns | 44,445,480 B |
|         |        |      |            |                   |              |
| FastSet |     10 |    1 |          1 |          17.92 ns |         80 B |
| FastSet |     10 |    1 |        100 |         601.43 ns |        144 B |
| FastSet |     10 |    1 |      10000 |      57,135.45 ns |      4,592 B |
| FastSet |     10 |    1 |    1000000 |   5,745,999.53 ns |    444,683 B |
| FastSet |     10 |    1 |  100000000 | 582,735,580.00 ns | 44,445,480 B |

#### Default Factors

HashSet defaults:
- Growth = 2;
- Load = 0.75.

|  Method | Iterations |                Mean | Ratio |       Allocated |
|-------- |----------- |--------------------:|------:|----------------:|
| FastSet |          1 |            18.24 ns |  0.67 |            80 B |
| HashSet |          1 |            27.24 ns |  1.00 |           168 B |
|         |            |                     |       |                 |
| FastSet |        100 |           653.88 ns |  0.56 |           208 B |
| HashSet |        100 |         1,176.62 ns |  1.00 |         6,000 B |
|         |            |                     |       |                 |
| FastSet |      10000 |        57,598.25 ns |  0.34 |         4,384 B |
| HashSet |      10000 |       168,172.24 ns |  1.00 |       538,656 B |
|         |            |                     |       |                 |
| FastSet |    1000000 |     5,819,893.44 ns |  0.28 |       524,787 B |
| HashSet |    1000000 |    21,024,800.00 ns |  1.00 |    43,111,446 B |
|         |            |                     |       |                 |
| FastSet |  100000000 |   585,783,700.00 ns |  0.28 |    33,556,160 B |
| HashSet |  100000000 | 2,113,297,500.00 ns |  1.00 | 6,136,884,336 B |

### Static

Capacity = Iterations.

|  Method | Iterations |              Mean | Ratio |       Allocated |
|-------- |----------- |------------------:|------:|----------------:|
| FastSet |          1 |          20.07 ns |  0.76 |            80 B |
| HashSet |          1 |          26.29 ns |  1.00 |           168 B |
|         |            |                   |       |                 |
| FastSet |        100 |         457.94 ns |  0.69 |            88 B |
| HashSet |        100 |         660.41 ns |  1.00 |         1,832 B |
|         |            |                   |       |                 |
| FastSet |      10000 |      47,503.20 ns |  0.56 |         1,328 B |
| HashSet |      10000 |      86,558.50 ns |  1.00 |       161,781 B |
|         |            |                   |       |                 |
| FastSet |    1000000 |   4,016,065.62 ns |  0.45 |       125,086 B |
| HashSet |    1000000 |   8,988,651.95 ns |  1.00 |    18,603,226 B |
|         |            |                   |       |                 |
| FastSet |  100000000 | 405,141,275.00 ns |  0.49 |    12,503,232 B |
| HashSet |  100000000 | 822,356,360.00 ns |  1.00 | 1,600,001,048 B |

## Contains

Data = `Enumerable.Range(0, Iterations)`.

|  Method | Iterations |                Mean | Ratio |       Allocated |
|-------- |----------- |--------------------:|------:|----------------:|
| FastSet |          1 |            34.62 ns |  0.60 |           120 B |
| HashSet |          1 |            57.48 ns |  1.00 |           208 B |
|         |            |                     |       |                 |
| FastSet |        100 |           946.82 ns |  0.51 |           248 B |
| HashSet |        100 |         1,848.76 ns |  1.00 |         6,040 B |
|         |            |                     |       |                 |
| FastSet |      10000 |        86,119.66 ns |  0.40 |         4,424 B |
| HashSet |      10000 |       216,576.04 ns |  1.00 |       538,696 B |
|         |            |                     |       |                 |
| FastSet |    1000000 |     9,469,483.20 ns |  0.35 |       524,828 B |
| HashSet |    1000000 |    26,255,979.06 ns |  1.00 |    43,111,506 B |
|         |            |                     |       |                 |
| FastSet |  100000000 |   931,330,375.00 ns |  0.34 |    33,556,200 B |
| HashSet |  100000000 | 2,735,724,800.00 ns |  1.00 | 6,136,884,664 B |

## Remove

Data = `Enumerable.Range(0, Iterations)`.

|  Method | Iterations |                Mean | Ratio |       Allocated |
|-------- |----------- |--------------------:|------:|----------------:|
| FastSet |          1 |            36.40 ns |  0.62 |           120 B |
| HashSet |          1 |            58.87 ns |  1.00 |           208 B |
|         |            |                     |       |                 |
| FastSet |        100 |         1,175.76 ns |  0.58 |           248 B |
| HashSet |        100 |         2,026.44 ns |  1.00 |         6,040 B |
|         |            |                     |       |                 |
| FastSet |      10000 |       116,981.21 ns |  0.51 |         4,424 B |
| HashSet |      10000 |       231,293.35 ns |  1.00 |       538,696 B |
|         |            |                     |       |                 |
| FastSet |    1000000 |    10,855,032.81 ns |  0.38 |       524,828 B |
| HashSet |    1000000 |    28,539,675.62 ns |  1.00 |    43,111,566 B |
|         |            |                     |       |                 |
| FastSet |  100000000 | 1,137,995,500.00 ns |  0.39 |    33,556,200 B |
| HashSet |  100000000 | 2,918,531,540.00 ns |  1.00 | 6,136,884,664 B |

