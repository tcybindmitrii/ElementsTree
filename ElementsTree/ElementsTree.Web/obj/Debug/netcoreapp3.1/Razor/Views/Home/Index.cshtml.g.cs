#pragma checksum "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb4d6bbbe7467bf838e02a9327b4bce52410f82e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4d6bbbe7467bf838e02a9327b4bce52410f82e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37f2e5ff0e8dd269b65e43c86fefbc3d2b176233", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/node_modules/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/node_modules/jstree/dist/jstree.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <div class=""trees-height row"">
        <div class=""column"">
            <div>User tree</div>
            <div id=""CachedTreeView"" class=""tree-container""></div>
        </div>
        <div class=""column vertical-center"">
            <input type=""button"" id=""copyItem"" value=""&#60;&#60;&#60;"" />
        </div>
        <div class=""column"">
            <div>Data base tree</div>
            <div id=""DBTreeView"" class=""tree-container ""></div>
        </div>
    </div>
    <div>
        <input type=""button"" id=""applyItems"" value=""Apply"" />
        <input type=""button"" id=""resetItem"" value=""Reset"" />
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb4d6bbbe7467bf838e02a9327b4bce52410f82e4554", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb4d6bbbe7467bf838e02a9327b4bce52410f82e5593", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script type=\'text/javascript\'>\r\n    $(document).ready(function ($) {\r\n\r\n        var dbTreeJSON = ");
#nullable restore
#line 31 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                    Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.dbTreeJSON)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n        var localTreeJSON = ");
#nullable restore
#line 32 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                       Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.localTreeJSON)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

        var dbTreeView = $('#DBTreeView').jstree({
            core: {
                data: dbTreeJSON,
                themes: {
                    icons: true
                }
            },
        });
        var cachedTreeView = $('#CachedTreeView').jstree({
            core: {
                multiple: false,
                data: localTreeJSON,
                check_callback: true,
                themes: {
                    url: true,
                    icons: true
                }
            },
            plugins: [""contextmenu"", ""types""],
            contextmenu: {
                items: function ($node) {
                    var userTree = $(""#CachedTreeView"").jstree(true);
                    if ($node.state.disabled)
                        return;
                    return {
                        Create: {
                            separator_before: false,
                            separator_after: false,
                            label: ""Create");
            WriteLiteral(@""",
                            action: function () {
                                var parentId = $node.id;
                                userTree.create_node($node, undefined, undefined, function (e) {
                                    $.ajax({
                                        url: '");
#nullable restore
#line 67 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                                         Write(Url.Action("Add"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                                        type: 'POST',
                                        data: { value: e.text, parentId: parentId },
                                        success: function (response) { successDefault(response); }
                                    });
                                });
                            }
                        },
                        Rename: {
                            separator_before: false,
                            separator_after: false,
                            label: ""Rename"",
                            action: function () {
                                userTree.edit($node);
                            }
                        },
                        Remove: {
                            separator_before: false,
                            separator_after: false,
                            label: ""Remove"",
                            action: function () {
                                $.ajax({
        ");
            WriteLiteral("                            url: \'");
#nullable restore
#line 89 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                                     Write(Url.Action("Remove"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                                    type: 'POST',
                                    data: { nodeId: $node.id },
                                    success: function (response) {
                                        successDefault(response);
                                    }
                                });
                            }
                        }
                    };
                }
            }
        }).on('rename_node.jstree', function (e, data) {
            $.ajax({
                url: '");
#nullable restore
#line 103 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                 Write(Url.Action("Edit"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'POST',
                data: { nodeId: data.node.id, newValue: data.text },
                success: function (response) {
                    if (!response.success) {
                        alert(response.responseText);
                        window.location.reload();
                    }
                }
            });
        }).on(""keydown"", "".jstree-rename-input"", function (e) {
            $('.jstree-rename-input').attr('maxLength', 10);
        });

        $(""#copyItem"").click(function (e) {

            var selNodeId = dbTreeView.jstree(""get_selected"");

            if (selNodeId.length !== 0)
                $.ajax({
                    url: '");
#nullable restore
#line 123 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                     Write(Url.Action("CopyFromDb"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    type: 'POST',
                    data: { dbNodeId: selNodeId },
                    success: function (response) { successDefault(response); }
                });
            return false;
        });
        $(""#applyItems"").click(function (e) {

            $.ajax({
                url: '");
#nullable restore
#line 133 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                 Write(Url.Action("Apply"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'POST',
                success: function (response) { window.location.reload(); }
            });
            return false;
        });
        $(""#resetItem"").click(function (e) {

            $.ajax({
                url: '");
#nullable restore
#line 142 "C:\Users\Tervin\Source\Repos\ElementsTree\ElementsTree.Web\Views\Home\Index.cshtml"
                 Write(Url.Action("Reset"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'POST',
                success: function (response) { window.location.reload(); }
            });

            return false;
        });

        function successDefault(response) {
            if (response.success) {
                cachedTreeView.jstree(true).settings.core.data = response.localTreeJSON;
                cachedTreeView.jstree(true).refresh();
            }
            else
                alert(response.responseText);
        }
    });
</script>");
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
