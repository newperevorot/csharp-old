using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;

namespace telegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramBot tb = new TelegramBot();
            tb.TBotNewData += Tb_TBotNewData;
            //tb.MessageReader();
            //tb.MessageSend("Тестирование класса");

        }

        private static void Tb_TBotNewData(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}
