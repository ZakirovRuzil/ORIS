using Npgsql;

string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
string sqlExpression = "SELECT * FROM Users";

using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    using (NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection)){}
}