#pragma checksum "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\Index2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1473afedb948fc4ac088baa41cd0e18c83e62e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Gestion_Scolarite.Pages.Pages_Index2), @"mvc.1.0.razor-page", @"/Pages/Index2.cshtml")]
namespace Gestion_Scolarite.Pages
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
#line 1 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\_ViewImports.cshtml"
using Gestion_Scolarite;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1473afedb948fc4ac088baa41cd0e18c83e62e1", @"/Pages/Index2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f55cc80d0be406d0eb28231a568b84878b06e777", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index2 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\Index2.cshtml"
  
    ViewData["Title"] = "Enseignant";
    Layout = "~/Pages/Shared/_LayoutEnseignant.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Enseignant</h1>\r\n<h2>");
#nullable restore
#line 8 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\Index2.cshtml"
Write(Model.Enseignant.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\Index2.cshtml"
                     Write(Model.Enseignant.Prenom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gestion_Scolarite.Pages.Index2Model> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gestion_Scolarite.Pages.Index2Model> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gestion_Scolarite.Pages.Index2Model>)PageContext?.ViewData;
        public Gestion_Scolarite.Pages.Index2Model Model => ViewData.Model;
    }
}
#pragma warning restore 1591
