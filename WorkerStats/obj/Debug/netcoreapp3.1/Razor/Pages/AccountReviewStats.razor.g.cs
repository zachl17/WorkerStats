#pragma checksum "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bcffad8b33815b53692197e77edc2d51043f40a"
// <auto-generated/>
#pragma warning disable 1591
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
#nullable restore
#line 8 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
 if (workerStats == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 11 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "container-fluid");
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.AddMarkupContent(5, "<h5>This page will automatically refresh every 5 minutes to get up to date stats</h5>\r\n    ");
            __builder.AddMarkupContent(6, "<h3>AR Department Worker Stats</h3>\r\n    ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "row");
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-md-12");
            __builder.AddMarkupContent(12, "\r\n            ");
            __builder.OpenElement(13, "table");
            __builder.AddAttribute(14, "class", "table table-bordered");
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.AddMarkupContent(16, @"<thead>
                    <tr>
                        <th>Employee</th>
                        <th>Avg</th>
                        <th>Count</th>
                        <th>Type</th>
                        <th>Time Spent</th>
                    </tr>
                </thead>
                ");
            __builder.OpenElement(17, "tbody");
            __builder.AddMarkupContent(18, "\r\n");
#nullable restore
#line 31 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                     foreach (var workerStat in workerStats)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(19, "                        ");
            __builder.OpenElement(20, "tr");
            __builder.AddMarkupContent(21, "\r\n                            ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 34 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStat.Username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                            ");
            __builder.OpenElement(25, "td");
            __builder.AddContent(26, 
#nullable restore
#line 35 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStat.AverageSecondsElapsed

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                            ");
            __builder.OpenElement(28, "td");
            __builder.AddContent(29, 
#nullable restore
#line 36 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStat.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                            ");
            __builder.OpenElement(31, "td");
            __builder.AddContent(32, 
#nullable restore
#line 37 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStat.InWorker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                            ");
            __builder.OpenElement(34, "td");
            __builder.AddContent(35, 
#nullable restore
#line 38 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStat.TimeSpent

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n");
#nullable restore
#line 40 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(38, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n    ");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "row");
            __builder.AddMarkupContent(45, "\r\n        ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "col-md-6");
            __builder.AddAttribute(48, "id", "searchForm");
            __builder.AddMarkupContent(49, "\r\n            ");
            __builder.OpenElement(50, "form");
            __builder.AddAttribute(51, "class", "form");
            __builder.AddAttribute(52, "role", "form");
            __builder.AddMarkupContent(53, "\r\n                ");
            __builder.OpenElement(54, "div");
            __builder.AddAttribute(55, "class", "form-group");
            __builder.AddMarkupContent(56, "\r\n                    ");
            __builder.AddMarkupContent(57, "<label for=\"beginDate\">Beginning Date:</label>\r\n                    ");
            __builder.OpenElement(58, "input");
            __builder.AddAttribute(59, "type", "date");
            __builder.AddAttribute(60, "class", "form-control");
            __builder.AddAttribute(61, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 50 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                                    startDateString

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(62, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => startDateString = __value, startDateString, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n                ");
            __builder.OpenElement(65, "div");
            __builder.AddAttribute(66, "class", "form-group");
            __builder.AddMarkupContent(67, "\r\n                    ");
            __builder.AddMarkupContent(68, "<label for=\"endDate\">End Date:</label>\r\n                    ");
            __builder.OpenElement(69, "input");
            __builder.AddAttribute(70, "type", "date");
            __builder.AddAttribute(71, "class", "form-control");
            __builder.AddAttribute(72, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 54 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                                    endDateString

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(73, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => endDateString = __value, endDateString, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                ");
            __builder.AddMarkupContent(76, "<label for=\"beginDate\">Name To Filter By:</label>\r\n                ");
            __builder.OpenElement(77, "select");
            __builder.AddAttribute(78, "class", "form-control");
            __builder.AddAttribute(79, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 57 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                    uniqueUserToSearch

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(80, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => uniqueUserToSearch = __value, uniqueUserToSearch));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddMarkupContent(81, "\r\n                    ");
            __builder.OpenElement(82, "option");
            __builder.AddAttribute(83, "value", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n");
#nullable restore
#line 61 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                     foreach (var uniqueUser in uniqueUsers)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(85, "                        ");
            __builder.OpenElement(86, "option");
            __builder.AddAttribute(87, "value", 
#nullable restore
#line 63 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                        uniqueUser

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(88, 
#nullable restore
#line 63 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                     uniqueUser

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n");
#nullable restore
#line 64 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(90, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(91, "\r\n                ");
            __builder.AddMarkupContent(92, "<label for=\"beginDate\">Type To Filter By:</label>\r\n                ");
            __builder.OpenElement(93, "select");
            __builder.AddAttribute(94, "class", "form-control");
            __builder.AddAttribute(95, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 67 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                    inWorker

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(96, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => inWorker = __value, inWorker));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddMarkupContent(97, "\r\n                    ");
            __builder.OpenElement(98, "option");
            __builder.AddAttribute(99, "value", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n");
#nullable restore
#line 71 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                     foreach (var uniqueWorker in uniqueWorkers)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(101, "                        ");
            __builder.OpenElement(102, "option");
            __builder.AddAttribute(103, "value", 
#nullable restore
#line 73 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                        uniqueWorker

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(104, 
#nullable restore
#line 73 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                       uniqueWorker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\r\n");
#nullable restore
#line 74 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(106, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n                ");
            __builder.OpenElement(108, "button");
            __builder.AddAttribute(109, "type", "button");
            __builder.AddAttribute(110, "class", "btn btn-default");
            __builder.AddAttribute(111, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 76 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                                                        SearchStats

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(112, "Search");
            __builder.CloseElement();
            __builder.AddMarkupContent(113, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(115, "\r\n        ");
            __builder.OpenElement(116, "div");
            __builder.AddAttribute(117, "class", "col-md-6");
            __builder.AddMarkupContent(118, "\r\n            ");
            __builder.AddMarkupContent(119, "<h3>AR Department Remaining Totals</h3>\r\n            ");
            __builder.OpenElement(120, "table");
            __builder.AddAttribute(121, "class", "table table-bordered");
            __builder.AddMarkupContent(122, "\r\n                ");
            __builder.AddMarkupContent(123, "<thead>\r\n                    <tr>\r\n                        <th>In Worker</th>\r\n                        <th>Remaining Total</th>\r\n                    </tr>\r\n                </thead>\r\n                ");
            __builder.OpenElement(124, "tbody");
            __builder.AddMarkupContent(125, "\r\n");
#nullable restore
#line 89 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                     foreach (var workerStatsRemainingTotal in workerStatsRemainingTotals)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(126, "                        ");
            __builder.OpenElement(127, "tr");
            __builder.AddMarkupContent(128, "\r\n                            ");
            __builder.OpenElement(129, "td");
            __builder.AddContent(130, 
#nullable restore
#line 92 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStatsRemainingTotal.InWorker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(131, "\r\n                            ");
            __builder.OpenElement(132, "td");
            __builder.AddContent(133, 
#nullable restore
#line 93 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                                 workerStatsRemainingTotal.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(134, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(135, "\r\n");
#nullable restore
#line 95 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(136, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(137, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(138, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(139, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(140, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n");
#nullable restore
#line 101 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 103 "G:\Employee\ZachL\WorkerStats\WorkerStats\Pages\AccountReviewStats.razor"
       
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