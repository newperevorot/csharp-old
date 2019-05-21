using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core.Nvoptic.Crawler
{
    class CrawlerWorker
    {
        CrawlerSettings settings;
        CrawlerParser parser;
        HtmlLoader loader;
        List<string> urls;

        public CrawlerWorker(CrawlerParser parser, CrawlerSettings settings)
        {
            this.parser = parser;
            this.settings = settings;
            loader = new HtmlLoader(settings);
        }

        public List<string> Start(string url)
        {
            Worker(url);
            return urls;
        }

        private async void Worker(string url)
        {
            string source = loader.GetSourceByUrl(url);
            var domParser = new HtmlParser();
            var document = await domParser.ParseAsync(source);
            this.urls = parser.Parse(document);
        }
    }
}
