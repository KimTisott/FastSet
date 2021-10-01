using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Linq;

namespace FastCollections.Benchmarks
{
    public class BitArray_And : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("And")]
        public int FastBitArray()
        {
            var fastBitArray = new FastBitArray(Enumerable.Range(0, 5).ToArray());

            fastBitArray.And(new FastBitArray(new int[] { 0, 1 }));

            return fastBitArray[0];
        }

        [Benchmark, BenchmarkCategory("And")]
        public bool BitArray()
        {
            var bitArray = new BitArray(1);

            bitArray.Or(new BitArray(new bool[] { true }));

            bitArray.And(bitArray);

            return bitArray[0];
        }
    }
}