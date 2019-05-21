using AngleSharp.Parser.Html;
using FreelanceParser.Core.Freelance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceParser.Core
{
    class ParserWorker<T> where T : class
    {
        IParserSettings settings;
        HtmlLoader loader;
        FreelanceParcer parser;
        FreelanceParserDescription parserDescription;
        bool isActive;
        bool isUniqPage = true;

        #region Properties

        public IParserSettings Settings
        {
            get
            {
                return settings;
            }
            set
            {
                settings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion

        public event Action<object, List<FreelanceTask>> onNewData;
        public event Action<object> OnCompleted;

        public event Action<object, FreelanceTask> onNewDataDescription;
        public event Action<object> OnCompletedDescription;

        public ParserWorker(FreelanceParcer parser, IParserSettings settings)
        {
            this.parser = parser;
            Settings = settings;
        }

        public ParserWorker(FreelanceParserDescription parser, IParserSettings settings)
        {
            this.parserDescription = parser;
            Settings = settings;
        }

        public void Start()
        {
            isActive = true;
            if(Settings.Type == "description")
            {
                WorkerDescription();
            }
            if(Settings.Type == "basic")
            {
                Worker();
            }
            
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            string url;
            for (int i = 1; i < 2; i++)
            {
                url = settings.StartUrl + settings.Prefix.Replace("{count}", i.ToString());
                if (!isUniqPage)
                {
                    break;
                }
                GetSource(url);
            }
                
            OnCompleted?.Invoke(this);
            isActive = false;
            isUniqPage = true;
        }

        private async void WorkerDescription()
        {
            string url = Settings.StartUrl;

            if (!isActive)
            {
                OnCompletedDescription?.Invoke(this);
                return;
            }

            string source = loader.GetSourceByUrl(url);
            var domParser = new HtmlParser();

            var document = await domParser.ParseAsync(source);

            var result = parserDescription.Parse(document);

            onNewDataDescription?.Invoke(this, result);
        }

        private async void GetSource(string url)
        {
            if (!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }

            string source = loader.GetSourceByUrl(url);
            var domParser = new HtmlParser();

            var document = await domParser.ParseAsync(source);

            var result = parser.Parse(document);

            if (!Processing.isUniqAllId(result))
            {
                isUniqPage = false;
            }

            onNewData?.Invoke(this, result);
        }

        
    }
}
