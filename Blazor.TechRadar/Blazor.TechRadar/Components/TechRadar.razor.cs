using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.TechRadar.Components;

public partial class TechRadar : ComponentBase
{
    /// <summary>
    ///     Describes the last point in time since the TechRadar was updated.
    /// </summary>
    [Parameter]
    public DateTime? Date { get; set; }

    [Inject]
    public required IJSRuntime JsRuntime { get; set; }

    /// <summary>
    ///     The four quadrants of the TechRadar.
    /// </summary>
    [Parameter]
    public List<Quadrant> Quadrants { get; set; } = [];

    [Parameter]
    public Uri? Repository { get; set; }

    [Parameter]
    public string Title { get; set; } = "Tech Radar";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var config = new
            {
                repo_url = Repository?.ToString(),
                title = Title,
                date = Date?.ToString("yyyy.MM"),
                quadrants = Quadrants.Select(q => new { name = q.Name }),
                rings = new[]
                {
                    new { name = nameof(Ring.Adopt).ToUpper(), color = "#5ba300" },
                    new { name = nameof(Ring.Trial).ToUpper(), color = "#009eb0" },
                    new { name = nameof(Ring.Assess).ToUpper(), color = "#c7ba00" },
                    new { name = nameof(Ring.Hold).ToUpper(), color = "#e09b96" }
                },
                entries = Quadrants.GetEntries().ToList()
            };

            await JsRuntime.InvokeVoidAsync("radar_visualization", config);
        }
    }
}