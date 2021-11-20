# FastSet

Faster implementation of sets.

## Features

- Faster operations
- Low memory usage
- Supports Int32

## Benchmarks

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
 ```
 
### Int32

|           Method |   Count |             Mean |          Error |           StdDev |           Median |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |-------- |-----------------:|---------------:|-----------------:|-----------------:|----------:|----------:|----------:|-------------:|
|      FastSet_Add |       1 |         20.79 ns |       0.239 ns |         0.200 ns |         20.75 ns |    0.0229 |         - |         - |         96 B |
|      HashSet_Add |       1 |         31.69 ns |       1.067 ns |         3.096 ns |         30.74 ns |    0.0401 |         - |         - |        168 B |
| FastSet_Contains |       1 |         39.38 ns |       0.717 ns |         0.560 ns |         39.33 ns |    0.0325 |         - |         - |        136 B |
| HashSet_Contains |       1 |         59.40 ns |       1.053 ns |         1.730 ns |         58.89 ns |    0.0497 |         - |         - |        208 B |
|   FastSet_Remove |       1 |         40.82 ns |       0.605 ns |         0.565 ns |         40.92 ns |    0.0325 |         - |         - |        136 B |
|   HashSet_Remove |       1 |         58.37 ns |       0.873 ns |         0.774 ns |         58.25 ns |    0.0497 |         - |         - |        208 B |
|      FastSet_Add |     100 |        470.20 ns |       4.317 ns |         3.827 ns |        468.98 ns |    0.0458 |         - |         - |        192 B |
|      HashSet_Add |     100 |      1,271.29 ns |      24.055 ns |        22.501 ns |      1,275.10 ns |    1.4343 |         - |         - |      6,000 B |
| FastSet_Contains |     100 |        847.20 ns |      13.201 ns |        12.348 ns |        844.46 ns |    0.0553 |         - |         - |        232 B |
| HashSet_Contains |     100 |      2,006.96 ns |      39.675 ns |        54.308 ns |      1,996.50 ns |    1.4420 |         - |         - |      6,040 B |
|   FastSet_Remove |     100 |      1,028.59 ns |       4.465 ns |         3.958 ns |      1,028.37 ns |    0.0553 |         - |         - |        232 B |
|   HashSet_Remove |     100 |      2,099.76 ns |      35.098 ns |        32.831 ns |      2,089.93 ns |    1.4420 |         - |         - |      6,040 B |
|      FastSet_Add |   10000 |     42,066.52 ns |     449.503 ns |       420.466 ns |     41,903.44 ns |    1.0376 |         - |         - |      4,368 B |
|      HashSet_Add |   10000 |    171,150.31 ns |   3,336.179 ns |     3,276.574 ns |    170,382.84 ns |   95.2148 |   95.2148 |   95.2148 |    538,656 B |
| FastSet_Contains |   10000 |     74,032.94 ns |     845.481 ns |       749.497 ns |     73,668.65 ns |    0.9766 |         - |         - |      4,408 B |
| HashSet_Contains |   10000 |    233,520.66 ns |   2,792.265 ns |     2,475.270 ns |    234,078.11 ns |   95.2148 |   95.2148 |   95.2148 |    538,696 B |
|   FastSet_Remove |   10000 |     92,404.59 ns |     583.087 ns |       516.892 ns |     92,237.73 ns |    0.9766 |         - |         - |      4,408 B |
|   HashSet_Remove |   10000 |    250,130.10 ns |   4,723.785 ns |     5,439.917 ns |    248,350.72 ns |   95.2148 |   95.2148 |   95.2148 |    538,696 B |
|      FastSet_Add | 1000000 |  4,161,755.62 ns |  23,440.288 ns |    19,573.702 ns |  4,156,847.27 ns |   39.0625 |   39.0625 |   39.0625 |    262,577 B |
|      HashSet_Add | 1000000 | 21,204,632.89 ns | 423,986.209 ns |   921,711.125 ns | 21,351,309.38 ns | 1000.0000 |  968.7500 |  968.7500 | 43,111,446 B |
| FastSet_Contains | 1000000 |  7,440,266.13 ns |  64,332.211 ns |    57,028.829 ns |  7,419,458.98 ns |   39.0625 |   39.0625 |   39.0625 |    262,617 B |
| HashSet_Contains | 1000000 | 28,083,621.79 ns | 556,114.483 ns | 1,395,182.503 ns | 28,529,134.38 ns | 1156.2500 | 1125.0000 | 1125.0000 | 43,111,545 B |
|   FastSet_Remove | 1000000 |  9,336,377.68 ns |  35,100.778 ns |    31,115.926 ns |  9,336,127.34 ns |   31.2500 |   31.2500 |   31.2500 |    262,618 B |
|   HashSet_Remove | 1000000 | 28,962,141.38 ns | 565,295.345 ns |   828,602.587 ns | 29,067,896.88 ns | 1156.2500 | 1125.0000 | 1125.0000 | 43,111,536 B |

## Roadmap

1. Support Int8, Int16, Int64
2. Zero memory allocation
3. Thread safety