using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;

namespace FreelanceParser.Core.Freelance
{
    class FreelanceParserDescription:IParser<FreelanceTask>
    {
        public FreelanceTask fl;

        public FreelanceParserDescription(FreelanceTask fl)
        {
            this.fl = fl;
        }

        public FreelanceTask Parse(IHtmlDocument document)
        {
            ////var items = document.QuerySelectorAll("p").Where(item => item.ClassName != null && item.ClassName.Contains("href_me"));
            //var item = document.QuerySelector("p.href_me");
            ////foreach (var item in items)
            ////{
            ////    fl.Description = item.TextContent;
            ////}
            ////try
            ////{
            ////    fl.Description = item.TextContent;
            ////}
            ////catch
            ////{
            ////    fl.Description = null;
            ////}
            //if (1==1)
            //{
            //    fl.Description = item.
            //}
            //else
            //{
            //    fl.Description = null;
            //}
            //return fl;
            var p = document.QuerySelector("p");
            if (p.InnerHtml.Contains("Получить доступ"))
            {
                return fl;
            }
            fl.Description = document.QuerySelector("p.href_me").TextContent;

            var allDt = document.QuerySelectorAll("dt");
            foreach (var dt in allDt)
            {
                if (dt.InnerHtml.Contains("Срок выполнения:"))
                {
                    fl.Deadline = dt.NextSibling.TextContent;
                }
                if (dt.InnerHtml.Contains("Варианты оплаты:"))
                {
                    fl.Prepayment = dt.NextSibling.TextContent;
                }
                if (dt.InnerHtml.Contains("Способ оплаты:"))
                {
                    List<string> payment = new List<string>();
                    var items_payment = dt.NextElementSibling.QuerySelectorAll("li");
                    foreach (var item in items_payment)
                    {
                        payment.Add(item.TextContent);
                    }
                    fl.Payment = string.Join(", ", payment);
                }
                if (dt.InnerHtml.Contains("Дата публикации:"))
                {
                    fl.PublishDate = dt.NextSibling.TextContent;
                }
            }

            var hElements = document.QuerySelector("div.avatar>a");
            fl.Employer = hElements.GetAttribute("title");
            
            //int count = 0;
            //foreach (var h in hElements)
            //{
            //    count++;

            //}
            //string hs = document.QuerySelector("h4").TextContent;
            //fl.Employer = hElements;

            //fl.PublishDate = document.QuerySelector("dl>dd:nth-of-type(5)").TextContent;
            //fl.Employer = document.QuerySelector("div.table h4>a").TextContent;
            //fl.Employer = document.QuerySelector("dt").NextSibling.TextContent;


            return fl;
        }
    }
}
