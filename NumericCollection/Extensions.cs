using System.Collections.Generic;

namespace NumericCollection
{
    public static class Numeric
    {
        public static NumericCollection ToNumericCollection(this IEnumerable<int> enumerable)
        {
            NumericCollection nc = new();

            foreach (var item in enumerable)
            {
                nc.Add(item);
            }

            return nc;
        }
    }
}