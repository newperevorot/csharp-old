using NvopticParser.Core.Nvoptic.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core.Nvoptic
{
    class NvopticSettings : IParserSettings, ICrawler
    {
        public string BaseUrl { get; set; } = "http://nvoptic.ru";
        public string StartUrl { get; set; } = "http://nvoptic.ru/category/planki-kreplenija/";
        public string Prefix { get; set; }
        public string Type { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public int CountParse { get; set; }
        public string JsonCookies { get; set; }
        private int CurrentPosition { get; set; }

        private Dictionary<string, string> AllMainUrls = new Dictionary<string, string>();
        
        //Словарь сслылок на категории.
        private Dictionary<string, string> FirstMainUrls = new Dictionary<string, string>
            {
                {"http://nvoptic.ru/category/teplovizionnyj-pricely/","teplovizionnyj-pricely"},
                {"http://nvoptic.ru/category/teplovizionnye-binokli/","teplovizionnye-binokli"},
                {"http://nvoptic.ru/category/pricely-nochnogo-videnija/","pricely-nochnogo-videnija"},
                {"http://nvoptic.ru/category/dnevnye-pricely/","dnevnye-pricely"},
                {"http://nvoptic.ru/category/nochnye-nasadki-dlja-dnevnyh-pricelov/","nochnye-nasadki-dlja-dnevnyh-pricelov"},
                {"http://nvoptic.ru/category/pribory-nochnogo-videnija/","pribory-nochnogo-videnija"},
                {"http://nvoptic.ru/category/planki-kreplenija/","planki-kreplenija"},
                {"http://nvoptic.ru/category/dopolnitelnye-prinadlezhnosti/","dopolnitelnye-prinadlezhnosti"}
            };

        public NvopticSettings()
        {
            ParseUrl();
        }

        public string NextUrl()
        {
            List<string> urls = new List<string>();

            foreach(string url in AllMainUrls.Keys)
            {
                urls.Add(url);
            }

            try
            {
                CurrentPosition++;
                return urls[CurrentPosition];
            }
            catch
            {
                CurrentPosition = 0;
                return null;
            }
        }
        
        public void ParseUrl()
        {
            //Функция перебирает словарь ссылок на категории и формирут полный словарь ссылок с категориями.
            //Перебор ссылок из словаря, парсинг по одной и формирование словаря AllMainUrls
            CrawlerWorker parser = new CrawlerWorker(new CrawlerParser(), new CrawlerSettings());

            foreach(KeyValuePair<string, string> keyValue in FirstMainUrls)
            {
                List<string> list = parser.Start(keyValue.Key);
                list.Add(keyValue.Key);
                List<string> new_list = new List<string>(list.Distinct());
                foreach(string str in new_list)
                {
                    AllMainUrls.Add(str, keyValue.Value);
                }
            }

        }
    }
}
