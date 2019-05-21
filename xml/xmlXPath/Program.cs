using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xmlXPath
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("users.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            //Выбор всех дочерних элементов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
            {
                //Console.WriteLine(n.OuterXml);
            }

            //Выберем все узлы user
            XmlNodeList childnodes1 = xRoot.SelectNodes("user");
            //Выведем на консоль значение атрибутов name
            foreach (XmlNode n in childnodes1)
            {
                //Console.WriteLine(n.SelectSingleNode("@name").Value);
            }

            //Выберем узел у которого атрибут name имеет значение "Bill Gates"
            XmlNode childnode = xRoot.SelectSingleNode("user[@name='Bill Gates']");
            if (childnode != null)
            {
                //Console.WriteLine(childnode.OuterXml);
            }

            //Выберем узел у которого вложенный элемент company имеет значение "Microsoft"
            XmlNode childnode1 = xRoot.SelectSingleNode("user[company='Microsoft']");
            if (childnode != null)
            {
                //Console.WriteLine(childnode1.OuterXml);
            }

            //Если нужны только компании перемещаемся вниз по иерархии элементов
            XmlNodeList childnodes2 = xRoot.SelectNodes("//user/company");
            foreach (XmlNode n in childnodes2)
            {
                Console.WriteLine(n.InnerText);
            }
        }
    }
}
