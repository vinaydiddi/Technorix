#pragma checksum "D:\code\newmvccore\Views\Admin\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac854d7a2a7bde4833053e48159141273a3486b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_NotFound), @"mvc.1.0.view", @"/Views/Admin/NotFound.cshtml")]
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
#line 1 "D:\code\newmvccore\Views\_ViewImports.cshtml"
using newmvccore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\code\newmvccore\Views\_ViewImports.cshtml"
using newmvccore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac854d7a2a7bde4833053e48159141273a3486b1", @"/Views/Admin/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e87384d85d653635b3c22f4ce4f90d247c1486da", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_NotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\code\newmvccore\Views\Admin\NotFound.cshtml"
  
    ViewData["Title"] = "NotFound";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>NotFound</h1>\r\n\r\n<h3>");
#nullable restore
#line 8 "D:\code\newmvccore\Views\Admin\NotFound.cshtml"
Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
