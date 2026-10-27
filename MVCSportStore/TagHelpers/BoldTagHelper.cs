using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCSportStore.TagHelpers
{
    [HtmlTargetElement("bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<b>");
            output.PostContent.SetHtmlContent("</b>");
        }
    }
}
