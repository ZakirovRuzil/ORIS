using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
        string sqlExpression = "DELETE FROM clients WHERE status='Wood'";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection))
            {
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Удалено объектов: {0}", number);
            }
        }
        Console.Read();
    }
}