using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core.Nvoptic
{
    class NvopticElement
    {
        private string imgUrl;
        private string productName;
        private int price;
        private string description1;
        private string description;
        private string haracter;
        private string category;
        private string brend;
        private string anotation;
        private string keys;

        #region Properties
        public string ImgUrl { get => imgUrl; set => imgUrl = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Haracter { get => haracter; set => haracter = value; }
        public string Category { get => category; set => category = value; }
        public string Brend { get => brend; set => brend = value; }
        public string Anotation { get => anotation; set => anotation = value; }
        public string Description1 { get => description1; set => description1 = value; }
        #endregion
    }
}
