using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;

namespace NvopticParser.Core
{
    class HtmlLoader
    {
        private HttpRequest req;
        private IParserSettings settings;
        private string url;
        
        public HtmlLoader(IParserSettings settings)
        {
            this.settings = settings;
            req = new HttpRequest();
            req.UserAgent = Http.ChromeUserAgent();
            CookieDictionary cookie = new CookieDictionary();
            req.Cookies = cookie;
            if(settings.JsonCookies != null)
            {
                JObject j = JObject.Parse(settings.JsonCookies);
                foreach(var item in j)
                {
                    req.Cookies.Add(item.Key, item.Value.ToString());
                }
            }
            this.url = settings.BaseUrl;
        }
        
        public string GetSourceByUrl(string url)
        {
            var response = req.Get(url);
            string source = null;

            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = response.ToString();
            }

            return source;
        }

        public string GetSource()
        {
            return GetSourceByUrl(settings.StartUrl);
        }
    }
}
