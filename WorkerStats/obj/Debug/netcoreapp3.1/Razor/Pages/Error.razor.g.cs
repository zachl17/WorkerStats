#pragma checksum "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\Error.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a58c43978ce1fa9f8e93ccf3a2468e7379811ea"
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
#line 3 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\Error.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/error")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/error/{startDateTime}/{endDateTime}")]
    public partial class Error : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container-fluid");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<form>\r\n        <input type=\"button\" class=\"btn btn-default\" value=\"Back To Worker Stats\" onclick=\"history.back()\">\r\n    </form>\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "row");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "col-md-12");
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "h1");
            __builder.AddAttribute(11, "style", "color:#ff0000");
            __builder.AddContent(12, "The start date you entered was: ");
            __builder.AddContent(13, 
#nullable restore
#line 11 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\Error.razor"
                                                                       convertedStartDateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n            ");
            __builder.OpenElement(15, "h1");
            __builder.AddAttribute(16, "style", "color:#ff0000");
            __builder.AddContent(17, "The end date you entered was: ");
            __builder.AddContent(18, 
#nullable restore
#line 12 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\Error.razor"
                                                                     convertedEndDateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n            ");
            __builder.AddMarkupContent(20, "<h1 style=\"color:#ff0000\">But the start date must be earlier than the end date!</h1>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "G:\Instructions\Visual_Studio\ZachL\WorkerStats\WorkerStats\Pages\Error.razor"
       
    //Parameters for SearchResults razor component
    [Parameter]
    public string startDateTime { get; set; }
    [Parameter]
    public string endDateTime { get; set; }

    public string convertedStartDateTime;
    public string convertedEndDateTime;

    protected override async Task OnInitializedAsync()
    {
        convertedStartDateTime = DateTime.ParseExact(startDateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
        convertedEndDateTime = DateTime.ParseExact(endDateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
