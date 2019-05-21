using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceParser.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
        string StartUrl { get; set; }
        string Prefix { get; set; }
        string Type { get; set; }
        int StartPoint { get; set; }
        int EndPoint { get; set; }
        int CountParse { get; set; }
        string JsonCookies { get; set; }
        string[] Links { get; set; }
    }
}
