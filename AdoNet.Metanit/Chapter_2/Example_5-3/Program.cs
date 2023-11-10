using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
        string sqlExpression = "INSERT INTO clients (id, last_name, first_name, surname, age, contact, status, is_blocked, is_anonimus) VALUES (2, 'Suchkov', 'Anton', 'Batievich', 21, 'Antonchik@mail.ru', 'Wood', false, false)";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection))
            {
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
            }
        }
        Console.Read();
    }
}