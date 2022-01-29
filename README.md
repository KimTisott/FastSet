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

|  Method |      Count |             Mean |          Error |           StdDev |           Median |    Allocated |  Notes |
|-------- |----------- |-----------------:|---------------:|-----------------:|-----------------:|-------------:|-------:|
| Numeric |          1 |         18.75 ns |       0.377 ns |         0.353 ns |         18.68 ns |         96 B |        |
| HashSet |          1 |         27.08 ns |       0.549 ns |         0.486 ns |         27.15 ns |        168 B |        |
| Numeric |       1000 |      3,760.75 ns |      36.379 ns |        32.249 ns |      3,766.47 ns |        712 B |        |
| HashSet |       1000 |     11,344.20 ns |     263.413 ns |       751.533 ns |     10,942.49 ns |     58,664 B |        |
| Numeric |    1000000 |  3,674,451.87 ns |  52,343.709 ns |    46,401.335 ns |  3,658,394.53 ns |    262,575 B |        |
| HashSet |    1000000 | 21,990,010.70 ns | 716,239.734 ns | 2,077,941.341 ns | 22,087,296.88 ns | 43,111,496 B |        |
| Numeric | 1000000000 |          3.380 s |       0.0293 s |         0.0274 s |  3,658,394.53 ns |       256 MB |        |
| Numeric | 1000000000 |          2.217 s |       0.0204 s |         0.0191 s |  3,658,394.53 ns |       256 MB | Static |
| HashSet | 1000000000 |                - |              - |                - |                - |            - | DNF    |

### Contains

|  Method |   Count |             Mean |          Error |           StdDev |    Allocated |
|-------- |-------- |-----------------:|---------------:|-----------------:|-------------:|
| Numeric |       1 |         35.85 ns |       0.664 ns |         0.621 ns |        136 B |
| HashSet |       1 |         56.49 ns |       1.158 ns |         1.027 ns |        208 B |
| Numeric |    1000 |      7,244.55 ns |      94.312 ns |        88.219 ns |        752 B |
| HashSet |    1000 |     17,539.28 ns |     350.801 ns |       491.773 ns |     58,704 B |
| Numeric | 1000000 |  6,036,269.11 ns |  56,945.554 ns |    53,266.906 ns |    262,617 B |
| HashSet | 1000000 | 27,879,910.21 ns | 555,880.233 ns | 1,549,571.905 ns | 43,111,555 B |

### Remove

|  Method |   Count |             Mean |          Error |           StdDev |    Allocated |
|-------- |-------- |-----------------:|---------------:|-----------------:|-------------:|
| Numeric |       1 |         39.00 ns |       0.797 ns |         0.949 ns |        136 B |
| HashSet |       1 |         55.55 ns |       1.131 ns |         1.347 ns |        208 B |
| Numeric |    1000 |      8,865.95 ns |      47.272 ns |        44.218 ns |        752 B |
| HashSet |    1000 |     18,045.76 ns |      73.074 ns |        61.020 ns |     58,704 B |
| Numeric | 1000000 |  8,633,551.46 ns |  92,837.077 ns |    86,839.859 ns |    262,618 B |
| HashSet | 1000000 | 29,364,822.60 ns | 586,826.109 ns | 1,371,687.112 ns | 43,111,545 B |