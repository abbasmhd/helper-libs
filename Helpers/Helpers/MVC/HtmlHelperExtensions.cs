using System.Web.Mvc.Html;

namespace System.Web.Mvc {

    public static class HtmlHelperExtensions
    {

        public static HtmlString ValidationSummaryBootstrap(this HtmlHelper htmlHelper)
        {
            if(htmlHelper == null) {
                throw new ArgumentNullException(nameof(htmlHelper));
            }
            return htmlHelper.ViewData.ModelState.IsValid
                       ? new HtmlString(String.Empty)
                       : new HtmlString($"<div class=\"alert alert-danger\">{htmlHelper.ValidationSummary()}</div>");
        }

    }

}