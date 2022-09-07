<img src="assets/icon.png?raw=true" width="200">

# Dark Random Utils

C# randomization helpers - random picker, weighted picks, loop.

## Nuget

[![Nuget](https://img.shields.io/nuget/v/Divis.DarkRandomUtils?label=Divis.DarkRandomUtils)](https://www.nuget.org/packages/Divis.DarkRandomUtils/)

DarkRandomUtils is available using [nuget](https://www.nuget.org/packages/Divis.DarkRandomUtils/). To install DarkRandomUtils, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```Powershell
PM> Install-Package Divis.DarkRandomUtils
```

## Random Picker

```csharp
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
```

## Loop

```csharp
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
```
