using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace FastSet.Benchmarks;

[Config(typeof(Config))]
[SimpleJob(launchCount: 1, warmupCount: 5, targetCount: 5, baseline: true)]
[StopOnFirstError(false)]
public class Base
{
    public const int Count = 100;

    [ParamsSource(nameof(GetRandomLimitedValues))]
    public IEnumerable<int> RandomLimitedValues { get; set; }

    public static IEnumerable<IEnumerable<int>> GetRandomLimitedValues()
    {
        var array = new int[Count];

        var random = new Random();
        for (var index = 0; index < Count; index++)
            array[index] = random.Next(Count);

        yield return array;
    }

    [ParamsSource(nameof(GetRandomUnlimitedValues))]
    public IEnumerable<int> RandomUnlimitedValues { get; set; }

    public static IEnumerable<IEnumerable<int>> GetRandomUnlimitedValues()
    {
        var array = new int[Count];

        var random = new Random();
        for (var index = 0; index < Count; index++)
            array[index] = random.Next();

        yield return array;
    }

    [ParamsSource(nameof(GetSequentialValues))]
    public IEnumerable<int> SequentialValues { get; set; }

    public static IEnumerable<IEnumerable<int>> GetSequentialValues()
    {
        var array = new int[Count];

        for (var index = 0; index < Count; index++)
            array[index] = index;

        yield return array;
    }
}