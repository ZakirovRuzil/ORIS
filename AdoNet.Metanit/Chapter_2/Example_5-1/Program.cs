using Npgsql;

string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    NpgsqlCommand command = new NpgsqlCommand();
    command.CommandText = "SELECT * FROM clients";
    command.Connection = connection;
}