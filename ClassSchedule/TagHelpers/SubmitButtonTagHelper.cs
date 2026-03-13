using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ClassSchedule.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "type")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        { 
            if (output.Attributes.TryGetAttribute("type", out TagHelperAttribute? attr))
            {
            string? typeValue = attr.Value?.ToString();
        if (!string.IsNullOrEmpty(typeValue) &&
            typeValue.Equals("submit", StringComparison.OrdinalIgnoreCase))
            {
        output.Attributes.AppendCssClass("btn");
            output.Attributes.AppendCssClass("btn-dark");
            }
           }
          }
    }
}
//