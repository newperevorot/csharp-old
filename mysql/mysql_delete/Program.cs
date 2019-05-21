using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysql_delete
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=vseuznaem.su;user id=root;password=afnfkbnb1987;database=people;characterset=utf8";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            int id = int.Parse(Console.ReadLine());
            string query = $"DELETE FROM men WHERE id={id}";

            MySqlCommand command = new MySqlCommand(query, conn);
            string result = command.ExecuteNonQuery().ToString();

            Console.WriteLine($"Количество удаленых строк: {result}");

            conn.Close();
        }
    }
}
