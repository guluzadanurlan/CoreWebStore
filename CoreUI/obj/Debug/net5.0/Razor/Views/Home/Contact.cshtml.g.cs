#pragma checksum "C:\Users\Computer clinic\Desktop\CoreComputers\CoreUI\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87781f810e5ebecae3733df54f9790ebe9a1950d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
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
#line 1 "C:\Users\Computer clinic\Desktop\CoreComputers\CoreUI\Views\_ViewImports.cshtml"
using CoreUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Computer clinic\Desktop\CoreComputers\CoreUI\Views\_ViewImports.cshtml"
using CoreUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Computer clinic\Desktop\CoreComputers\CoreUI\Views\_ViewImports.cshtml"
using CoreUI.HelpFolder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Computer clinic\Desktop\CoreComputers\CoreUI\Views\_ViewImports.cshtml"
using CoreUI.Models.ControllerModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87781f810e5ebecae3733df54f9790ebe9a1950d", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e6cd884f2f11c7d7fb1e78408914ba0952e5d7c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Computer clinic\Desktop\CoreComputers\CoreUI\Views\Home\Contact.cshtml"
  
   Layout="_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <!-- contact section start -->
      <div class=""contact_section layout_padding"">
         <div class=""container"">
            <h1 class=""contact_taital"">Contact Us</h1>
            <div class=""contact_section_2"">
               <div class=""mail_section_1"">
               <input type=""text"" class=""mail_text"" placeholder=""Name"" name=""text"">
               <input type=""text"" class=""mail_text"" placeholder=""Email"" name=""text"">
               <input type=""text"" class=""mail_text"" placeholder=""Phone Number"" name=""text"">
               <textarea class=""massage-bt"" placeholder=""Massage"" rows=""5"" id=""comment"" name=""Massage""></textarea>
               <div class=""send_bt""><a href=""#"">Send</a></div>
               </div>
            </div>
         </div>
      </div>
      <!-- contact section end -->
     ");
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