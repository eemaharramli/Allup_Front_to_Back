#pragma checksum "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/Category/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c24971b800bdf9c2353d76eb5ddb375450dc13c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminPanel_Views_Category_Details), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/Category/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/_ViewImports.cshtml"
using AspNetPractise.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/_ViewImports.cshtml"
using AspNetPractise.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c24971b800bdf9c2353d76eb5ddb375450dc13c0", @"/Areas/AdminPanel/Views/Category/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80ef9c490f8e1287c7414d591bb94e55057471ee", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    public class Areas_AdminPanel_Views_Category_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/Category/Details.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"main-panel\">\n    <div class=\"content-wrapper\">\n      <div class=\"col-lg-12 stretch-card grid-margin\">\n        <div class=\"card\">\n          <div class=\"card-body\">\n            <h4 class=\"card-title\">");
#nullable restore
#line 13 "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/Category/Details.cshtml"
                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Info</h4>
            <table class=""table table-bordered"">
              <thead>
              <tr>
                <th> Category Name </th>
                <th> Is Main </th>
              </tr>
              </thead>
              <tbody>
              <tr class=""table-info"">
                <td> ");
#nullable restore
#line 23 "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/Category/Details.cshtml"
                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n                <td> ");
#nullable restore
#line 24 "/Users/elnur/Desktop/Allup_Front_to_Back/Allup_Front_to_Back/AspNetPractise/AspNetPractise/Areas/AdminPanel/Views/Category/Details.cshtml"
                Write(Html.Raw(Model.IsMain));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n              </tr>\n              </tbody>\n            </table>\n          </div>\n        </div>\n      </div>\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
