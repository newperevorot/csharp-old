using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("users.xml");

            //Получение корневого элемента
            XmlElement xRoot = xDoc.DocumentElement;

            //Обход всех узлов в корневом элементе
            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Attributes.Count > 0)
                {
                    XmlNode attr = xNode.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        Console.WriteLine(attr.Value);
                    }
                }

                //Обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xNode.ChildNodes)
                {
                    //Если узел company
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine("Компания: {0}", childnode.InnerText);
                    }

                    //Если узел age
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine("Возраст: {0}", childnode.InnerText);
                    }
                }

                Console.WriteLine();

            }

            Console.Read();

        }
    }
}
