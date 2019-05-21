using FreelanceParser.Core;
using FreelanceParser.Core.Freelance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelanceParser
{
    public partial class Form1 : Form
    {
        ParserWorker<List<FreelanceTask>> parser;
        List<FreelanceTask> listFl = new List<FreelanceTask>();

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<List<FreelanceTask>>(new FreelanceParcer(), new FreelanceSettings());

            parser.onNewData += Parser_onNewData;
            parser.OnCompleted += Parser_OnCompleted;
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Парсинг завершен");
        }

        private void Parser_onNewData(object arg1, List<FreelanceTask> arg2)
        {
            foreach (FreelanceTask fl in arg2)
            {
                richTextBox1.AppendText(fl.Title + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Start();
        }
    }

}