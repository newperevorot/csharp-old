using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xmlToClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("users.xml");

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlElement xnode in xRoot)
            {
                User user = new User();
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                {
                    user.Name = attr.Value;
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                    {
                        user.Company = childnode.InnerText;
                    }

                    if (childnode.Name == "age")
                    {
                        user.Age = int.Parse(childnode.InnerText);
                    }
                }

                users.Add(user);
            }

            foreach (User u in users)
            {
                Console.WriteLine("{0} ({1}) - {2}", u.Name, u.Company, u.Age);
            }
        }
    }
    
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }

}
