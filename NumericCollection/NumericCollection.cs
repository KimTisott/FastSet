using System;
using System.Collections.Generic;

namespace NumericCollection
{
    public class NumericCollection
    {
        int[] _data;

        int BufferSize
            => _data.Length * 32;

        readonly bool _staticData;

        int _count;
        public int Count
            => _count;

        public NumericCollection(IEnumerable<int> values = null, bool staticData = false)
        {
            _staticData = staticData;
            _data = new int[_staticData ? int.MaxValue / 32 : 1];

            if (values != null)
                foreach (var value in values)
                    Add(value);
        }

        /// <summary>
        /// Adds <paramref name="value"/> to the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is added; otherwise, <see langword="false"/>.</returns>
        public bool Add(int value)
        {
            if (value < 0)
                return false;

            var dictionaryIndex = value >> 5;
            var position = value & 0x1F;

            if (!_staticData)
            {
                var necessarySize = dictionaryIndex + 1;
                if (necessarySize >= _data.Length)
                {
                    var doubleSize = _data.Length * 2;
                    Array.Resize(ref _data, necessarySize > doubleSize ? necessarySize : doubleSize);
                }
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
        /// <returns><see langword="true"/> if <paramref name="value"/> is removed; otherwise, <see langword="false"/>.</returns>
        public bool Remove(int value)
        {
            if (value < 0 || value > BufferSize)
                return false;

            var dictionaryIndex = value >> 5;
            var position = value & 0x1F;

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
        /// <returns><see langword="true"/> if <paramref name="value"/> is found; otherwise, <see langword="false"/>.</returns>
        public bool Contains(int value)
        {
            if (value < 0 || value >= BufferSize)
                return false;

            return ((1 << (value & 0x1F)) & _data[value >> 5]) != 0;
        }
    }
}