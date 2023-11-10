using Npgsql;

class Program
{
    static async Task Main(string[] args)
    {
        await ReadDataAsync();
        Console.Read();
    }

    private static async Task ReadDataAsync()
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";

        string npgsqlExpression = "SELECT * FROM clients";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();

            using (NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection))
            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(2), reader.GetName(4));

                    while (await reader.ReadAsync())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(2);
                        object age = reader.GetValue(4);

                        Console.WriteLine("{0} \t{1} \t\t{2}", id, name, age);
                    }
                }
            }
        }
    }
}