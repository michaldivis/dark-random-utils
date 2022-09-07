namespace DarkRandomUtils;

public class Loop<T>
{
    private readonly List<T> _items = new();
    private int _nextIndex = 0;

    /// <summary>
    /// To be added
    /// </summary>
    /// <param name="items">To be added</param>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ArgumentException" />
    public Loop(List<T> items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items), "Loop items cannot be null");
        }

        if (items.Count == 0)
        {
            throw new ArgumentException("Loop items cannot be empty", nameof(items));
        }

        _items.AddRange(items);
    }

    public Loop(params T[] items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items), "Loop items cannot be null");
        }

        if (items.Length == 0)
        {
            throw new ArgumentException("Loop items cannot be empty", nameof(items));
        }

        _items.AddRange(items);
    }

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