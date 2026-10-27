using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCSportStore.TagHelpers
{
    [HtmlTargetElement("first-tag")]
    public class FirstTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.Append("my first tag helper");
        }
    }
}
