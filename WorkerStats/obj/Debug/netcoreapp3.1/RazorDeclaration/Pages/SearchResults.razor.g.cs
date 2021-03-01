#pragma checksum "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2978d92ad6d9d0446cca62309177d5084d6f1a8"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WorkerStats.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using WorkerStats;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\_Imports.razor"
using WorkerStats.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
using WorkerStats.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/searchresults/{startDateTime}/{endDateTime}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/searchresults/worker/{startDateTime}/{endDateTime}/{inWorker}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/searchresults/user/{startDateTime}/{endDateTime}/{uniqueUserToSearch}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/searchresults/{startDateTime}/{endDateTime}/{uniqueUserToSearch}/{inWorker}")]
    public partial class SearchResults : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 90 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
       
    //Parameters for SearchResults razor component
    [Parameter]
    public string startDateTime { get; set; }
    [Parameter]
    public string endDateTime { get; set; }
    [Parameter]
    public string uniqueUserToSearch { get; set; }
    [Parameter]
    public string inWorker { get; set; }

    public long totalCount;
    public long remainingTotalCount;
    public long totalTimeSpent;
    public string convertedStartDateTime;
    public string convertedEndDateTime;
    private List<WorkerStats> workerStats { get; set; }

    protected override async Task OnInitializedAsync()
    {
        convertedStartDateTime = DateTime.ParseExact(startDateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
        convertedEndDateTime = DateTime.ParseExact(endDateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
        workerStats = await WorkerStatsService.SearchResultsAsync(startDateTime, endDateTime, uniqueUserToSearch, inWorker);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WorkerStatsService WorkerStatsService { get; set; }
    }
}
#pragma warning restore 1591
