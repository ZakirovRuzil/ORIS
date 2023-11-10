using System.Data;
using Npgsql;

class Program
{
    static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
    static void Main(string[] args)
    {
        Console.Write("Введите имя пользователя:");
        string first_name = Console.ReadLine();

        Console.Write("Введите возраст пользователя:");
        int age = Int32.Parse(Console.ReadLine());

        AddUser(first_name, age);
        Console.WriteLine();
        // GetUsers();

        Console.Read();
    }

    // добавление пользователя
    private static void AddUser(string first_name, int age)
    {
        // название процедуры
        string npgsqlExpression = "insert_client";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection))
            {
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода имени
                command.Parameters.AddWithValue("@first_name", first_name);
                // параметр для ввода возраста
                command.Parameters.AddWithValue("@age", age);

                var result = command.ExecuteNonQuery();
                Console.WriteLine("Id добавленного объекта: {0}", result);
            }
        }
    }

    // вывод всех пользователей
    // private static void GetUsers()
    // {
    //     // название процедуры
    //     string npgsqlExpression = "sp_get_users";
    //
    //     using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
    //     {
    //         connection.Open();
    //         using (NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection))
    //         {
    //             // указываем, что команда представляет хранимую процедуру
    //             command.CommandType = CommandType.StoredProcedure;
    //             using (NpgsqlDataReader reader = command.ExecuteReader())
    //             {
    //                 if (reader.HasRows)
    //                 {
    //                     Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(2), reader.GetName(4));
    //
    //                     while (reader.Read())
    //                     {
    //                         int id = reader.GetInt32(0);
    //                         string userName = reader.GetString(2);
    //                         int userAge = reader.GetInt32(4);
    //                         Console.WriteLine("{0} \t{1} \t\t{2}", id, userName, userAge);
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }
}
