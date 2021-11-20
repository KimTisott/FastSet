using System;
using System.Collections.Generic;

namespace FastSet
{
    public class FastSet_Int64
    {
        long[] dictionaries;
        int _bufferSize => dictionaries.Length * 64;
        int _count;
        public int Count => _count;

        public FastSet_Int64()
        {
            Init();
        }

        public FastSet_Int64(IEnumerable<long> enumerable)
        {
            Init();

            foreach (var item in enumerable)
            {
                TryAdd(item);
            }
        }

        public void Init()
        {
            dictionaries = new long[1];
        }

        public bool TryAdd(long index)
        {
            if (index < 0)
                return false;

            var dictionaryIndex = (int)(index >> 6);

            var position = (int)(index % 64);

            if (((dictionaries[dictionaryIndex] >> position) & 1) != 0)
                return false;

            Resize(dictionaryIndex);

            dictionaries[dictionaryIndex] |= 1 << position;

            _count++;

            return true;
        }

        public bool Contains(long index)
        {
            if (index < 0 || index >= _bufferSize)
                return false;

            return ((1 << (int)(index % 64)) & dictionaries[index >> 6]) != 0;
        }

        public bool TryRemove(long index)
        {
            if (index < 0 || index > _bufferSize)
                return false;

            var dictionaryIndex = (int)(index >> 6);

            var position = (int)(index % 64);

            if (((dictionaries[dictionaryIndex] >> position) & 1) == 0)
                return false;

            dictionaries[dictionaryIndex] ^= 1 << position;

            _count--;

            return true;
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
}