using System;
using System.Collections;
using System.Collections.Generic;

namespace NumericCollection
{
    public class NumericCollection : IEnumerable<bool>
    {
        int[] _data;

        int _count;
        public int Count
            => _count;

        int? _limit;
        public int? Limit
            => _limit;

        int _length;
        float _growth;
        const float DefaultGrowth = 2;

        /// <summary>
        /// Initializes data with the optional <paramref name="limit"/>.
        /// </summary>
        public NumericCollection(int? limit = null, float growth = DefaultGrowth)
        {
            if (growth < 0)
                throw new ArgumentOutOfRangeException(nameof(growth));

            if (limit == null)
            {
                _length = 1;
            }
            else
            {
                if (limit < 1)
                    throw new ArgumentOutOfRangeException(nameof(limit));

                _length = (limit.Value - 1) / 32 + 1;
            }

            _data = new int[_length];
            _limit = limit;
            _growth = growth;
        }

        /// <summary>
        /// Loads data with <paramref name="values"/> and the optional <paramref name="limit"/>.
        /// </summary>
        public NumericCollection(IEnumerable<int> values, int? limit = null, float growth = DefaultGrowth)
            : this(limit, growth)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

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
            if (value < 0 || value >= _limit)
                return false;

            return ((1 << value) & _data[value >> 5]) != 0;
        }

        /// <summary>
        /// Removes <paramref name="value"/> from the collection.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            if (value < 0 || value > _limit)
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
            var size = index++;
            if (size >= _length)
            {
                var calcSize = (int)Math.Ceiling(_length * _growth);
                var newSize = size > calcSize ? size : calcSize;
                Array.Resize(ref _data, newSize);
                _length = newSize;
            }
        }

        public bool this[int index]
            => Contains(index);

        public IEnumerator<bool> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}