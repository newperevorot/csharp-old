using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace NvopticParser.Core.Nvoptic
{
    class NvParser : IParser<List<NvopticElement>>
    {
        public List<NvopticElement> Parse(IHtmlDocument document)
        {
            List<NvopticElement> list = new List<NvopticElement>();
            var items = document.QuerySelectorAll("ul.product-list>li");
            foreach(var item in items)
            {
                NvopticElement nv = new NvopticElement();
                nv.ProductName = item.QuerySelector("img[itemprop='image']").GetAttribute("title");
                nv.ImgUrl = "http://nvoptic.ru" + item.QuerySelector("img[itemprop='image']").GetAttribute("src");
                nv.Price = int.Parse(item.QuerySelector("span.price").InnerHtml.Split(new char[] { '<' })[0].Replace(" ", ""));
                nv.Description1 = item.QuerySelector("span[itemprop='description']>p").InnerHtml;

                list.Add(nv);
            }
            return list;
        }
    }
}
