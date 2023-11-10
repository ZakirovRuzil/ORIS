using System;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace AdoNetConsoleApp
{
    class Program
    {
        static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
        static void Main(string[] args) 
        {
            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();

            GetAgeRange(name);

            Console.Read();
        }

        private static void GetAgeRange(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sp_get_age_range", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new NpgsqlParameter("search_name", NpgsqlDbType.Varchar) { Value = name });
                    command.Parameters.Add(new NpgsqlParameter("min_age", NpgsqlDbType.Integer) { Direction = ParameterDirection.Output });
                    command.Parameters.Add(new NpgsqlParameter("max_age", NpgsqlDbType.Integer) { Direction = ParameterDirection.Output });

                    command.ExecuteNonQuery();

                    int minAge = Convert.ToInt32(command.Parameters["min_age"].Value);
                    int maxAge = Convert.ToInt32(command.Parameters["max_age"].Value);

                    Console.WriteLine("Минимальный возраст: {0}", minAge);
                    Console.WriteLine("Максимальный возраст: {0}", maxAge);
                }
            }
        }
    }
}