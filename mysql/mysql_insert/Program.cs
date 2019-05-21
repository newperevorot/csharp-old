using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysql_insert
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=vseuznaem.su;user id=root;password=afnfkbnb1987;database=people;characterset=utf8";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string name = "Анатолий";
            int age = 44;

            string query = $"INSERT INTO men (name,age) VALUES('{name}', {age})";

            MySqlCommand command = new MySqlCommand(query, conn);

            //Метод возвращает целое число, количество строк которые модифицированы, вставлены или удалены.
            int result = command.ExecuteNonQuery();

            Console.WriteLine(result.ToString());
            Console.Read();

            conn.Close();
        }
    }
}
