using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core.Freelance
{
    class FreelanceSettings:IParserSettings
    {
        public FreelanceSettings():this(0, true)
        {
            //Если в конструктор ничего не передается парсинг
            //тогда парсить без ограничения с куками
        }

        public FreelanceSettings(int count, bool useCookie)
        {
            CountParse = count;
            if (useCookie)
            {
                CookiesParser cs = new CookiesParser(this);
                JsonCookies = cs.JsonCookies;
            }
        }

        public string BaseUrl { get; set; } = "https://freelance.ru";
        public string StartUrl { get; set; } = "https://freelance.ru/projects/filter/?specs=4:133:186:69:554";
        public string Type { get; set; }
        public string Prefix { get; set; } = "&page={count}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public int CountParse { get; set; }
        public string JsonCookies { get; set; }
    }
}
