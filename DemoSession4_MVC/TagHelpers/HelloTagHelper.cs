using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DemoSession4_MVC.TagHelpers;

// dau tien ke thua thua tu :TagHelper

// dat tien the tuy theo mong muon

//TagStructure = TagStructure.NormalOrSelfClosing => giup the co the tu dong dong hoac vua mo vua dong: Vd: <table></table>, <br/>
[HtmlTargetElement("hello", TagStructure = TagStructure.NormalOrSelfClosing | TagStructure.WithoutEndTag)]
public class HelloTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // cau hinh cho Tag rong de khi view page source len khong con hien thi <hello></hello> nua
        output.TagName = "";
        output.Content.SetHtmlContent("<b><i><u>Hello Master NguyenHoangKhai</u></i></b>");
    }
}
