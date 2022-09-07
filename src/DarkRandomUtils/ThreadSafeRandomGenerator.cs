namespace DarkRandomUtils;

public class ThreadSafeRandomGenerator
{
    private readonly Random _random;
    private readonly object _syncLock = new();

    public ThreadSafeRandomGenerator(Random random)
    {
        _random = random;
    }

    public int Next(int min, int max)
    {
        lock (_syncLock)
        {
            return _random.Next(min, max);
        }
    }
}
