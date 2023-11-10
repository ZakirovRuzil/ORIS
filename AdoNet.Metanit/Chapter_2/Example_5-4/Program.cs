using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
        string npgsqlExpression = "UPDATE clients SET Age=15 WHERE last_name='Pasha'";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection))
            {
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Обновлено объектов: {0}", number);
            }
        }
        Console.Read();
    }
}