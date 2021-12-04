using System.Collections.Generic;

namespace FastestCollections
{
    public static class Fastest
    {
        public static NumericCollection ToNumericCollection(this IEnumerable<int> enumerable)
        {
            NumericCollection nc = new();

            foreach(var item in enumerable)
            {
                nc.Add(item);
            }

            return nc;
        }
    }
}