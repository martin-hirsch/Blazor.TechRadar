namespace Blazor.TechRadar.Components;

public record Quadrant(string Name, List<Entry> Entries);

public record Entry(string Label, Ring Ring, Moved Moved, Uri? Uri = null, bool Active = true);

public enum Ring
{
    Adopt = 0,
    Trial = 1,
    Assess = 2,
    Hold = 3
}

public enum Moved
{
    Down = -1,
    NoChange = 0,
    Up = 1,
    New = 2
}