namespace DarkRandomUtils;

/// <summary>
/// Represents an item with a weight
/// </summary>
public record WeightedPick<T>(T Value, int Weight);