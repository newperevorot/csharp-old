using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysql_update
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=vseuznaem.su;user id=root;password=afnfkbnb1987;database=people;characterset=utf8";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string name = "Генадий";
            int age = 44;
            string query = $"UPDATE men SET name='{name}' where age={age}";

            MySqlCommand command = new MySqlCommand(query, conn);

            int result = command.ExecuteNonQuery();
            Console.WriteLine($"Изменена {result.ToString()} строка");

            conn.Close();
        }
    }
}
