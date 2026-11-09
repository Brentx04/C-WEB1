using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCVoertuig.TagHelpers
{
    // Stap 13 - TagHelper
    // Gebruik in een view:  <car-info aantal="5"></car-info>
    // Resultaat:
    //   <div class="btn btn-outline-primary m-3">Aantal voertuigen <span class="badge bg-primary">5</span></div>
    //
    // Klassenaam CarInfoTagHelper -> tag <car-info> (PascalCase wordt kebab-case, "TagHelper" valt weg)
    // Property Aantal -> attribuut aantal="..."
    // Vergeet niet: @addTagHelper *, MVCVoertuig in Views/_ViewImports.cshtml
    public class CarInfoTagHelper : TagHelper
    {
        public int Aantal { get; set; }

        public string Tekst { get; set; } = "Aantal voertuigen";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";                        // <car-info> wordt een <div>
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "btn btn-outline-primary m-3");
            output.Content.SetHtmlContent(
                $"{Tekst} <span class=\"badge bg-primary\">{Aantal}</span>");
        }
    }
}
