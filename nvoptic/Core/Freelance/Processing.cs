using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NvopticParser.Core.Freelance
{
    class Processing
    {
        public static List<FreelanceTask> getUniqElements(List<FreelanceTask> old_list)
        {
            List<FreelanceTask> list = new List<FreelanceTask>();
            BaseId bi = new BaseId();

            foreach (var item in old_list)
            {
                if (bi.IsId(item.Id))
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public static bool isUniqAllId(List<FreelanceTask> list)
        {
            BaseId bi = new BaseId();

            foreach(var item in list)
            {
                if (!bi.IsId(item.Id, false))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool WriteDB(FreelanceTask fl)
        {
            string connectionString = "server=vseuznaem.su;user id=root;password=afnfkbnb1987;database=freelance;characterset=utf8";
            MySqlConnection conn;
            MySqlCommand command;

            try
            {
                conn = new MySqlConnection(connectionString);
            }
            catch(Exception e)
            {
                return false;
            }

            conn.Open();

            string query = $"INSERT INTO task (id, title, price, link, description, deadline, prepaiment, payment, publishdate, employer)" +
                           $"VALUES({fl.Id}, '{fl.Title}', '{fl.Price}', '{fl.Link}', '{fl.Description}', '{fl.Deadline}', '{fl.Prepayment}', '{fl.Payment}', '{fl.PublishDate}', '{fl.Employer}')";

            try
            {
                command = new MySqlCommand(query, conn);
            }
            catch
            {
                return false;
            }

            int result = command.ExecuteNonQuery();

            conn.Close();

            if(result > 0)
            {
                return true;
            }

            return false;
        }

        public static List<FreelanceTask> ReadDb(int count)
        {
            string connectionString = "server=vseuznaem.su;user id=root;password=afnfkbnb1987;database=freelance;characterset=utf8";
            MySqlConnection conn;
            MySqlCommand command;
            List<FreelanceTask> list = new List<FreelanceTask>();

            try
            {
                conn = new MySqlConnection(connectionString);
            }
            catch (Exception e)
            {
                return null;
            }

            conn.Open();

            string query = $"SELECT id, title, price, link, description, deadline, prepaiment, payment, publishdate, employer FROM task LIMIT {count}";

            try
            {
                command = new MySqlCommand(query, conn);
            }
            catch
            {
                return null;
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader[0].ToString());
                string title = reader[1].ToString();
                string price = reader[2].ToString();
                string link = reader[3].ToString();

                FreelanceTask fl = new FreelanceTask(id, title, price, link);

                fl.Description = (string)reader[4];
                fl.Deadline = (string)reader[5];
                fl.Prepayment = (string)reader[6];
                fl.Payment = (string)reader[7];
                fl.PublishDate = (string)reader[8];
                fl.Employer = (string)reader[9];

                list.Add(fl);
            }

            conn.Close();

            return list;
        }
    }
}
