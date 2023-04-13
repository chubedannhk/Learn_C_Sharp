using FlowerShop.Service;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FlowerShop.TagHelpers;

// dau tien ke thua thua tu :TagHelper

// dat tien the tuy theo mong muon

//TagStructure = TagStructure.NormalOrSelfClosing => giup the co the tu dong dong hoac vua mo vua dong: Vd: <table></table>, <br/>
[HtmlTargetElement("category", TagStructure = TagStructure.NormalOrSelfClosing | TagStructure.WithoutEndTag)]
// nham f12 de ra TagHelper
public class CategoryTagHelper : TagHelper
{
    // injection len de giup lay duong dan ve cai View
    [ViewContext]
    //  khai bao voi no rang ViewContext khong phai ten goi len
    [HtmlAttributeNotBound]
    public ViewContext viewContext { get; set; }
  

    private IHtmlHelper htmlHelper;
    //
    private CategoryService categoryService;
    //
    private ProductService productService;
    // no la interface thi phai trich no len moi dung duoc
    public CategoryTagHelper(IHtmlHelper _htmlHelper, CategoryService _categoryService, ProductService _productService)
    {
        htmlHelper = _htmlHelper;
        categoryService = _categoryService;
        productService = _productService;
    }

    //Asysn su ly bat dong bo
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // tu cha ep ve cai con => ve toi folder share roi do
        (htmlHelper as IViewContextAware).Contextualize(viewContext);
     
        htmlHelper.ViewBag.categories = categoryService.findAll();
     
        // cho Tagname rong 
        output.TagName = "";

        // dung bat dong bo de load du lieu len
        output.Content.SetHtmlContent(await htmlHelper.PartialAsync("TagHelpers/Category/Index"));
    }
}
