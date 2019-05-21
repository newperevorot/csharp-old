using AngleSharp.Parser.Html;
using NvopticParser.Core.Nvoptic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core
{
    class ParserWorker<T> where T : class
    {
        IParserSettings settings;
        HtmlLoader loader;
        NvParser parser;
        bool isActive;

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

        public event Action<object, List<NvopticElement>> onNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(NvParser parser, IParserSettings settings)
        {
            this.parser = parser;
            Settings = settings;
        }

        public void Start()
        {
            isActive = true;
            Worker();

        }

        public void Abort()
        {
            isActive = false;
        }

        private void Worker()
        {
            string url = settings.StartUrl;
            GetSource(url);

            OnCompleted?.Invoke(this);
            isActive = false;
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

            onNewData?.Invoke(this, result);
        }


    }
}
