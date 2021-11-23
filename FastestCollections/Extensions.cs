using System.Collections.Generic;

namespace FastestCollections
{
    public static class NumericCollection
    {
        public static NumericCollection<int> ToNumericCollection(this IEnumerable<int> enumerable)
        {
            NumericCollection<int> collection = new();

            foreach(var item in enumerable)
            {
                collection.TryAdd(item);
            }

            return collection;
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            var limit = start + count;

            while (start < limit)
            {
                yield return start;
                start++;
            }
        }
    }
}