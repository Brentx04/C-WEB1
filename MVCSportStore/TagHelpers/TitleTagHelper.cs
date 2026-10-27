using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCSportStore.TagHelpers
{
    [HtmlTargetElement("title-tag", Attributes = "title-text")]
    public class TitleTagHelper : TagHelper
    {
        // kebab-case in Razor (title-text)  <->  PascalCase in C# (TitleText)
        public string TitleText { get; set; } = string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<h1 class='display-4'>{TitleText}</h1>");
        }
    }
}
