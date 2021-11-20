# FastSet
 Faster implementations of data sets.

## Types

- Int32

## Benchmarks

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
 ```
 
### Int32

#### x1000

|  Method |       Mean |     Error |    StdDev | Code Size |   Gen 0 | Allocated |
|-------- |-----------:|----------:|----------:|----------:|--------:|----------:|
| FastSet |   1.697 us | 0.0045 us | 0.0042 us |     350 B |  0.1678 |     704 B |
| HashSet |  10.714 us | 0.0520 us | 0.0461 us |     710 B | 13.9771 |  58,664 B |
| FastSet |   722.0 ns |   1.37 ns |   1.21 ns |      69 B |       - |         - |
| HashSet | 4,226.4 ns |   9.28 ns |   8.23 ns |     455 B |       - |         - |
| FastSet |   1.683 us | 0.0024 us | 0.0020 us |     111 B |       - |         - |
| HashSet |   3.548 us | 0.0578 us | 0.0541 us |     432 B |       - |         - |
