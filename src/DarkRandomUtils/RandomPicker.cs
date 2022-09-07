namespace DarkRandomUtils;

public class RandomPicker
{
    private readonly ThreadSafeRandomGenerator _randomGenerator;

    public RandomPicker(ThreadSafeRandomGenerator randomGenerator)
    {
        _randomGenerator = randomGenerator;
    }

    public T Pick<T>(List<T> items)
    {
        var index = _randomGenerator.Next(0, items.Count);
        return items[index];
    }

    public T Pick<T>(params T[] items)
    {
        var index = _randomGenerator.Next(0, items.Length);
        return items[index];
    }

    public T PickWeighted<T>(List<WeightedPick<T>> items)
    {
        var options = new List<T>();

        foreach (var item in items)
        {
            for (int i = 0; i < item.Weight; i++)
            {
                options.Add(item.Value);
            }
        }

        var numberOfOptions = items.Sum(a => a.Weight);

        var index = _randomGenerator.Next(0, numberOfOptions);

        return options[index];
    }

    public T PickWeighted<T>(params WeightedPick<T>[] items)
    {
        var options = new List<T>();

        foreach (var item in items)
        {
            for (int i = 0; i < item.Weight; i++)
            {
                options.Add(item.Value);
            }
        }

        var numberOfOptions = items.Sum(a => a.Weight);

        var index = _randomGenerator.Next(0, numberOfOptions);

        return options[index];
    }
}