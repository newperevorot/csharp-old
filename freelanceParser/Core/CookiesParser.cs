using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FreelanceParser.Core
{
    class CookiesParser
    {
        private string url;
        private string jsonCookies;

        #region Properties
        public string JsonCookies
        {
            get
            {
                return jsonCookies;
            }
        }
        #endregion

        public CookiesParser(IParserSettings settings)
        {
            url = settings.BaseUrl.Replace("https://", "").Replace("http://", "");
            jsonCookies = GetJsonCookies();
        }

        private string GetJsonCookies()
        {
            JObject j = new JObject();
            StreamReader sr;

            try
            {
                sr = new StreamReader("cookies.txt");
            }
            catch(Exception e)
            {
                return "{}";
            }
            
            string line;

            while((line = sr.ReadLine()) != null)
            {
                if (line.Contains(url))
                {
                    string[] elements = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    j[elements[6]] = elements[7];
                }
            }
            sr.Close();
            return j.ToString();
        }
    }
}
