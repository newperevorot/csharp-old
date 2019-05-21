using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "freelance.ru";
            JObject j = new JObject();

            StreamReader sr = new StreamReader("cookie.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(url))
                {

                    string[] elements = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    j[elements[6]] = elements[7];
                }
            }

            Console.WriteLine(j.ToString());
            sr.Close();
        }
    }
}