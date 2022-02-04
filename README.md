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
| Numeric |    Dynamic |         1 |            19.88 ns |  0.77 |           104 B |
| HashSet |    Dynamic |         1 |            25.69 ns |  1.00 |           168 B |
| Numeric |     Static |         1 |            11.68 ns |  0.43 |            72 B |
| HashSet |     Static |         1 |            27.08 ns |  1.00 |           168 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |        10 |            63.98 ns |  0.42 |           104 B |
| HashSet |    Dynamic |        10 |           151.87 ns |  1.00 |           664 B |
| Numeric |     Static |        10 |            48.28 ns |  0.63 |            72 B |
| HashSet |     Static |        10 |            75.80 ns |  1.00 |           296 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |       100 |           551.07 ns |  0.40 |           200 B |
| HashSet |    Dynamic |       100 |         1,401.92 ns |  1.00 |         6,000 B |
| Numeric |     Static |       100 |           419.73 ns |  0.67 |            80 B |
| HashSet |     Static |       100 |           623.45 ns |  1.00 |         1,832 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |      1000 |         5,350.13 ns |  0.47 |           720 B |
| HashSet |    Dynamic |      1000 |        11,374.66 ns |  1.00 |        58,664 B |
| Numeric |     Static |      1000 |         4,454.10 ns |  0.74 |           192 B |
| HashSet |     Static |      1000 |         6,077.24 ns |  1.00 |        17,768 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |     10000 |        51,293.65 ns |  0.32 |         4,376 B |
| HashSet |    Dynamic |     10000 |       162,783.45 ns |  1.00 |       538,656 B |
| Numeric |     Static |     10000 |        41,205.81 ns |  0.48 |         1,320 B |
| HashSet |     Static |     10000 |        85,595.52 ns |  1.00 |       161,781 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |    100000 |       502,688.48 ns |  0.29 |        33,120 B |
| HashSet |    Dynamic |    100000 |     1,816,042.42 ns |  1.00 |     4,830,622 B |
| Numeric |     Static |    100000 |       413,868.78 ns |  0.43 |        12,568 B |
| HashSet |     Static |    100000 |       968,118.55 ns |  1.00 |     1,738,384 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |   1000000 |     5,044,563.83 ns |  0.23 |       262,585 B |
| HashSet |    Dynamic |   1000000 |    21,921,108.12 ns |  1.00 |    43,111,496 B |
| Numeric |     Static |   1000000 |     4,129,712.50 ns |  0.46 |       125,078 B |
| HashSet |     Static |   1000000 |     8,925,010.94 ns |  1.00 |    18,603,236 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic |  10000000 |    50,925,816.00 ns |  0.33 |     4,195,174 B |
| HashSet |    Dynamic |  10000000 |   156,288,170.00 ns |  1.00 |   377,378,604 B |
| Numeric |     Static |  10000000 |    40,590,115.38 ns |  0.47 |     1,250,204 B |
| HashSet |     Static |  10000000 |    85,758,076.67 ns |  1.00 |   160,003,424 B |
|         |            |           |                     |       |                 |
| Numeric |    Dynamic | 100000000 |   504,835,275.00 ns |  0.24 |    33,556,152 B |
| HashSet |    Dynamic | 100000000 | 2,070,539,175.00 ns |  1.00 | 6,136,884,000 B |
| Numeric |     Static | 100000000 |   404,231,380.00 ns |  0.51 |    12,500,856 B |
| HashSet |     Static | 100000000 |   791,634,160.00 ns |  1.00 | 1,600,001,048 B |

### Contains

|  Method |     count |                Mean | Ratio |       Allocated |
|-------- |---------- |--------------------:|------:|----------------:|
| Numeric |         1 |            40.42 ns |  0.74 |           144 B |
| HashSet |         1 |            54.42 ns |  1.00 |           208 B |
|         |           |                     |       |                 |
| Numeric |        10 |           107.96 ns |  0.44 |           144 B |
| HashSet |        10 |           245.50 ns |  1.00 |           704 B |
|         |           |                     |       |                 |
| Numeric |       100 |           833.60 ns |  0.45 |           240 B |
| HashSet |       100 |         1,838.82 ns |  1.00 |         6,040 B |
|         |           |                     |       |                 |
| Numeric |      1000 |         7,761.64 ns |  0.46 |           760 B |
| HashSet |      1000 |        16,925.83 ns |  1.00 |        58,704 B |
|         |           |                     |       |                 |
| Numeric |     10000 |        76,225.23 ns |  0.35 |         4,416 B |
| HashSet |     10000 |       216,414.22 ns |  1.00 |       538,696 B |
|         |           |                     |       |                 |
| Numeric |    100000 |       768,118.51 ns |  0.39 |        33,160 B |
| HashSet |    100000 |     1,974,003.03 ns |  1.00 |     4,830,620 B |
|         |           |                     |       |                 |
| Numeric |   1000000 |     7,643,461.72 ns |  0.26 |       262,625 B |
| HashSet |   1000000 |    29,166,985.00 ns |  1.00 |    43,111,495 B |
|         |           |                     |       |                 |
| Numeric |  10000000 |    81,079,777.14 ns |  0.35 |     4,195,179 B |
| HashSet |  10000000 |   234,307,260.00 ns |  1.00 |   377,378,728 B |
|         |           |                     |       |                 |
| Numeric | 100000000 |   784,280,000.00 ns |  0.28 |    33,556,192 B |
| HashSet | 100000000 | 2,780,230,425.00 ns |  1.00 | 6,136,884,664 B |

### Remove

|  Method |     count |                Mean | Ratio |       Allocated |
|-------- |---------- |--------------------:|------:|----------------:|
| Numeric |         1 |            41.80 ns |  0.73 |           144 B |
| HashSet |         1 |            57.04 ns |  1.00 |           208 B |
|         |           |                     |       |                 |
| Numeric |        10 |           148.93 ns |  0.58 |           144 B |
| HashSet |        10 |           257.77 ns |  1.00 |           704 B |
|         |           |                     |       |                 |
| Numeric |       100 |         1,100.08 ns |  0.55 |           240 B |
| HashSet |       100 |         1,989.79 ns |  1.00 |         6,040 B |
|         |           |                     |       |                 |
| Numeric |      1000 |        10,385.09 ns |  0.58 |           760 B |
| HashSet |      1000 |        18,012.97 ns |  1.00 |        58,704 B |
|         |           |                     |       |                 |
| Numeric |     10000 |       102,369.38 ns |  0.45 |         4,416 B |
| HashSet |     10000 |       227,305.30 ns |  1.00 |       538,696 B |
|         |           |                     |       |                 |
| Numeric |    100000 |     1,020,849.51 ns |  0.43 |        33,161 B |
| HashSet |    100000 |     2,519,976.07 ns |  1.00 |     4,830,681 B |
|         |           |                     |       |                 |
| Numeric |   1000000 |    10,213,317.58 ns |  0.35 |       262,626 B |
| HashSet |   1000000 |    29,219,960.62 ns |  1.00 |    43,111,495 B |
|         |           |                     |       |                 |
| Numeric |  10000000 |   103,224,596.00 ns |  0.45 |     4,195,602 B |
| HashSet |  10000000 |   229,341,506.67 ns |  1.00 |   377,378,632 B |
|         |           |                     |       |                 |
| Numeric | 100000000 | 1,023,600,450.00 ns |  0.36 |    33,556,192 B |
| HashSet | 100000000 | 2,847,749,950.00 ns |  1.00 | 6,136,884,376 B |
