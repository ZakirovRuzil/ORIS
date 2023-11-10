using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
        string npgsqlExpression = "SELECT * FROM clients";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection))
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(2), reader.GetName(4));

                    while (reader.Read()) // построчно считываем данные
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(2);
                        int age = reader.GetInt32(4);

                        Console.WriteLine("{0} \t{1} \t\t{2}", id, name, age);
                    }
                }
            }
        }

        Console.Read();
    }
}