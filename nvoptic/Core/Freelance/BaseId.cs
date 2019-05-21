using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NvopticParser.Core.Freelance
{
    class BaseId
    {
        //Класс применяется в управлении парсингом
        //Классу даются идентификаторы заданий. Если идентификатор уже присутствует в базе то он возвращает false
        //Если идентификатора в базе нет то true;
        private List<int> listId = new List<int>();

        public BaseId()
        {
            StreamReader sr;

            try
            {
                sr = new StreamReader("listId.txt");
            }
            catch
            {
                return;
            }

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    listId.Add(int.Parse(line));
                }
                catch
                {
                    listId.Add(1);
                }
            }

            sr.Close();
        }

        public bool IsId(int id, bool write=true)
        {
            if (listId.Find(x => x == id) > 0)
            {
                return false;
            }
            else
            {
                if(write == true)
                {
                    writeId(id);
                }
                listId.Add(id);
                return true;
            }
        }

        public void writeId(int id)
        {
            StreamWriter sw;

            try
            {
                sw = new StreamWriter("listId.txt", true);
            }
            catch
            {
                return;
            }

            sw.WriteLine(id);
            sw.Close();
        }

    }
}
