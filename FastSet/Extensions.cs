using System.Collections.Generic;

namespace FastSet
{
    public static class FastSet
    {
        public static FastSet_Int32 ToFastSet(this IEnumerable<int> enumerable)
        {
            var fastSet = new FastSet_Int32();

            foreach (var item in enumerable)
            {
                fastSet.TryAdd(item);
            }

            return fastSet;
        }

        public static FastSet_Int64 ToFastSet(this IEnumerable<long> enumerable)
        {
            var fastSet = new FastSet_Int64();

            foreach (var item in enumerable)
            {
                fastSet.TryAdd(item);
            }

            return fastSet;
        }

        public static IEnumerable<int> Range_Int32(int start, int count)
        {
            var limit = start + count;

            while (start < limit)
            {
                yield return start;
                start++;
            }
        }

        public static IEnumerable<long> Range_Int64(long start, int count)
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