using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core
{
    interface ICrawler
    {
        string NextUrl();
        void ParseUrl();
    }
}
