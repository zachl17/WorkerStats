#pragma checksum "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\LegalWorkerStats.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aeb35b7d0adfcdb3c297c02088664152e6858fa8"
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
#line 1 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using WorkerStats;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using WorkerStats.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\LegalWorkerStats.razor"
using WorkerStats.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/legalworkerstats")]
    public partial class LegalWorkerStats : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 100 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\LegalWorkerStats.razor"
       
    private string currentPage = "LegalPage";

    //For form fields
    private string inWorker;
    private string uniqueUserToSearch;
    public static DateTime currentDate = DateTime.Now;
    string currentDateString = currentDate.ToString("yyyy-MM-dd");
    DateTime startDateString = currentDate;
    DateTime endDateString = currentDate;

    private List<WorkerStats> workerStats { get; set; }
    private List<WorkerStats> workerStatsRemainingTotals { get; set; }
    private List<string> uniqueUsers = new List<string>();
    private List<string> uniqueWorkers = new List<string>();

    protected override async Task OnInitializedAsync()
    {
        //Get todays stats from AllWorkerStats table on page load
        workerStats = await WorkerStatsService.GetStatsAsync(currentPage);
        workerStatsRemainingTotals = await WorkerStatsService.GetRemainingTotalsAsync(currentPage);

        //Get unique usernames from list to populate form with
        uniqueUsers = workerStats.Select(uName => uName.Username).Distinct().ToList();

        //Get unique worker types from list to populate form with
        uniqueWorkers = workerStats.Select(worker => worker.InWorker).Distinct().ToList();
    }

    protected void SearchStats()
    {
        string startDate = startDateString.ToString("yyyy-MM-dd");
        string endDate = endDateString.ToString("yyyy-MM-dd");

        if (String.IsNullOrEmpty(uniqueUserToSearch) && String.IsNullOrEmpty(inWorker))
        {
            navigationManager.NavigateTo($"/searchresults/{startDate}/{endDate}");
        }
        else if (!String.IsNullOrEmpty(uniqueUserToSearch) && String.IsNullOrEmpty(inWorker))
        {
            navigationManager.NavigateTo($"/searchresults/user/{startDate}/{endDate}/{uniqueUserToSearch}");
        }
        else if (String.IsNullOrEmpty(uniqueUserToSearch) && !String.IsNullOrEmpty(inWorker))
        {
            navigationManager.NavigateTo($"/searchresults/worker/{startDate}/{endDate}/{inWorker}");
        }
        else
        {
            navigationManager.NavigateTo($"/searchresults/{startDate}/{endDate}/{uniqueUserToSearch}/{inWorker}");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WorkerStatsService WorkerStatsService { get; set; }
    }
}
#pragma warning restore 1591
