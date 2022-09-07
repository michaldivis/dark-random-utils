using FluentAssertions;

namespace DarkRandomUtils;

public class RandomPickerTests
{
    private readonly RandomPicker _randomPicker;

    public RandomPickerTests()
    {
        _randomPicker = new RandomPicker(new Random(123465));
    }

    [Fact]
    public void PickWeighted_ShouldBeBiasedByWeight()
    {
        uint tolerance = 1_000;

        var weightedNames = new WeightedPick<string>[]
        {
            new("Bjorn", 3), //30% chance of getting picked
            new("Helmut", 1), //10% chance of getting picked
            new("Nabeel", 2), //20% chance of getting picked
            new("Amelia", 4) //40% chance of getting picked
        };

        var pickedNames = new List<string>();

        for (int i = 0; i < 10_000; i++)
        {
            pickedNames.Add(_randomPicker.PickWeighted(weightedNames));
        }

        var bjornCount = pickedNames.Count(a => a == "Bjorn");
        var helmutCount = pickedNames.Count(a => a == "Helmut");
        var nabeelCount = pickedNames.Count(a => a == "Nabeel");
        var ameliaCount = pickedNames.Count(a => a == "Amelia");

        bjornCount.Should().BeCloseTo(3_000, tolerance);
        helmutCount.Should().BeCloseTo(1_000, tolerance);
        nabeelCount.Should().BeCloseTo(2_000, tolerance);
        ameliaCount.Should().BeCloseTo(4_000, tolerance);
    }
}