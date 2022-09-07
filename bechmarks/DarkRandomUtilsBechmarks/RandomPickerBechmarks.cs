using BenchmarkDotNet.Attributes;
using DarkRandomUtils;

namespace DarkRandomUtilsBechmarks;

[MemoryDiagnoser]
public class RandomPickerBechmarks
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private RandomPicker _randomPicker;
    private List<int> _fewItems;
    private List<WeightedPick<int>> _fewWeightedItems;
    private List<int> _manyItems;
    private List<WeightedPick<int>> _manyWeightedItems;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [GlobalSetup]
    public void GlobalSetup()
    {
        _randomPicker = new(Random.Shared);

        _fewItems = new() { 1, 2, 3, 4 };

        _fewWeightedItems = new()
        {
            new(1, 3),
            new(2, 1),
            new(3, 2),
            new(4, 4)
        };

        _manyItems = Enumerable.Range(1, 10_000).ToList();

        _manyWeightedItems = Enumerable.Range(1, 10_000)
            .Select(a => new WeightedPick<int>(a, Random.Shared.Next(1, 100)))
            .ToList();
    }

    [Benchmark]
    public void Pick_Few()
    {
        _randomPicker.Pick(_fewItems);
    }

    [Benchmark]
    public void Pick_Many()
    {
        _randomPicker.Pick(_manyItems);
    }

    [Benchmark]
    public void PickWeighted_Few()
    {
        _randomPicker.PickWeighted(_fewWeightedItems);
    }

    [Benchmark]
    public void PickWeighted_Many()
    {
        _randomPicker.PickWeighted(_manyWeightedItems);
    }
}
