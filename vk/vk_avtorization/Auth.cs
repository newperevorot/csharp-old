using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace vk_avtorization
{
    class Auth
    {
        public const int AppID = 6290819;
        public const string Scope = "wall";

        public string VkAuth(string Login, string Pass)
        {
            using(var req = new HttpRequest())
            {
                req.UserAgent = HttpHelper.
            }
        }
    }
}
