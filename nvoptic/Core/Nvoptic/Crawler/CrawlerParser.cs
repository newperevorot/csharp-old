using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace NvopticParser.Core.Nvoptic.Crawler
{
    class CrawlerParser : IParser<List<string>>
    {
        public List<string> Parse(IHtmlDocument document)
        {
            List<string> list = new List<string>();
            var items = document.QuerySelectorAll("ul.menu-h a");

            foreach (var item in items)
            {
                list.Add("http://nvoptic.ru" + item.GetAttribute("href"));
            }

            return list;
        }
    }
}
