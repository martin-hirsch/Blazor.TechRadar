namespace Blazor.TechRadar.Components;

public static class QuadrantExtensions
{
    public static IEnumerable<object> GetEntries(this IEnumerable<Quadrant> source)
    {
        var quadrants = source.ToList();
        foreach (var quadrant in quadrants)
        {
            foreach (var entry in quadrant.Entries)
            {
                yield return new
                {
                    quadrant = quadrants.IndexOf(quadrant),
                    ring = entry.Ring,
                    label = entry.Label,
                    active = entry.Active,
                    moved = entry.Moved
                };
            }
        }
    }
}