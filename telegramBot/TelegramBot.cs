using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace telegramBot
{
    class TelegramBot
    {
        const string token = "541519356:AAFELREebU49NIbv6RmJlMYDlUA5xhewuI0";
        const string id = "464654673";
        private int idMsgOld = 0;
        private bool isReaderActive = false;
        HttpRequest req;

        string url_update = $"https://api.telegram.org/bot{token}/getUpdates";

        #region Properties
        private bool IsReaderActive
        {
            get
            {
                return isReaderActive;
            }
            set
            {
                isReaderActive = value;
            }
        }
        #endregion

        public event Action<string> TBotNewData;
        
        public TelegramBot()
        {
            req = new HttpRequest();
        }

        public void MessageReader()
        {
            IsReaderActive = true;

            while(true)
            {
                string response = req.Get(url_update).ToString();
                JObject j = JObject.Parse(response);
                //Получаем коллекцию токенов элементов находящихся в result
                IEnumerable<JToken> jTokens = j.SelectTokens("result[*]", false);
                //Определяем количество токенов в result
                int numTokens = jTokens.Count() - 1;
                //Получаем текст и id последнего токена
                string textNew = (string)j.SelectToken("result[" + numTokens + "].message.text");
                int idMsg = (int)j.SelectToken("result[" + numTokens + "].update_id");

                if(textNew == "break" || IsReaderActive == false)
                {
                    break;
                }

                if(idMsg != idMsgOld)
                {
                    TBotNewData?.Invoke(textNew);
                    idMsgOld = idMsg;
                }

                Thread.Sleep(500);
            }

            IsReaderActive = false;
        }

        public void MessageSend(string msg)
        {
            string url_send = $"https://api.telegram.org/bot{token}/sendMessage?chat_id={id}&text={msg}";
            req.Get(url_send);
        }
    }
}
