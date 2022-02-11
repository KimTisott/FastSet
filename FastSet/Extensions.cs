using System;
using System.Collections.Generic;

namespace FastSet;

public static class Numeric
{
    public static FastSet ToFastNumbers(this IEnumerable<int> enumerable)
    {
        if (enumerable == null)
            throw new ArgumentNullException(nameof(enumerable));

        FastSet nc = new();

        foreach (var item in enumerable)
            nc.TryAdd(item);

        return nc;
    }
}