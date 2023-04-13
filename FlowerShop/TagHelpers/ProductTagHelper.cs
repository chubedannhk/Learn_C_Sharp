using FlowerShop.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FlowerShop.TagHelpers;

[HtmlTargetElement("Product", TagStructure = TagStructure.NormalOrSelfClosing | TagStructure.WithoutEndTag)]
public class ProductTagHelper : TagHelper
{
    // injection len de giup lay duong dan ve cai View
    [ViewContext]
    //  khai bao voi no rang ViewContext khong phai ten goi len
    [HtmlAttributeNotBound]
    public ViewContext viewContext { get; set; }
    [HtmlAttributeName("amount")]
    public int amount { get; set; }

    private IHtmlHelper htmlHelper;
    //
    private ProductService productService;

    public ProductTagHelper(IHtmlHelper _htmlHelper,ProductService _productService)
    {
        htmlHelper = _htmlHelper;
        productService = _productService;
    }

    //Asysn su ly bat dong bo
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // tu cha ep ve cai con => ve toi folder share roi do
        (htmlHelper as IViewContextAware).Contextualize(viewContext);

        htmlHelper.ViewBag.product = productService.sortPro(amount);
        // cho Tagname rong 
        output.TagName = "";

        // dung bat dong bo de load du lieu len
        output.Content.SetHtmlContent(await htmlHelper.PartialAsync("TagHelpers/Product/Index"));
    }
}
