#pragma checksum "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0326ef1b2ba17634b7fa1e4e97dac3638666625d"
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
#nullable restore
#line 15 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
 if (workerStats == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.AddMarkupContent(1, "<form>\r\n        <input type=\"button\" id=\"backButton\" class=\"btn btn-default\" value=\"Back to worker stats\" onclick=\"history.back()\">\r\n    </form>\r\n    ");
            __builder.AddMarkupContent(2, "<h3>No Search Results For:</h3>\r\n    ");
            __builder.OpenElement(3, "h5");
            __builder.AddContent(4, "Start Date: ");
            __builder.AddContent(5, 
#nullable restore
#line 21 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                     convertedStartDateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.OpenElement(7, "h5");
            __builder.AddContent(8, "End Date: ");
            __builder.AddContent(9, 
#nullable restore
#line 22 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                   convertedEndDateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.OpenElement(11, "h5");
            __builder.AddContent(12, "User: ");
            __builder.AddContent(13, 
#nullable restore
#line 23 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
               uniqueUserToSearch

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n    ");
            __builder.OpenElement(15, "h5");
            __builder.AddContent(16, "Type: ");
            __builder.AddContent(17, 
#nullable restore
#line 24 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
               inWorker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n");
#nullable restore
#line 25 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "container-fluid");
            __builder.AddMarkupContent(21, "\r\n    ");
            __builder.AddMarkupContent(22, "<form>\r\n        <input type=\"button\" id=\"backButton\" class=\"btn btn-default\" value=\"Back To Worker Stats\" onclick=\"history.back()\">\r\n    </form>\r\n    ");
            __builder.AddMarkupContent(23, "<h3>Search Results For:</h3>\r\n    ");
            __builder.AddMarkupContent(24, @"<div class=""row"">
        <div class=""col-md-3"">
            <h5>Start Date:</h5>
        </div>
        <div class=""col-md-3"">
            <h5>End Date:</h5>
        </div>
        <div class=""col-md-3"">
            <h5>Employee:</h5>
        </div>
        <div class=""col-md-3"">
            <h5>Type:</h5>
        </div>
    </div>
    ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "row");
            __builder.AddMarkupContent(27, "\r\n        ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "col-md-3");
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.OpenElement(31, "h5");
            __builder.AddContent(32, 
#nullable restore
#line 49 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                 convertedStartDateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n        ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "col-md-3");
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.OpenElement(38, "h5");
            __builder.AddContent(39, 
#nullable restore
#line 52 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                 convertedEndDateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n        ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "class", "col-md-3");
            __builder.AddMarkupContent(44, "\r\n            ");
            __builder.OpenElement(45, "h5");
            __builder.AddContent(46, 
#nullable restore
#line 55 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                 uniqueUserToSearch

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n        ");
            __builder.OpenElement(49, "div");
            __builder.AddAttribute(50, "class", "col-md-3");
            __builder.AddMarkupContent(51, "\r\n            ");
            __builder.OpenElement(52, "h5");
            __builder.AddContent(53, 
#nullable restore
#line 58 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                 inWorker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n    ");
            __builder.OpenElement(57, "div");
            __builder.AddAttribute(58, "class", "row");
            __builder.AddMarkupContent(59, "\r\n        ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "col-md-12");
            __builder.AddMarkupContent(62, "\r\n            ");
            __builder.OpenElement(63, "table");
            __builder.AddAttribute(64, "class", "table table-bordered");
            __builder.AddMarkupContent(65, "\r\n                ");
            __builder.AddMarkupContent(66, @"<thead>
                    <tr>
                        <th>Employee</th>
                        <th>Avg</th>
                        <th>Count</th>
                        <th>Type</th>
                        <th>Time Spent</th>
                    </tr>
                </thead>
                ");
            __builder.OpenElement(67, "tbody");
            __builder.AddMarkupContent(68, "\r\n");
#nullable restore
#line 74 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                     foreach (var workerStat in workerStats)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(69, "                        ");
            __builder.OpenElement(70, "tr");
            __builder.AddMarkupContent(71, "\r\n                            ");
            __builder.OpenElement(72, "td");
            __builder.AddContent(73, 
#nullable restore
#line 77 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                 workerStat.Username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                            ");
            __builder.OpenElement(75, "td");
            __builder.AddContent(76, 
#nullable restore
#line 78 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                 workerStat.AverageSecondsElapsed

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n                            ");
            __builder.OpenElement(78, "td");
            __builder.AddContent(79, 
#nullable restore
#line 79 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                 workerStat.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(80, "\r\n                            ");
            __builder.OpenElement(81, "td");
            __builder.AddContent(82, 
#nullable restore
#line 80 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                 workerStat.InWorker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n                            ");
            __builder.OpenElement(84, "td");
            __builder.AddContent(85, 
#nullable restore
#line 81 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                 workerStat.ConvertedTimeSpent

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n");
#nullable restore
#line 83 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(88, "                    ");
            __builder.OpenElement(89, "tr");
            __builder.AddMarkupContent(90, "\r\n                        ");
            __builder.AddMarkupContent(91, "<td><b>Totals</b></td>\r\n");
#nullable restore
#line 86 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                         foreach (var workerStat in workerStats)
                        {
                            totalCount += long.Parse(workerStat.Count);
                            totalTimeSpent += long.Parse(workerStat.TimeSpent);
                        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(92, "                        <td></td>\r\n                        ");
            __builder.OpenElement(93, "td");
            __builder.OpenElement(94, "b");
            __builder.AddContent(95, 
#nullable restore
#line 92 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                totalCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(96, "\r\n                        <td></td>\r\n                        ");
            __builder.OpenElement(97, "td");
            __builder.OpenElement(98, "b");
            __builder.AddContent(99, 
#nullable restore
#line 94 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
                                WorkerStatsService.convertSeconds(totalTimeSpent.ToString())

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(103, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n");
#nullable restore
#line 101 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 102 "G:\Instructions\Project Analyst\ZAL\WorkerStats\WorkerStats\Pages\SearchResults.razor"
       
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
