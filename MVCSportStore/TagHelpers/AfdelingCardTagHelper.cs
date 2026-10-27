using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCSportStore.ViewModels;

namespace MVCSportStore.TagHelpers
{
    [HtmlTargetElement(Attributes = "afdeling-card")]
    public class AfdelingCardTagHelper : TagHelper
    {
        public AfdelingCard AfdelingCard { get; set; } = new AfdelingCard();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='card'>";
            content += $@"<h4 class='card-title'>{AfdelingCard.AfdelingNaam}</h4>";
            content += $@"<p class='card-position'>{AfdelingCard.LandCode} - {AfdelingCard.Locatie}</p>";
            content += $@"<p class='card-description'>De afdeling {AfdelingCard.AfdelingNaam} ligt in {AfdelingCard.Land}. </p>";
            content += "</div>";

            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
