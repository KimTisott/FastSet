# NumericCollection

Fastest implementation of a .NET number collection.

## Features

| Duplicate | Ordered | Sorted | Null | Min |        Max |
|---------- |-------- |------- |----- |---- |----------- |
|        No |      No |     No |   No |   0 | 2147483647 |

## Benchmarks

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
```

### Add

|  Method | Categories |     count |                Mean | Ratio |       Allocated |
|-------- |----------- |---------- |--------------------:|------:|----------------:|
| Numeric |    Dynamic |         1 |            17.08 ns |  0.66 |            80 B |
| HashSet |    Dynamic |         1 |            25.92 ns |  1.00 |           168 B |
|         |            |           |                     |       |                 |
| Numeric |     Static |         1 |            19.01 ns |  0.74 |            80 B |
| HashSet |     Static |         1 |            25.61 ns |  1.00 |           168 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |       100 |           613.44 ns |  0.53 |           152 B |
| HashSet |    Dynamic |       100 |         1,167.34 ns |  1.00 |         6,000 B |
|         |            |           |                     |       |                 |
| Numeric |     Static |       100 |           424.10 ns |  0.74 |            88 B |
| HashSet |     Static |       100 |           575.14 ns |  1.00 |         1,832 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |     10000 |        57,318.10 ns |  0.37 |         4,384 B |
| HashSet |    Dynamic |     10000 |       155,375.46 ns |  1.00 |       538,656 B |
|         |            |           |                     |       |                 |
| Numeric |     Static |     10000 |        40,304.98 ns |  0.48 |         1,328 B |
| HashSet |     Static |     10000 |        83,672.46 ns |  1.00 |       161,781 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |   1000000 |     5,718,100.16 ns |  0.27 |       262,593 B |
| HashSet |    Dynamic |   1000000 |    21,038,506.25 ns |  1.00 |    43,111,485 B |
|         |            |           |                     |       |                 |
| Numeric |     Static |   1000000 |     4,059,108.83 ns |  0.44 |       125,086 B |
| HashSet |     Static |   1000000 |     9,308,485.16 ns |  1.00 |    18,603,226 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic | 100000000 |   594,818,020.00 ns |  0.27 |    33,555,872 B |
| HashSet |    Dynamic | 100000000 | 2,194,333,950.00 ns |  1.00 | 6,136,884,624 B |
|         |            |           |                     |       |                 |
| Numeric |     Static | 100000000 |   419,581,080.00 ns |  0.39 |    12,500,864 B |
| HashSet |     Static | 100000000 | 1,070,544,625.00 ns |  1.00 | 1,600,001,048 B |

### Contains

|  Method |     count |                Mean | Ratio |       Allocated |
|-------- |---------- |--------------------:|------:|----------------:|
| Numeric |         1 |            35.71 ns |  0.51 |           120 B |
| HashSet |         1 |            69.43 ns |  1.00 |           208 B |
|         |           |                     |       |                 |
| Numeric |       100 |           937.21 ns |  0.49 |           192 B |
| HashSet |       100 |         1,904.19 ns |  1.00 |         6,040 B |
|         |           |                     |       |                 |
| Numeric |     10000 |        87,095.98 ns |  0.36 |         4,424 B |
| HashSet |     10000 |       245,147.85 ns |  1.00 |       538,696 B |
|         |           |                     |       |                 |
| Numeric |   1000000 |     8,709,197.50 ns |  0.27 |       262,634 B |
| HashSet |   1000000 |    32,179,698.44 ns |  1.00 |    43,111,596 B |
|         |           |                     |       |                 |
| Numeric | 100000000 |   872,808,560.00 ns |  0.24 |    33,556,200 B |
| HashSet | 100000000 | 3,655,191,600.00 ns |  1.00 | 6,136,884,376 B |

### Remove

|  Method |     count |                Mean | Ratio |       Allocated |
|-------- |---------- |--------------------:|------:|----------------:|
| Numeric |         1 |            47.80 ns |  0.60 |           120 B |
| HashSet |         1 |            79.68 ns |  1.00 |           208 B |
|         |           |                     |       |                 |
| Numeric |       100 |         1,226.14 ns |  0.61 |           192 B |
| HashSet |       100 |         2,024.38 ns |  1.00 |         6,040 B |
|         |           |                     |       |                 |
| Numeric |     10000 |       118,691.47 ns |  0.50 |         4,424 B |
| HashSet |     10000 |       235,856.86 ns |  1.00 |       538,696 B |
|         |           |                     |       |                 |
| Numeric |   1000000 |    11,446,587.50 ns |  0.31 |       262,634 B |
| HashSet |   1000000 |    37,405,975.94 ns |  1.00 |    43,111,564 B |
|         |           |                     |       |                 |
| Numeric | 100000000 | 1,137,248,875.00 ns |  0.32 |    33,556,200 B |
| HashSet | 100000000 | 3,545,681,740.00 ns |  1.00 | 6,136,884,376 B |
