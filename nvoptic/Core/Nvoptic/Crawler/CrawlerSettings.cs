using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core.Nvoptic.Crawler
{
    class CrawlerSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "http://nvoptic.ru";
        public string StartUrl { get; set; }
        public string Prefix { get; set; }
        public string Type { get; set; } = "crowler";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public int CountParse { get; set; }
        public string JsonCookies { get; set; }
    }
}
