# FastCollections
 Faster implementations of the following .NET collections:
 
 - Collections
   - BitArray
 - Generic Collections
   - [HashSet](https://github.com/KimTisott/FastCollections/blob/main/FastCollections/FastSet.cs)

## Features

### General

- Faster data operations
- Reduced memory allocations
- Additional helper extensions

#### HashSet

- Bit key
- Index-based dictionary

## Benchmarks

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1165 (20H2/October2020Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.301
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
 ```
 
### HashSet

#### Int32 x1000000

|  Method | Categories |      Mean | Code Size |    Gen 0 |    Gen 1 |    Gen 2 |    Allocated |
|-------- |----------- |----------:|----------:|---------:|---------:|---------:|-------------:|
| FastSet |        Add |  3.180 ms |     194 B |  27.3438 |        - |        - |    262,552 B |
| HashSet |        Add | 21.176 ms |     828 B | 812.5000 | 781.2500 | 781.2500 | 43,111,114 B |
| FastSet |   Contains |  2.163 ms |     125 B |        - |        - |        - |            - |
| HashSet |   Contains |  4.671 ms |     471 B |        - |        - |        - |            - |
| FastSet |     Remove |  2.225 ms |     129 B |        - |        - |        - |            - |
| HashSet |     Remove |  3.643 ms |     422 B |        - |        - |        - |            - |
