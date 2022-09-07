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
    public T PickWeighted<T>(IList<WeightedPick<T>> items)
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

    public T PickWeightedInternal<T>(IList<WeightedPick<T>> items)
    {
        var weightSum = items.Sum(a => a.Weight);

        while (true)
        {
            for (int i = 0; i < items.Count; i++)
            {
                //get random weight from 1 to weightSum
                var randomWeight = _random.Next(1, weightSum);

                //return the item if randomWeight is less than of equal to the current item's Weight
                if(randomWeight <= items[i].Weight)
                {
                    return items[i].Value;
                }
            }
        }
    }
}