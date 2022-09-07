using DarkRandomUtils;

namespace SampleApp;

public static class RandomPickerExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("RANDOM PICKER examples");
        Console.WriteLine("----------------");

        var picker = new RandomPicker(new Random(123456));

        var names = new[] { "Bjorn", "Helmut", "Nabeel", "Amelia" };
        Console.WriteLine($"Names: {string.Join(", ", names)}");

        var randomName = picker.Pick(names);
        Console.WriteLine($"Randomly picked name: {randomName}");

        //output:
        //Randomly picked name: Helmut

        var weightedNames = new WeightedPick<string>[] 
        { 
            new("Bjorn", 3), //30% chance of getting picked
            new("Helmut", 1), //10% chance of getting picked
            new("Nabeel", 2), //20% chance of getting picked
            new("Amelia", 4) //40% chance of getting picked
        };

        var weightedRandomName = picker.PickWeighted(weightedNames);
        Console.WriteLine($"Randomly picked weighted name: {weightedRandomName}");

        //output:
        //Randomly picked weighted name: Bjorn
    }
}