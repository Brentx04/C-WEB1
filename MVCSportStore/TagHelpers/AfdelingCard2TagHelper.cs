using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCSportStore.ViewModels;

namespace MVCSportStore.TagHelpers
{
    // Oefening: zelfde card als AfdelingCardTagHelper, maar opgebouwd met TagBuilder
    [HtmlTargetElement("afdeling-card2", Attributes = "card")]
    public class AfdelingCard2TagHelper : TagHelper
    {
        public AfdelingCard Card { get; set; } = new AfdelingCard();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder title = new TagBuilder("h4");
            title.AddCssClass("card-title");
            title.InnerHtml.Append(Card.AfdelingNaam);

            TagBuilder position = new TagBuilder("p");
            position.AddCssClass("card-position");
            position.InnerHtml.Append($"{Card.LandCode} - {Card.Locatie}");

            TagBuilder description = new TagBuilder("p");
            description.AddCssClass("card-description");
            description.InnerHtml.Append($"De afdeling {Card.AfdelingNaam} ligt in {Card.Land}.");

            TagBuilder body = new TagBuilder("div");
            body.AddCssClass("card-body");
            body.InnerHtml.AppendHtml(title);
            body.InnerHtml.AppendHtml(position);
            body.InnerHtml.AppendHtml(description);

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "card mt-3");
            output.Content.SetHtmlContent(body);
        }
    }
}
