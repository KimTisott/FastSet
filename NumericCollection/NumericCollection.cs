using System;
using System.Collections.Generic;

namespace FastestCollections
{
    public class NumericCollection
    {
        int[] _data;

        int BufferSize => _data.Length * 32;

        int _count;
        public int Count => _count;

        public NumericCollection()
        {
            Init();
        }

        public NumericCollection(IEnumerable<int> values)
        {
            Init();

            foreach (var value in values)
            {
                var num = value;

                if (num < 0)
                    throw new ArgumentOutOfRangeException(nameof(values), value, $"Value should be between {default(int)} and {int.MaxValue}");

                TryAdd(num);
            }
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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value should be between {default(int)} and {int.MaxValue}");

            var dictionaryIndex = value >> 5;

            var position = value % 32;

            EnsureCapacity(dictionaryIndex);

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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value should be between {default(int)} and {int.MaxValue}");

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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value should be between {default(int)} and {int.MaxValue}");

            if (value >= BufferSize)
                return false;

            return ((1 << (value % 32)) & _data[value >> 5]) != 0;
        }

        /// <summary>
        /// Determines whether <paramref name="value"/> is in the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns><see langword="true"/> if <paramref name="value"/> is found; otherwise, <see langword="false"/>.</returns>
        public bool this[int value]
        {
            get
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"Value should be between {default(int)} and {int.MaxValue}");

                if (value > BufferSize)
                    return false;

                return ((1 << (value % 32)) & _data[value >> 5]) != 0;
            }
        }

        void Init()
        {
            _data = new int[1];
        }

        void EnsureCapacity(int dictionaryIndex)
        {
            var necessarySize = dictionaryIndex + 1;

            if (necessarySize < _data.Length)
                return;

            var doubleSize = _data.Length * 2;

            Array.Resize(ref _data, necessarySize > doubleSize ? necessarySize : doubleSize);
        }
    }
}
