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
        ParserWorker<FreelanceTask> parserDescription;
        List<FreelanceTask> listFl = new List<FreelanceTask>();
        List<FreelanceTask> listFromDb = new List<FreelanceTask>();

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<List<FreelanceTask>>(new FreelanceParcer(), new FreelanceSettings() { Type = "basic" });

            parser.OnCompleted += Parser_OnCompleted;
            parser.onNewData += Parser_onNewData;
        }

        private void Parser_onNewData(object arg1, List<FreelanceTask> arg2)
        {
            //Получаем только уникальные элементы и добавляем их в глобальный список
            var result = Processing.getUniqElements(arg2);
            foreach (var a in result)
            {
                listFl.Add(a);
                //richTextBox1.AppendText(a.Id.ToString() + "\n");
            }
            //MessageBox.Show(Processing.isUniqAllId(arg2).ToString());
        }

        private void Parser_OnCompleted(object obj)
        {

            //Перебираем список с целью парсинга дополнительной информации
            foreach (FreelanceTask item in listFl)
            {
                parserDescription = new ParserWorker<FreelanceTask>(new FreelanceParserDescription(item), new FreelanceSettings() { Type = "description", StartUrl = item.Link });
                parserDescription.onNewDataDescription += ParserDescription_onNewDataDescription;
                parserDescription.OnCompletedDescription += ParserDescription_OnCompletedDescription;
                parserDescription.Start();
            }
            MessageBox.Show("Парсинг завершен");
        }

        private void ParserDescription_OnCompletedDescription(object obj)
        {
            MessageBox.Show("Парсинг дескрипторов завершен");
        }

        private void ParserDescription_onNewDataDescription(object arg1, FreelanceTask arg2)
        {
            Processing.WriteDB(arg2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listFl.Clear();
            parser.Start();
            //BaseId bi = new BaseId();
            //MessageBox.Show(bi.IsId(1224).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<FreelanceTask> list = Processing.ReadDb(int.Parse(numericUpDown1.Value.ToString()));
            this.listFromDb = list;

            List<string[]> data = new List<string[]>();

            dataGridView1.Rows.Clear();

            foreach (FreelanceTask item in list)
            {
                //richTextBox1.AppendText(item.Title + "\n");
                data.Add(new string[5]);
                data[data.Count - 1][0] = item.Id.ToString();
                data[data.Count - 1][1] = item.Title;
                data[data.Count - 1][2] = item.Price.ToString();
                data[data.Count - 1][3] = item.Deadline;
                data[data.Count - 1][4] = item.Employer;
            }

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numString = e.RowIndex;
            if(numString > -1)
            {
                richTextBox1.Text = listFromDb[numString].Description;
                textBox1.Text = listFromDb[numString].Link;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void clearDataGrid_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
