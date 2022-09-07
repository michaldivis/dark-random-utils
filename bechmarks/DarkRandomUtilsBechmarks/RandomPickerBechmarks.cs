using BenchmarkDotNet.Attributes;
using DarkRandomUtils;

namespace DarkRandomUtilsBechmarks;

[MemoryDiagnoser]
public class RandomPickerBechmarks
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private RandomPicker _randomPicker;
    private List<string> _items;
    private List<WeightedPick<string>> _weightedItems;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [GlobalSetup]
    public void GlobalSetup()
    {
        _randomPicker = new(Random.Shared);

        _items = new() { "Bjorn", "Helmut", "Nabeel", "Amelia" };

        _weightedItems = new()
        {
            new("Bjorn", 3),
            new("Helmut", 1),
            new("Nabeel", 2),
            new("Amelia", 4)
        };
    }

    [Benchmark]
    public void Pick()
    {
        _randomPicker.Pick(_items);
    }

    [Benchmark]
    public void PickWeighted()
    {
        _randomPicker.PickWeighted(_weightedItems);
    }
}
