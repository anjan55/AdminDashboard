#pragma checksum "E:\ProductManagement\ProductManagement\Views\Employee\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0055ce9be0fbfca2dc8692d0edbcf5ae0bb9729"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Details), @"mvc.1.0.view", @"/Views/Employee/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employee/Details.cshtml", typeof(AspNetCore.Views_Employee_Details))]
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
#line 1 "E:\ProductManagement\ProductManagement\Views\_ViewImports.cshtml"
using ProductManagement.ViewModels;

#line default
#line hidden
#line 2 "E:\ProductManagement\ProductManagement\Views\_ViewImports.cshtml"
using ProductManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0055ce9be0fbfca2dc8692d0edbcf5ae0bb9729", @"/Views/Employee/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10827a39c2752d4279605801b45cbfceda10631b", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\ProductManagement\ProductManagement\Views\Employee\Details.cshtml"
   
    
    ViewBag.Title = Model.PageTitle;

#line default
#line hidden
            BeginContext(87, 42, true);
            WriteLiteral("\r\n    <h1>Hello from Details.cshtml</h1>\r\n");
            EndContext();
#line 9 "E:\ProductManagement\ProductManagement\Views\Employee\Details.cshtml"
      
       // var employee = ViewData["Employee"] as ProductManagement.Models.Employee;

    

#line default
#line hidden
            BeginContext(231, 16, true);
            WriteLiteral("    <div>  Name ");
            EndContext();
            BeginContext(248, 19, false);
#line 13 "E:\ProductManagement\ProductManagement\Views\Employee\Details.cshtml"
           Write(Model.Employee.Name);

#line default
#line hidden
            EndContext();
            BeginContext(267, 26, true);
            WriteLiteral(" </div>\r\n    <div>  Email ");
            EndContext();
            BeginContext(294, 20, false);
#line 14 "E:\ProductManagement\ProductManagement\Views\Employee\Details.cshtml"
            Write(Model.Employee.Email);

#line default
#line hidden
            EndContext();
            BeginContext(314, 31, true);
            WriteLiteral(" </div>\r\n    <div>  Department ");
            EndContext();
            BeginContext(346, 25, false);
#line 15 "E:\ProductManagement\ProductManagement\Views\Employee\Details.cshtml"
                 Write(Model.Employee.Department);

#line default
#line hidden
            EndContext();
            BeginContext(371, 9, true);
            WriteLiteral(" </div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
