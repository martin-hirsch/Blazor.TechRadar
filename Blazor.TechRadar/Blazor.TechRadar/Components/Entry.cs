namespace Blazor.TechRadar.Components;

public record Entry(string Label, Ring Ring, Moved Moved, Uri? Uri = null, bool Active = true);