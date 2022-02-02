using System;
using System.Collections.Generic;

namespace NumericCollection
{
    public class NumericCollection
    {
        int[] _data;

        int Limit
            => _data.Length * 32;

        int _count;
        public int Count
            => _count;

        readonly int? _limit;

        /// <summary>
        /// Initializes data with the minimum amount of resources.
        /// </summary>
        public NumericCollection()
        {
            _data = new int[1];
        }

        /// <summary>
        /// Initializes data with the required specified <paramref name="limit"/>.
        /// </summary>
        public NumericCollection(int limit)
        {
            if (limit < 1)
                throw new ArgumentOutOfRangeException(nameof(limit));

            _data = new int[(limit - 1) / 32 + 1];
            _limit = limit;
        }

        /// <summary>
        /// Loads data with <paramref name="values"/>, according to the optional <paramref name="limit"/>.
        /// </summary>
        public NumericCollection(IEnumerable<int> values, int? limit = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (limit != null)
            {
                if (limit < 1)
                    throw new ArgumentOutOfRangeException(nameof(limit));

                _data = new int[(limit.Value - 1) / 32 + 1];
                _limit = limit;
            }
            else
            {
                _data = new int[1];
            }

            foreach (var value in values)
                Add(value);
        }

        /// <summary>
        /// Adds <paramref name="value"/> to the collection.
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            var index = value >> 5;
            var bit = value & 0x1F;

            if (_limit == null)
                CheckSize(index);
            else if (_limit.Value < value)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (((_data[index] >> bit) & 1) != 0)
                throw new InvalidOperationException($"Value {value} already present.");

            _data[index] |= 1 << bit;
            _count++;
        }

        /// <summary>
        /// Determines whether <paramref name="value"/> is in the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is found; otherwise, <see langword="false"/>.</returns>
        public bool Contains(int value)
        {
            if (value < 0 || value >= Limit)
                return false;

            return ((1 << (value & 0x1F)) & _data[value >> 5]) != 0;
        }

        /// <summary>
        /// Removes <paramref name="value"/> from the collection.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            if (value < 0 || value > Limit)
                throw new ArgumentOutOfRangeException(nameof(value));

            var index = value >> 5;
            var bit = value & 0x1F;

            if (((_data[index] >> bit) & 1) == 0)
                throw new InvalidOperationException($"Value {value} not present.");

            _data[index] ^= 1 << bit;
            _count--;
        }

        void CheckSize(int index)
        {
            var size = index + 1;
            if (size >= _data.Length)
            {
                var newSize = _data.Length * 2;
                Array.Resize(ref _data, size > newSize ? size : newSize);
            }
        }
    }
}