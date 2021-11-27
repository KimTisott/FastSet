﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace FastestCollections
{
    public class NumericCollection : IEnumerable<int>
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

        public void Init()
        {
            _data = new int[1];
        }

        public bool TryAdd(int index)
        {
            if (index < 0)
                return default;

            var dictionaryIndex = index >> 5;

            var position = index % 32;

            Resize(dictionaryIndex);

            if (((_data[dictionaryIndex] >> position) & 1) != 0)
                return default;

            _data[dictionaryIndex] |= 1 << position;

            _count++;

            return true;
        }

        public bool Contains(int index)
        {
            if (index < 0 || index >= BufferSize)
                return default;

            return ((1 << (index % 32)) & _data[index >> 5]) != 0;
        }

        public bool TryRemove(int index)
        {
            if (index < 0 || index > BufferSize)
                return default;

            var dictionaryIndex = index >> 5;

            var position = index % 32;

            if (((_data[dictionaryIndex] >> position) & 1) == 0)
                return default;

            _data[dictionaryIndex] ^= 1 << position;

            _count--;

            return true;
        }

        public int? this[int index]
        {
            get
            {
                if (index < 0 || index > BufferSize)
                    return default;

                return (_data[index >> 5] & (1 << (index % 32))) > 0 ? 1 : null;
            }
        }

        void Resize(int dictionaryIndex)
        {
            var necessarySize = dictionaryIndex + 1;

            if (necessarySize < _data.Length)
                return;

            var doubleSize = _data.Length * 2;

            Array.Resize(ref _data, necessarySize > doubleSize ? necessarySize : doubleSize);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}