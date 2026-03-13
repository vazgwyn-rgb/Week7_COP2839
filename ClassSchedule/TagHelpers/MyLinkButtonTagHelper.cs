using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing; 

namespace ClassSchedule.TagHelpers
{
    [HtmlTargetElement("my-link-button")]
    public class MyLinkButtonTagHelper : TagHelper
    {
        private readonly LinkGenerator _linkGenerator;

        public MyLinkButtonTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
    public string? Action { get; set; }
        public string? Controller { get; set; }
        public string? Id { get; set; }
        public bool IsActive { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = default!;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string action = Action ??
                ViewContext.RouteData.Values["action"]?.ToString() ?? string.Empty;

            string controller = Controller ??
                ViewContext.RouteData.Values["controller"]?.ToString() ?? string.Empty;

            object? routeValues = Id == null ? null : new { id = Id };

            string? url = _linkGenerator.GetPathByAction(
                action,
                controller,
                routeValues
                ) ?? "#";

            string cssClasses = IsActive
                ? "btn btn-dark"
                : "btn btn-outline-dark";
            output.BuildLink(url, cssClasses);
        }
    }
}