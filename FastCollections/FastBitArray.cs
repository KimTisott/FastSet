using System;

namespace FastCollections
{
    public class FastBitArray
    {
        private int[] dictionaries;

        public FastBitArray()
        {
            Clear();
        }

        public FastBitArray(int[] values)
        {
            Clear();

            Array.Resize(ref dictionaries, (values.Length >> 5) + 1);

            for (var i = 0; i < values.Length; i++)
            {
                dictionaries[i >> 5] |= 1 << (i % 32);
            }
        }

        private void Clear()
        {
            dictionaries = new int[1];
        }

        public int this[int index]
        {
            get
            {
                return dictionaries[index >> 5];
            }
        }

        public FastBitArray And(FastBitArray value)
        {
            for (var i = 0; i < dictionaries.Length; i++)
            {
                dictionaries[i] &= value[i];
            }

            return this;
        }

        public FastBitArray Or(FastBitArray value)
        {
            for (var i = 0; i < dictionaries.Length; i++)
            {
                //dictionaries[i] |= value[i];
            }

            return this;
        }

        public bool[] ToBoolArray()
        {
            var result = new bool[5 << dictionaries.Length];

            for (var i = 0; i < dictionaries.Length; i++)
            {
                //result[i] = dictionaries[i] & 1;
            }

            return result;
        }
    }
}