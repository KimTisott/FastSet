using System.Collections.Generic;

namespace FastNumber
{
    public static class Numeric
    {
        public static FastNumbers ToFastNumbers(this IEnumerable<int> enumerable)
        {
            FastNumbers nc = new();

            foreach (var item in enumerable)
                nc.Add(item);

            return nc;
        }
    }
}