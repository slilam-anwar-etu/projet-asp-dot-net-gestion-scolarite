#pragma checksum "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8506f7fdedfcb0bf659d8997f7fea9a34f07e42d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Gestion_Scolarite.Pages.EtudiantVues.Pages_EtudiantVues_EtuSeances), @"mvc.1.0.razor-page", @"/Pages/EtudiantVues/EtuSeances.cshtml")]
namespace Gestion_Scolarite.Pages.EtudiantVues
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8506f7fdedfcb0bf659d8997f7fea9a34f07e42d", @"/Pages/EtudiantVues/EtuSeances.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f55cc80d0be406d0eb28231a568b84878b06e777", @"/Pages/_ViewImports.cshtml")]
    public class Pages_EtudiantVues_EtuSeances : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
  
    ViewData["Title"] = "Seances";
    Layout = "~/Pages/Shared/_LayoutEtudiant.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Séances</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Date
            </th>
            <th>
                Matière
            </th>
            <th>
                Enseignant
            </th>
            <th>
                Durée
            </th>
            <th>
                Type
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
 foreach (var item in Model.Seance) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date_Seance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
           Write(Html.DisplayFor(modelItem => item.Matiere.Designation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
           Write(Html.DisplayFor(modelItem => item.Matiere.Enseignant.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => item.Matiere.Enseignant.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
           Write(Html.DisplayFor(modelItem => item.Heures));

#line default
#line hidden
#nullable disable
            WriteLiteral(" h : ");
#nullable restore
#line 44 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
                                                          Write(Html.DisplayFor(modelItem => item.Minutes));

#line default
#line hidden
#nullable disable
            WriteLiteral(" min\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
           Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 50 "C:\Users\Pavilion\source\repos\Gestion_Scolarite\Gestion_Scolarite\Pages\EtudiantVues\EtuSeances.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gestion_Scolarite.Pages.EtudiantVues.EtuSeancesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gestion_Scolarite.Pages.EtudiantVues.EtuSeancesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gestion_Scolarite.Pages.EtudiantVues.EtuSeancesModel>)PageContext?.ViewData;
        public Gestion_Scolarite.Pages.EtudiantVues.EtuSeancesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591