namespace DarkRandomUtils;

public class LoopTests
{
    private readonly Loop<int> _loop;

    public LoopTests()
    {
        _loop = new Loop<int>(4, 6, 8, 1, 18);
    }

    [Fact]
    public void Ctor_ShouldThrow_WhenItemsEmpty()
    {
        Action act = () => new Loop<int>();
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Ctor_ShouldThrow_WhenItemsNull()
    {
        List<int> items = null!;
        Action act = () => new Loop<int>(items);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GetNext_ShouldLoopCorrectly()
    {
        var item1 = _loop.GetNext();
        item1.Should().Be(4);

        var item2 = _loop.GetNext();
        item2.Should().Be(6);

        var item3 = _loop.GetNext();
        item3.Should().Be(8);

        var item4 = _loop.GetNext();
        item4.Should().Be(1);

        var item5 = _loop.GetNext();
        item5.Should().Be(18);

        var item6 = _loop.GetNext();
        item6.Should().Be(4);
    }
}