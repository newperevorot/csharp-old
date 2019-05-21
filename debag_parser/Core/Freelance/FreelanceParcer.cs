using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace FreelanceParser.Core.Freelance
{
    class FreelanceParcer : IParser<List<FreelanceTask>>
    {
        public List<FreelanceTask> Parse(IHtmlDocument document)
        {
            List<FreelanceTask> list = new List<FreelanceTask>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("proj") && item.ClassName.Contains("public"));
            
            foreach(var item in items)
            {
                int id = int.Parse(item.GetAttribute("data-project-id"));
                string title = item.QuerySelector("a>span").InnerHtml;
                string price = item.QuerySelector("span>b.cost_xs").InnerHtml;
                string link = item.QuerySelector("a").GetAttribute("href");
                link = $"https://freelance.ru{link}";
                FreelanceTask fl = new FreelanceTask(id, title, price, link);
                list.Add(fl);
            }

            return list;
        }
    }
}
