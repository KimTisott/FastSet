# NumericCollection

Fastest implementation of a .NET number collection.

## Features

| Lookup | Duplicate | Ordered | Sorted | Null | Min |        Max |
|------- |---------- |-------- |------- |----- |---- |----------- |
|  Index |        No |      No |     No |   No |   0 | 2147483647 |

## Benchmarks

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
```

### Add

|  Method |   Count |             Mean |          Error |         StdDev |    Allocated |
|-------- |-------- |-----------------:|---------------:|---------------:|-------------:|
| Fastest |       1 |         22.71 ns |       0.460 ns |       0.430 ns |         96 B |
| HashSet |       1 |         30.05 ns |       0.602 ns |       0.618 ns |        168 B |
| Fastest |    1000 |      4,349.95 ns |      24.400 ns |      21.630 ns |        712 B |
| HashSet |    1000 |     12,023.42 ns |     213.530 ns |     199.736 ns |     58,664 B |
| Fastest | 1000000 |  4,319,362.63 ns |  75,029.085 ns |  70,182.253 ns |    262,577 B |
| HashSet | 1000000 | 24,049,732.45 ns | 478,845.814 ns | 988,899.641 ns | 43,111,516 B |

### Contains

|  Method |   Count |             Mean |          Error |           StdDev |    Allocated |
|-------- |-------- |-----------------:|---------------:|-----------------:|-------------:|
| Fastest |       1 |         41.77 ns |       0.823 ns |         0.770 ns |        136 B |
| HashSet |       1 |         62.70 ns |       1.268 ns |         1.302 ns |        208 B |
| Fastest |    1000 |      7,872.76 ns |      83.688 ns |        78.282 ns |        752 B |
| HashSet |    1000 |     18,817.25 ns |     316.143 ns |       280.253 ns |     58,704 B |
| Fastest | 1000000 |  7,728,336.07 ns |  55,700.437 ns |    52,102.223 ns |    262,617 B |
| HashSet | 1000000 | 30,871,006.60 ns | 609,697.562 ns | 1,388,589.877 ns | 43,111,525 B |

### Remove

|  Method |   Count |             Mean |          Error |           StdDev |    Allocated |
|-------- |-------- |-----------------:|---------------:|-----------------:|-------------:|
| Fastest |       1 |         42.16 ns |       0.441 ns |         0.368 ns |        136 B |
| HashSet |       1 |         62.30 ns |       1.114 ns |         1.042 ns |        208 B |
| Fastest |    1000 |     10,366.99 ns |      70.875 ns |        66.297 ns |        752 B |
| HashSet |    1000 |     20,124.44 ns |     362.215 ns |       338.816 ns |     58,704 B |
| Fastest | 1000000 | 10,492,388.62 ns |  73,935.944 ns |    65,542.288 ns |    262,619 B |
| HashSet | 1000000 | 32,806,357.77 ns | 649,722.689 ns | 1,581,514.822 ns | 43,111,552 B |

## Roadmap

- Int64 support
- Negative values
- Thread safety
