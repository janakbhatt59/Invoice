using Invoice.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Invoice
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString AutoComplete(this System.Web.Mvc.HtmlHelper html, AutoCompleteViewModel model)
        {
            return html.Partial("~/Views/Shared/AutoComplete.cshtml", model);
        }
    }
}
