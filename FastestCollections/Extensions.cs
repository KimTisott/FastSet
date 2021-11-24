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
                nc.TryAdd(item);
            }

            return nc;
        }

        public static List<int> ToList(this NumericCollection nc)
        {
            List<int> list = new();

            foreach (var item in nc)
            {
                for (var i = 0; i < 32; i++)
                {

                }

                list.Add(item);
            }

            return list;
        }
    }
}