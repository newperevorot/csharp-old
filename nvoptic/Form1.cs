using NvopticParser.Core;
using NvopticParser.Core.Freelance;
using NvopticParser.Core.Nvoptic;
using NvopticParser.Core.Nvoptic.Crawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NvopticParser
{
    public partial class Form1 : Form
    {
        ParserWorker<List<NvopticElement>> parser;
        List<NvopticElement> listNv = new List<NvopticElement>();
        //NvopticSettings ns = new NvopticSettings();

        public Form1()
        {
            InitializeComponent();
            //parser = new ParserWorker<List<FreelanceTask>>(new FreelanceParcer(), new FreelanceSettings());
            parser = new ParserWorker<List<NvopticElement>>(new NvParser(), new NvopticSettings());

            parser.onNewData += Parser_onNewData;
            parser.OnCompleted += Parser_OnCompleted;
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Парсинг завершен");
        }

        private void Parser_onNewData(object arg1, List<NvopticElement> arg2)
        {
            foreach (NvopticElement nv in arg2)
            {
                richTextBox1.AppendText(nv.Description1 + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CrawlerWorker crowlerParser = new CrawlerWorker(new CrawlerParser(), new CrawlerSettings() { StartUrl = "http://nvoptic.ru/category/dopolnitelnye-prinadlezhnosti/" });
            //List<string> list = crowlerParser.Start();
            //foreach(var element in list)
            //{
            //    richTextBox1.AppendText(element + "\n");
            //}

            //richTextBox1.AppendText(ns.NextUrl() + "\n");

        }

    }

}