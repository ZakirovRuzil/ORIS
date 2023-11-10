using Npgsql;

string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";

using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    NpgsqlTransaction transaction = connection.BeginTransaction();

    NpgsqlCommand command = connection.CreateCommand();
    command.Transaction = transaction;

    try
    {
        // Выполняем две отдельные команды
        command.CommandText = "INSERT INTO clients (first_name, Age) VALUES('Tim', 34)";
        command.ExecuteNonQuery();
        command.CommandText = "INSERT INTO clients (first_name, Age) VALUES('Kat', 31)";
        command.ExecuteNonQuery();

        // Подтверждаем транзакцию
        transaction.Commit();
        Console.WriteLine("Данные добавлены в базу данных");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        transaction.Rollback();
    }
}