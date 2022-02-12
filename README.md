# FastSet

Fastest and lowest allocation set operations. [Beats the .NET HashSet in style](./FastSet.Benchmark).

The current implementation of the [.NET HashSet](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-6.0) has three issues:

1. Large storage space

If we wanted a `HashSet` to store the numbers 1, 13 and 15, we would need 32 * 3 = 96 bits of space:

`00000000000000000000000000000001`
`00000000000000000000000000001101`
`00000000000000000000000000001111`

There is a lot of unnecessary zeros in there. In `FastSet` the storage looks like this:

`10100000000000000000000000000001`

Basically it uses the number as a bit field, with index that represent the added numbers.

2. Costly operations

Throughout the years, the .NET team has done some amazing work with the HashSet. Still I felt quite disappointed with some performance issues in real-time scenarios, when dealing with large amounts of data. For instance, checking the existence of 100.000.000 numbers in a set that already contains 100.000.000 numbers [took 2.7s on my machine](https://github.com/KimTisott/FastSet/blob/main/FastSet.Benchmark/README.md#contains).

3. Missing configurations

Having the capacity property to preallocate the space required to insert the data is really nice. But when not setting an initial capacity, there is no way to control when and how much the dynamic space should be reallocated.
