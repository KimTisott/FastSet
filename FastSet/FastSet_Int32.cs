using System;
using System.Collections.Generic;

namespace FastSet
{
    public class FastSet_Int32
    {
        int[] dictionaries;
        int BufferSize => dictionaries.Length * 32;
        public int Count { get; }

        public FastSet_Int32()
        {
            Init();
        }

        public FastSet_Int32(IEnumerable<int> enumerable)
        {
            Init();

            foreach (var item in enumerable)
            {
                TryAdd(item);
            }
        }

        public bool TryAdd(int index)
        {
            if (index < 0)
                return false;

            var dictionaryIndex = index >> 5;

            var position = index % 32;

            if (((dictionaries[dictionaryIndex] >> position) & 1) != 0)
                return false;

            Resize(dictionaryIndex);

            dictionaries[dictionaryIndex] |= 1 << position;

            Count++;

            return true;
        }

        public void Init()
        {
            dictionaries = new int[1];
        }

        public bool Contains(int index)
        {
            if (index < 0 || index >= BufferSize)
                return false;

            return ((1 << (index % 32)) & dictionaries[index >> 5]) != 0;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > BufferSize)
                return;

            dictionaries[index >> 5] ^= 1 << (index % 32);
        }

        void Resize(int dictionaryIndex)
        {
            var necessarySize = dictionaryIndex + 1;

            if (necessarySize < dictionaries.Length)
                return;

            var doubleSize = dictionaries.Length * 2;

            Array.Resize(ref dictionaries, necessarySize > doubleSize ? necessarySize : doubleSize);
        }
    }

    public static class FastSetExtensions
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
    }
}