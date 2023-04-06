using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DemoSession4_MVC.TagHelpers;

// dau tien ke thua thua tu :TagHelper

// dat tien the tuy theo mong muon

//TagStructure = TagStructure.NormalOrSelfClosing => giup the co the tu dong dong hoac vua mo vua dong: Vd: <table></table>, <br/>
[HtmlTargetElement("hi", TagStructure = TagStructure.NormalOrSelfClosing | TagStructure.WithoutEndTag)]
public class HiTagHelper : TagHelper
{
    [HtmlAttributeName("fullName")]
    public string FullName { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // cau hinh cho Tag rong de khi view page source len khong con hien thi <hello></hello> nua
        output.TagName = "";
        output.Content.SetHtmlContent($"Hi <span style='color:red'> { FullName} </span>");
    }
}
