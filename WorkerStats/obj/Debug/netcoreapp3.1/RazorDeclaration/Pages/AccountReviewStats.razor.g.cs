#pragma checksum "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cd775b0a395342f2dc038176705728bb1203af5"
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
#line 1 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using WorkerStats;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\Employee\ZachL\WorkerStats\WorkerStats\_Imports.razor"
using WorkerStats.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
using WorkerStats.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
using System.Timers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/accountreviewstats")]
    public partial class AccountReviewStats : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 150 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
           
        private string loggedInUsername = Environment.UserName;
        private string currentPage = "AccountReviewPage";
        private string currentPageForReload = "/accountreviewstats";
        private static Timer aTimer;

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

        public long totalCount;
        public long remainingTotalCount;
        public long totalTimeSpent;

        protected override async Task OnInitializedAsync()
        {
            aTimer = new System.Timers.Timer();
            //set timer to 5 minutes (300000 milliseconds)
            aTimer.Interval = 300000;
            //hook up the Elapsed event for the timer
            aTimer.Elapsed += OnTimedEvent;
            //have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;
            //start the timer
            aTimer.Enabled = true;

            //Get todays stats from AllWorkerStats table
            workerStats = await WorkerStatsService.GetStatsAsync(currentPage);
            workerStatsRemainingTotals = await WorkerStatsService.GetRemainingTotalsAsync(currentPage);

            //Get unique usernames from list to populate form with
            uniqueUsers = workerStats.Select(uName => uName.Username).Distinct().ToList();
            //Get unique worker types from list to populate form with
            uniqueWorkers = workerStats.Select(worker => worker.InWorker).Distinct().ToList();
        }

        //event to fire after millisecods elapsed = interval
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            navigationManager.NavigateTo(currentPageForReload);
        }

        //search workerstats table based on values in form
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
