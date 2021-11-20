# FastSet

Fastest implementation of the [.NET HashSet](https://docs.microsoft.com/dotnet/api/system.collections.generic.hashset-1?view=net-6.0).

## Features

### Convert IEnumerable<T> to a set

```csharp
IEnumerable<int> ienum = Enumerable.Range(1, 100);
FastSet_Int32 set = ienum.ToFastSet();
```

### Generate a set from IEnumerable<T>

```csharp
FastSet_Int32 set = FastSet.Range_Int32(1, 100);
```

### Improved Add, Contains and Remove

```csharp
FastSet_Int32 set = ...;

if (set.TryAdd(100))
{
    // item added
}

if (set.Contains(100))
{
    // item exists
}

if (set.TryRemove(100))
{
    // item removed
}
```

## Benchmarks

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
```

### Add

|        Method |   Count |             Mean |          Error |           StdDev |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated | Code Size |
|-------------- |-------- |-----------------:|---------------:|-----------------:|----------:|----------:|----------:|-------------:|----------:|
| FastSet_Int32 |       1 |         20.08 ns |       0.428 ns |         0.440 ns |    0.0229 |         - |         - |         96 B |     236 B |
| FastSet_Int64 |       1 |         20.07 ns |       0.322 ns |         0.269 ns |    0.0249 |         - |         - |        104 B |     266 B |
| HashSet_Int32 |       1 |         29.92 ns |       0.876 ns |         2.556 ns |    0.0401 |         - |         - |        168 B |     718 B |
| HashSet_Int64 |       1 |         27.72 ns |       0.562 ns |         0.731 ns |    0.0421 |         - |         - |        176 B |     775 B |
| FastSet_Int32 |    1000 |      4,250.97 ns |      64.429 ns |        60.267 ns |    0.1678 |         - |         - |        712 B |     236 B |
| FastSet_Int64 |    1000 |      4,101.39 ns |      72.565 ns |        64.327 ns |    0.1602 |         - |         - |        680 B |     266 B |
| HashSet_Int32 |    1000 |     11,018.63 ns |     218.205 ns |       182.211 ns |   13.9771 |         - |         - |     58,664 B |     718 B |
| HashSet_Int64 |    1000 |     12,098.69 ns |     229.341 ns |       214.526 ns |   17.4408 |    2.8992 |         - |     73,152 B |     775 B |
| FastSet_Int32 | 1000000 |  4,135,775.62 ns |  57,264.560 ns |    53,565.305 ns |   39.0625 |   39.0625 |   39.0625 |    262,577 B |     236 B |
| FastSet_Int64 | 1000000 |  3,860,352.68 ns |  24,566.335 ns |    22,979.365 ns |   39.0625 |   39.0625 |   39.0625 |    262,543 B |     266 B |
| HashSet_Int32 | 1000000 | 21,651,788.97 ns | 424,587.627 ns |   867,320.008 ns | 1437.5000 | 1406.2500 | 1406.2500 | 43,111,586 B |     718 B |
| HashSet_Int64 | 1000000 | 23,921,337.75 ns | 475,463.046 ns | 1,082,869.958 ns | 1000.0000 |  968.7500 |  937.5000 | 53,888,875 B |     775 B |

### Contains

|        Method |   Count |             Mean |          Error |           StdDev |     Gen 0 |    Gen 1 |    Gen 2 |    Allocated | Code Size |
|-------------- |-------- |-----------------:|---------------:|-----------------:|----------:|---------:|---------:|-------------:|----------:|
| FastSet_Int32 |       1 |         38.24 ns |       0.769 ns |         1.026 ns |    0.0344 |        - |        - |        144 B |     389 B |
| FastSet_Int64 |       1 |         39.10 ns |       0.810 ns |         0.900 ns |    0.0401 |        - |        - |        168 B |     481 B |
| HashSet_Int32 |       1 |         56.00 ns |       1.082 ns |         1.202 ns |    0.0516 |        - |        - |        216 B |     837 B |
| HashSet_Int64 |       1 |         57.00 ns |       0.845 ns |         0.749 ns |    0.0573 |        - |        - |        240 B |     840 B |
| FastSet_Int32 |    1000 |      7,713.83 ns |      79.308 ns |        74.185 ns |    0.1678 |        - |        - |        760 B |     389 B |
| FastSet_Int64 |    1000 |      9,828.56 ns |      57.889 ns |        51.317 ns |    0.1678 |        - |        - |        744 B |     481 B |
| HashSet_Int32 |    1000 |     17,734.20 ns |     238.222 ns |       222.833 ns |   14.0076 |        - |        - |     58,712 B |     802 B |
| HashSet_Int64 |    1000 |     18,875.16 ns |     319.297 ns |       283.048 ns |   17.4255 |   2.8992 |        - |     73,216 B |     840 B |
| FastSet_Int32 | 1000000 |  7,559,826.35 ns |  46,633.074 ns |    43,620.606 ns |   39.0625 |  39.0625 |  39.0625 |    262,625 B |     389 B |
| FastSet_Int64 | 1000000 |  9,545,735.83 ns |  57,707.668 ns |    53,979.788 ns |   31.2500 |  31.2500 |  31.2500 |    262,611 B |     481 B |
| HashSet_Int32 | 1000000 | 28,571,602.59 ns | 568,063.240 ns | 1,445,902.321 ns | 1000.0000 | 968.7500 | 968.7500 | 43,111,494 B |     802 B |
| HashSet_Int64 | 1000000 | 29,251,283.75 ns | 551,209.934 ns |   515,602.115 ns |  968.7500 | 937.5000 | 906.2500 | 53,888,930 B |     840 B |

### Remove

|        Method |   Count |             Mean |          Error |           StdDev |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated | Code Size |
|-------------- |-------- |-----------------:|---------------:|-----------------:|----------:|----------:|----------:|-------------:|----------:|
| FastSet_Int32 |       1 |         40.11 ns |       0.788 ns |         0.774 ns |    0.0344 |         - |         - |        144 B |     487 B |
| FastSet_Int64 |       1 |         39.84 ns |       0.784 ns |         0.871 ns |    0.0401 |         - |         - |        168 B |     516 B |
| HashSet_Int32 |       1 |         54.82 ns |       0.634 ns |         0.593 ns |    0.0516 |         - |         - |        216 B |     814 B |
| HashSet_Int64 |       1 |         57.02 ns |       1.152 ns |         1.232 ns |    0.0573 |         - |         - |        240 B |     786 B |
| FastSet_Int32 |    1000 |     10,730.99 ns |     104.339 ns |        97.599 ns |    0.1678 |         - |         - |        760 B |     487 B |
| FastSet_Int64 |    1000 |     10,138.27 ns |      82.288 ns |        72.946 ns |    0.1678 |         - |         - |        744 B |     516 B |
| HashSet_Int32 |    1000 |     19,232.97 ns |     274.626 ns |       256.885 ns |   14.0076 |         - |         - |     58,712 B |     779 B |
| HashSet_Int64 |    1000 |     20,287.78 ns |     198.811 ns |       185.968 ns |   17.4255 |    2.8992 |         - |     73,216 B |     786 B |
| FastSet_Int32 | 1000000 |  9,995,641.88 ns |  64,915.425 ns |    60,721.929 ns |   31.2500 |   31.2500 |   31.2500 |    262,626 B |     487 B |
| FastSet_Int64 | 1000000 | 10,033,098.54 ns |  74,456.749 ns |    69,646.889 ns |   31.2500 |   31.2500 |   31.2500 |    262,610 B |     516 B |
| HashSet_Int32 | 1000000 | 29,892,287.29 ns | 520,741.724 ns |   487,102.131 ns | 1250.0000 | 1218.7500 | 1218.7500 | 43,111,575 B |     779 B |
| HashSet_Int64 | 1000000 | 30,008,117.15 ns | 594,596.790 ns | 1,041,388.313 ns | 1000.0000 |  937.5000 |  937.5000 | 53,888,954 B |     786 B |

## Roadmap

1. Support Int8, Int16
2. Zero memory allocation
3. Thread safety
