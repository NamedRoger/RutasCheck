#pragma checksum "C:\Users\Roger\source\repos\RutasCheck\Views\Shared\_Navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5829c1079bf2ca8b4f2c6a3529629222b7138619"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navbar), @"mvc.1.0.view", @"/Views/Shared/_Navbar.cshtml")]
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
#line 1 "C:\Users\Roger\source\repos\RutasCheck\Views\_ViewImports.cshtml"
using RutasCheck;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Roger\source\repos\RutasCheck\Views\_ViewImports.cshtml"
using RutasCheck.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Roger\source\repos\RutasCheck\Views\_ViewImports.cshtml"
using RutasCheck.ViewComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Roger\source\repos\RutasCheck\Views\_ViewImports.cshtml"
using RutasCheck.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5829c1079bf2ca8b4f2c6a3529629222b7138619", @"/Views/Shared/_Navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c5e34ca7bb426521ea6ce2a35f3ceb7b5a2473a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Navbar Header -->
<nav class=""navbar navbar-header navbar-expand-lg"" data-background-color=""blue2"">

    <div class=""container-fluid"">
        <div class=""collapse"" id=""search-nav"">
            
        </div>
        <ul class=""navbar-nav topbar-nav ml-md-auto align-items-center"">
            <li class=""nav-item toggle-nav-search hidden-caret"">
                <a class=""nav-link"" data-toggle=""collapse"" href=""#search-nav"" role=""button"" aria-expanded=""false"" aria-controls=""search-nav"">
                    <i class=""fa fa-search""></i>
                </a>
            </li>
            <li class=""nav-item dropdown hidden-caret"">
                <a class=""nav-link dropdown-toggle"" href=""#"" id=""messageDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                    <i class=""fa fa-envelope""></i>
                </a>
                <ul class=""dropdown-menu messages-notif-box animated fadeIn"" aria-labelledby=""messageDropdown"">
                    ");
            WriteLiteral(@"<li>
                        <div class=""dropdown-title d-flex justify-content-between align-items-center"">
                            Messages
                            <a href=""#"" class=""small"">Mark all as read</a>
                        </div>
                    </li>
                    <li>
                        <div class=""message-notif-scroll scrollbar-outer"">
                            <div class=""notif-center"">
                                <a href=""#"">
                                    <div class=""notif-img"">
                                        <img src=""../assets/img/jm_denis.jpg"" alt=""Img Profile"">
                                    </div>
                                    <div class=""notif-content"">
                                        <span class=""subject"">Jimmy Denis</span>
                                        <span class=""block"">
                                            How are you ?
                                        </span>
                 ");
            WriteLiteral(@"                       <span class=""time"">5 minutes ago</span>
                                    </div>
                                </a>
                                <a href=""#"">
                                    <div class=""notif-img"">
                                        <img src=""../assets/img/chadengle.jpg"" alt=""Img Profile"">
                                    </div>
                                    <div class=""notif-content"">
                                        <span class=""subject"">Chad</span>
                                        <span class=""block"">
                                            Ok, Thanks !
                                        </span>
                                        <span class=""time"">12 minutes ago</span>
                                    </div>
                                </a>
                                <a href=""#"">
                                    <div class=""notif-img"">
                                        <img src");
            WriteLiteral(@"=""../assets/img/mlane.jpg"" alt=""Img Profile"">
                                    </div>
                                    <div class=""notif-content"">
                                        <span class=""subject"">Jhon Doe</span>
                                        <span class=""block"">
                                            Ready for the meeting today...
                                        </span>
                                        <span class=""time"">12 minutes ago</span>
                                    </div>
                                </a>
                                <a href=""#"">
                                    <div class=""notif-img"">
                                        <img src=""../assets/img/talha.jpg"" alt=""Img Profile"">
                                    </div>
                                    <div class=""notif-content"">
                                        <span class=""subject"">Talha</span>
                                        <span class");
            WriteLiteral(@"=""block"">
                                            Hi, Apa Kabar ?
                                        </span>
                                        <span class=""time"">17 minutes ago</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li>
                        <a class=""see-all"" href=""javascript:void(0);"">See all messages<i class=""fa fa-angle-right""></i> </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item dropdown hidden-caret"">
                <a class=""nav-link dropdown-toggle"" href=""#"" id=""notifDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                    <i class=""fa fa-bell""></i>
                    <span class=""notification"">4</span>
                </a>
                <ul class=""dropdown-menu notif-box animated fadeIn"" aria-labe");
            WriteLiteral(@"lledby=""notifDropdown"">
                    <li>
                        <div class=""dropdown-title"">You have 4 new notification</div>
                    </li>
                    <li>
                        <div class=""notif-scroll scrollbar-outer"">
                            <div class=""notif-center"">
                                <a href=""#"">
                                    <div class=""notif-icon notif-primary""> <i class=""fa fa-user-plus""></i> </div>
                                    <div class=""notif-content"">
                                        <span class=""block"">
                                            New user registered
                                        </span>
                                        <span class=""time"">5 minutes ago</span>
                                    </div>
                                </a>
                                <a href=""#"">
                                    <div class=""notif-icon notif-success""> <i class=""fa fa-comment");
            WriteLiteral(@"""></i> </div>
                                    <div class=""notif-content"">
                                        <span class=""block"">
                                            Rahmad commented on Admin
                                        </span>
                                        <span class=""time"">12 minutes ago</span>
                                    </div>
                                </a>
                                <a href=""#"">
                                    <div class=""notif-img"">
                                        <img src=""../assets/img/profile2.jpg"" alt=""Img Profile"">
                                    </div>
                                    <div class=""notif-content"">
                                        <span class=""block"">
                                            Reza send messages to you
                                        </span>
                                        <span class=""time"">12 minutes ago</span>
                    ");
            WriteLiteral(@"                </div>
                                </a>
                                <a href=""#"">
                                    <div class=""notif-icon notif-danger""> <i class=""fa fa-heart""></i> </div>
                                    <div class=""notif-content"">
                                        <span class=""block"">
                                            Farrah liked Admin
                                        </span>
                                        <span class=""time"">17 minutes ago</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li>
                        <a class=""see-all"" href=""javascript:void(0);"">See all notifications<i class=""fa fa-angle-right""></i> </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item dropdown hidden-caret"">
                <a class");
            WriteLiteral(@"=""nav-link"" data-toggle=""dropdown"" href=""#"" aria-expanded=""false"">
                    <i class=""fas fa-layer-group""></i>
                </a>
                <div class=""dropdown-menu quick-actions quick-actions-info animated fadeIn"">
                    <div class=""quick-actions-header"">
                        <span class=""title mb-1"">Quick Actions</span>
                        <span class=""subtitle op-8"">Shortcuts</span>
                    </div>
                    <div class=""quick-actions-scroll scrollbar-outer"">
                        <div class=""quick-actions-items"">
                            <div class=""row m-0"">
                                <a class=""col-6 col-md-4 p-0"" href=""#"">
                                    <div class=""quick-actions-item"">
                                        <i class=""flaticon-file-1""></i>
                                        <span class=""text"">Generated Report</span>
                                    </div>
                                <");
            WriteLiteral(@"/a>
                                <a class=""col-6 col-md-4 p-0"" href=""#"">
                                    <div class=""quick-actions-item"">
                                        <i class=""flaticon-database""></i>
                                        <span class=""text"">Create New Database</span>
                                    </div>
                                </a>
                                <a class=""col-6 col-md-4 p-0"" href=""#"">
                                    <div class=""quick-actions-item"">
                                        <i class=""flaticon-pen""></i>
                                        <span class=""text"">Create New Post</span>
                                    </div>
                                </a>
                                <a class=""col-6 col-md-4 p-0"" href=""#"">
                                    <div class=""quick-actions-item"">
                                        <i class=""flaticon-interface-1""></i>
                                 ");
            WriteLiteral(@"       <span class=""text"">Create New Task</span>
                                    </div>
                                </a>
                                <a class=""col-6 col-md-4 p-0"" href=""#"">
                                    <div class=""quick-actions-item"">
                                        <i class=""flaticon-list""></i>
                                        <span class=""text"">Completed Tasks</span>
                                    </div>
                                </a>
                                <a class=""col-6 col-md-4 p-0"" href=""#"">
                                    <div class=""quick-actions-item"">
                                        <i class=""flaticon-file""></i>
                                        <span class=""text"">Create New Invoice</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
           ");
            WriteLiteral(@" </li>
            <li class=""nav-item dropdown hidden-caret"">
                <a class=""nav-link dropdown-toggle profile-pic"" data-toggle=""dropdown"" href=""#"" aria-expanded=""false"">
                    <i class=""fas fa-user""></i>
                </a>
                <ul class=""dropdown-menu dropdown-user animated fadeIn"">
                    <div class=""dropdown-user-scroll scrollbar-outer"">
                        <li>
                            <div class=""user-box"">
                                <div class=""avatar-lg""><img src=""../assets/img/profile.jpg"" alt=""image profile"" class=""avatar-img rounded""></div>
                                <div class=""u-text"">
                                    <h4>");
#nullable restore
#line 211 "C:\Users\Roger\source\repos\RutasCheck\Views\Shared\_Navbar.cshtml"
                                   Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                </div>\r\n                            </div>\r\n                        </li>\r\n                        <li>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5829c1079bf2ca8b4f2c6a3529629222b713861917440", async() => {
                WriteLiteral("Logout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </li>\r\n                    </div>\r\n                </ul>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</nav>\r\n<!-- End Navbar -->\r\n");
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