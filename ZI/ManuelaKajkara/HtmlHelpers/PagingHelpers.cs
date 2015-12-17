using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManuelaKajkara.Models;
using System.Text;
using System.Web.Mvc.Html;

namespace ManuelaKajkara.HtmlHelpers
{
    public static class PagingHelpers
    {
        private const int offset = 10;
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            if (pagingInfo.CurrentPage - offset > 1)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(1, pagingInfo.Sort));
                tag.InnerHtml = "1..";
                result.Append(tag.ToString());
            }
            for (int i = Math.Max(1, pagingInfo.CurrentPage - offset); i <= Math.Min(pagingInfo.TotalPages, pagingInfo.CurrentPage + offset); i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i, pagingInfo.Sort));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            if (pagingInfo.CurrentPage + offset < pagingInfo.TotalPages)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(pagingInfo.TotalPages, pagingInfo.Sort));
                tag.InnerHtml = ".." + pagingInfo.TotalPages;
                result.Append(tag.ToString());
            }


            PageRangeModel model = new PageRangeModel
            {
                Min = 1,
                Max = pagingInfo.TotalPages,
                Url = pageUrl(-7777, pagingInfo.Sort) //-7777 ćemo kasnije zamijeniti s konkretnom vrijednošću iz textboxa - vidi GoToPage.cshtml
            };

            result.Append(html.Partial("GoToPage", model));

            return MvcHtmlString.Create(result.ToString());
        }


    }
}