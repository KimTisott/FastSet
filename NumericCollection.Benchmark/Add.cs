using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace NumericCollection.Benchmarks
{
    [BenchmarkCategory(nameof(Add))]
    public class Add : BenchmarkBase
    {
        [Benchmark]
        public void Numeric()
        {
            var collection = new NumericCollection();

            for (var i = 0; i < Count; i++)
            {
                collection.Add(i);
            }
        }

        [Benchmark]
        public void Numeric_Static()
        {
            var collection = new NumericCollection(staticData: true);

            for (var i = 0; i < Count; i++)
            {
                collection.Add(i);
            }
        }

        //[Benchmark]
        public void HashSet()
        {
            var hashSet = new HashSet<int>();

            for (var i = 0; i < Count; i++)
            {
                hashSet.Add(i);
            }
        }
    }
}