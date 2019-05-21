using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysql
{
    class Program1
    {
        static void Main(string[] args)
        {
            string connectionString = "server=vseuznaem.su;user id=root;password=afnfkbnb1987;database=people";

            //Подключение к БД
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT name, age FROM men";
            string name = "";
            int age;

            MySqlCommand command = new MySqlCommand(sql, conn);

            //Метод возвращает первуют строку и первый параметр после SELECT
            //name = command.ExecuteScalar().ToString();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Возраст {reader[0]} равен {reader[1]}.");
            }
            reader.Close();

            Console.ReadKey();

            conn.Close();
        }
    }
}
