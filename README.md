# FastSet

Fastest and lowest allocation set operations. [Beats the .NET HashSet in style](./FastSet.Benchmark).

All of the [.NET integral numeric types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types) are based on whole number storage. This means that 32 bits are required to store an `int`, 64 bits for a `long`, and 8 for a `byte`. So when working with the [.NET HashSet](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-6.0), the space required is calculated by taking the size of the data type and multiplying it by the amount of data. 
There are three issues with this implementation, and how `FastSet` overcame them:

1. Large storage space

When looking at the memory, this is how an `int` stores the number 13:

`00000000000000000000000000001101`

And here is its representation of 1.000.000.000 (one billion):

`00111011100110101100101000000000`

So 13 and one billion each take the same amount of space. That's awesome! However they both look pretty large, so maybe we could try removing the leading zeros:

`1101`

`111011100110101100101000000000`

This worked really well with 13, but one billion stayed pretty much the same. I wonder if there is a shorter way to represent them though, like with a single bit or something.

2. Costly operations

Throughout the years, the .NET team has done some amazing work with the HashSet. Still I felt quite disappointed with some performance issues in real-time scenarios, when dealing with large amounts of data. For instance, checking the existence of 100.000.000 numbers in a set that already contains 100.000.000 numbers [took 2.7s on my machine](https://github.com/KimTisott/FastSet/blob/main/FastSet.Benchmark/README.md#contains).

3. Missing configurations

Having the capacity property to preallocate the space required to insert the data is really nice. But when not setting an initial capacity, there is no way to control when and how much the dynamic space should be reallocated.
