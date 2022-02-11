using System;
using System.Collections;
using System.Collections.Generic;

namespace FastSet;

public class FastSet : IEnumerable<int>
{
    int[] _data;

    int _count;
    public int Count
        => _count;

    readonly int? _limit;
    public int? Limit
        => _limit;

    int _length;

    readonly float _growth;
    const float DefGrowth = 2;

    readonly float _load;
    const float DefLoad = 0.75f;

    public FastSet(int? limit = null, float growth = DefGrowth, float load = DefLoad)
    {
        if (growth < 0)
            throw new ArgumentOutOfRangeException(nameof(growth));

        if (limit == null)
            _length = 1;
        else
        {
            if (limit < 1)
                throw new ArgumentOutOfRangeException(nameof(limit));

            _length = (limit.Value - 1) / 32 + 1;
        }

        _data = new int[_length];
        _limit = limit;
        _growth = growth;
        _load = load;
    }

    public FastSet(IEnumerable<int> values, int? limit = null, float growth = DefGrowth)
        : this(limit, growth)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        foreach (var value in values)
            TryAdd(value);
    }

    /// <summary>
    /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
    /// </summary>
    /// <param name="item">The element to add to the set.</param>
    /// <returns><see langword="true"/> if the element is added in the set; <see langword="false"/> if the element is already in the set.</returns>
    public bool TryAdd(int item)
    {
        if (item < 0)
            return false;

        var index = item >> 5;

        if (_limit == null)
            CheckSize(index);
        else if (_limit.Value < item)
            return false;

        var bit = item & 0x1F;

        if (((_data[index] >> bit) & 1) != 0)
            return false;

        _data[index] |= 1 << bit;
        _count++;

        return true;
    }

    /// <summary>
    /// Determines whether the <see cref="FastSet"/> contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in the <see cref="FastSet"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="item"/> is found in the <see cref="FastSet"/>; otherwise, <see langword="false"/>.</returns>
    public bool Contains(int item)
    {
        if (item < 0 || item >= _limit)
            return false;

        return ((1 << item) & _data[item >> 5]) != 0;
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="FastSet"/>.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="FastSet"/>.</param>
    /// <returns><see langword="true"/> if <param name="item"> was successfully removed from the <see cref="FastSet"/>; otherwise, <see langword="false"/>. This method also returns <see langword="false"/> if <param name="item"> is not found in the original <see cref="FastSet"/>.</returns>
    public bool TryRemove(int item)
    {
        if (item < 0 || item > _limit)
            return false;

        var index = item >> 5;
        var bit = item & 0x1F;

        if (((_data[index] >> bit) & 1) == 0)
            return false;

        _data[index] ^= 1 << bit;
        _count--;

        return true;
    }

    void CheckSize(int index)
    {
        var size = index++;
        if (size >= _length * _load)
        {
            var calcSize = (int)Math.Ceiling(_length * _growth);
            var newSize = size > calcSize ? size : calcSize;
            Array.Resize(ref _data, newSize);
            _length = newSize;
        }
    }

    public bool this[int index] => Contains(index);

    public IEnumerator<int> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
            if (Contains(i))
                yield return i;
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}