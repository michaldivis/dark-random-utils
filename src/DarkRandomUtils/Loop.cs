namespace DarkRandomUtils;

/// <summary>
/// A loopable sequence of items
/// </summary>
public class Loop<T>
{
    private readonly List<T> _items = new();
    private int _nextIndex = 0;

    internal Loop(IEnumerable<T> items)
    {
        _items.AddRange(items);
    }

    /// <summary>
    /// Gets the next item in the loop
    /// </summary>
    /// <returns>The next item in the loop</returns>
    public T GetNext()
    {
        var item = _items[_nextIndex];
        IncrementIndex();
        return item;
    }

    private void IncrementIndex()
    {
        if (_nextIndex >= _items.Count - 1)
        {
            _nextIndex = 0;
            return;
        }

        _nextIndex++;
    }
}

/// <summary>
/// A loopable sequence of items
/// </summary>
public static class Loop
{
    /// <summary>
    /// Creates an instance of <see cref="Loop{T}"/> from a collection of items
    /// </summary>
    /// <param name="items">Items to create the loop from, cannot be empty</param>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ArgumentException" />
    public static Loop<T> Create<T>(List<T> items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items), "Loop items cannot be null");
        }

        if (items.Count == 0)
        {
            throw new ArgumentException("Loop items cannot be empty", nameof(items));
        }

        return new Loop<T>(items);
    }

    /// <summary>
    /// Creates an instance of <see cref="Loop{T}"/> from a collection of items
    /// </summary>
    /// <param name="items">Items to create the loop from, cannot be empty</param>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ArgumentException" />
    public static Loop<T> Create<T>(params T[] items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items), "Loop items cannot be null");
        }

        if (items.Length == 0)
        {
            throw new ArgumentException("Loop items cannot be empty", nameof(items));
        }

        return new Loop<T>(items);
    }
}