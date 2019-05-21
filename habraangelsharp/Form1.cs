using habra_angelsharp.Core;
using habra_angelsharp.Core.Habra;
using System;
using System.Windows.Forms;

namespace habra_angelsharp
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                    new HabraParser()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done");
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabraSettings((int)numericStart.Value, (int)numericEnd.Value);
            parser.Start();
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
