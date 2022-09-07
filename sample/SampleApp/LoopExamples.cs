using DarkRandomUtils;

namespace SampleApp;
public static class LoopExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("LOOP examples");
        Console.WriteLine("----------------");

        var names = new[] { "Bjorn", "Helmut", "Nabeel", "Amelia" };
        Console.WriteLine($"Names: {string.Join(", ", names)}");

        var loop = Loop.Create(names);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i}: {loop.GetNext()}");
        }

        //output:
        //0: Bjorn
        //1: Helmut
        //2: Nabeel
        //3: Amelia
        //4: Bjorn
        //5: Helmut
        //6: Nabeel
        //7: Amelia
        //8: Bjorn
        //9: Helmut
    }
}
