namespace DarkRandomUtils;

/// <summary>
/// Helper class for randomly picking things
/// </summary>
public class RandomPicker
{
    private readonly Random _random;

    public RandomPicker(Random random)
    {
        _random = random;
    }

    /// <summary>
    /// Randomly pick one item
    /// </summary>
    /// <param name="items">Items to pick from</param>
    /// <returns>One randomly picked item</returns>
    public T Pick<T>(List<T> items)
    {
        return PickInternal(items, items.Count);
    }

    /// <summary>
    /// Randomly pick one item
    /// </summary>
    /// <param name="items">Items to pick from</param>
    /// <returns>One randomly picked item</returns>
    public T Pick<T>(params T[] items)
    {
        return PickInternal(items, items.Length);
    }

    private T PickInternal<T>(IList<T> items, int count)
    {
        var index = _random.Next(0, count);
        return items[index];
    }

    /// <summary>
    /// Randomly pick one item, biased by <see cref="WeightedPick{T}.Weight"/>. The greater the <see cref="WeightedPick{T}.Weight"/> of an item is, the bigger the chance for it to get picked.
    /// </summary>
    /// <param name="items">Weigthed items to pick from</param>
    /// <returns>One randomly picked item</returns>
    public T PickWeighted<T>(IEnumerable<WeightedPick<T>> items)
    {
        return PickWeightedInternal(items);
    }

    /// <summary>
    /// Randomly pick one item, biased by <see cref="WeightedPick{T}.Weight"/>. The greater the <see cref="WeightedPick{T}.Weight"/> of an item is, the bigger the chance for it to get picked.
    /// </summary>
    /// <param name="items">Weigthed items to pick from</param>
    /// <returns>One randomly picked item</returns>
    public T PickWeighted<T>(params WeightedPick<T>[] items)
    {
        return PickWeightedInternal(items);
    }

    public T PickWeightedInternal<T>(IEnumerable<WeightedPick<T>> items)
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

        var index = _random.Next(0, numberOfOptions);

        return options[index];
    }
}