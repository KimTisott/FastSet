using System;
using System.Collections.Generic;

namespace FastSet
{
    public class FastSet_Int32
    {
        int[] dictionaries;
        int _bufferSize => dictionaries.Length * 32;
        int _count;
        public int Count => _count;

        public FastSet_Int32()
        {
            Init();
        }

        public FastSet_Int32(IEnumerable<int> values)
        {
            Init();

            foreach (var value in values)
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(values), value, $"Value should be between {default(int)} and {int.MaxValue}");
                }

                TryAdd(value);
            }
        }

        public void Init()
        {
            dictionaries = new int[1];
        }

        public bool TryAdd(int index)
        {
            if (index < 0)
                return false;

            var dictionaryIndex = index >> 5;

            var position = index % 32;

            Resize(dictionaryIndex);

            if (((dictionaries[dictionaryIndex] >> position) & 1) != 0)
                return false;

            dictionaries[dictionaryIndex] |= 1 << position;

            _count++;

            return true;
        }

        public bool Contains(int index)
        {
            if (index < 0 || index >= _bufferSize)
                return false;

            return ((1 << (index % 32)) & dictionaries[index >> 5]) != 0;
        }

        public bool TryRemove(int index)
        {
            if (index < 0 || index > _bufferSize)
                return false;

            var dictionaryIndex = index >> 5;

            var position = index % 32;

            if (((dictionaries[dictionaryIndex] >> position) & 1) == 0)
                return false;

            dictionaries[dictionaryIndex] ^= 1 << position;

            _count--;

            return true;
        }

        public int this[int index] => dictionaries[index];

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