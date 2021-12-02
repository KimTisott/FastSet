using System;
using System.Collections.Generic;

namespace FastestCollections
{
    public class NumericCollection
    {
        int[] _data = new int[1];

        int BufferSize => _data.Length * 32;

        int _count;
        public int Count => _count;

        public NumericCollection(){}

        public NumericCollection(IEnumerable<int> values)
        {
            foreach (var value in values)
                TryAdd(value);
        }

        /// <summary>
        /// Adds <paramref name="value"/> to the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns><see langword="true"/> if <paramref name="value"/> is added; otherwise, <see langword="false"/>.</returns>
        public bool TryAdd(int value)
        {
            if (value < 0)
                throw new RangeException(nameof(value), default(int), int.MaxValue);

            var dictionaryIndex = value >> 5;

            var position = value % 32;

            var necessarySize = dictionaryIndex + 1;

            if (necessarySize >= _data.Length)
            {
                var doubleSize = _data.Length * 2;

                Array.Resize(ref _data, necessarySize > doubleSize ? necessarySize : doubleSize);
            }

            if (((_data[dictionaryIndex] >> position) & 1) != 0)
                return false;

            _data[dictionaryIndex] |= 1 << position;

            _count++;

            return true;
        }

        /// <summary>
        /// Removes <paramref name="value"/> from the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns><see langword="true"/> if <paramref name="value"/> is removed; otherwise, <see langword="false"/>.</returns>
        public bool TryRemove(int value)
        {
            if (value < 0)
                throw new RangeException(nameof(value), default(int), int.MaxValue);

            if (value > BufferSize)
                return false;

            var dictionaryIndex = value >> 5;

            var position = value % 32;

            if (((_data[dictionaryIndex] >> position) & 1) == 0)
                return false;

            _data[dictionaryIndex] ^= 1 << position;

            _count--;

            return true;
        }

        /// <summary>
        /// Determines whether <paramref name="value"/> is in the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns><see langword="true"/> if <paramref name="value"/> is found; otherwise, <see langword="false"/>.</returns>
        public bool TryContains(int value)
        {
            if (value < 0)
                throw new RangeException(nameof(value), default(int), int.MaxValue);

            if (value >= BufferSize)
                return false;

            return ((1 << (value % 32)) & _data[value >> 5]) != 0;
        }

        class RangeException : Exception
        {
            public RangeException(string paramName, object lower, object upper)
                => throw new ArgumentOutOfRangeException(paramName, null, $"Value should be between {lower} and {upper}.");
        }
    }
}
