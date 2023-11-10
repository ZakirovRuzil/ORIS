using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";

        string countNpgsqlExpression = "SELECT COUNT(*) FROM clients";
        string minAgeNpgsqlExpression = "SELECT MIN(Age) FROM clients";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand countCommand = new NpgsqlCommand(countNpgsqlExpression, connection))
            using (NpgsqlCommand minAgeCommand = new NpgsqlCommand(minAgeNpgsqlExpression, connection))
            {
                object count = countCommand.ExecuteScalar();
                object minAge = minAgeCommand.ExecuteScalar();

                Console.WriteLine("В таблице {0} объектов", count);
                Console.WriteLine("Минимальный возраст: {0}", minAge);
            }
        }

        Console.Read();
    }
}