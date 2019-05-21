using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace vk_api_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void VkAuth(string login, string pass)
        {
            using (var req = new HttpRequest())
            {
                req.UserAgent = Http.ChromeUserAgent();

                CookieDictionary cookie = new CookieDictionary(false);
                req.Cookies = cookie;

                req.Get(String.Format($"https://login.vk.com/?act=login&email={login}&pass={pass}"));
                /****************************** Для API ***********************************************/

                string data = req.Get(String.Format($"https://oauth.vk.com/authorize?client_id=6290819&scope=notify%2Cfriends%2Cphotos%2Caudio%2Cvideo%2Cstatus%2Cwall%2Cgroups%2Cmessages%2Cstats&redirect_uri=http://oauth.vk.com/blank.html&display=touch&response_type=token")).ToString();

                req.AllowAutoRedirect = false;

                req.Get(data.Substring("<form method=\"post\" action=\"", "\">"));

                char[] simbol = { '=', '&' };
                string[] reString = req.Response.Location.Split(simbol);

                MessageBox.Show($"Token {reString[1]}. ID {reString[5]}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VkAuth(textBox1.Text, textBox2.Text);
        }
    }
}
