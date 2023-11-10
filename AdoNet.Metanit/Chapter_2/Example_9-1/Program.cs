using Npgsql;

string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
int age = 23;
string name = "T',10);INSERT INTO clients (first_name, age) VALUES('H";
string npgsqlExpression = "INSERT INTO clients (first_name, age) VALUES (@name, @age)";

using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    using (NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection))
    {
        // создаем параметр для имени
        NpgsqlParameter nameParam = new NpgsqlParameter("@name", NpgsqlTypes.NpgsqlDbType.Text);
        nameParam.Value = name;
        // добавляем параметр к команде
        command.Parameters.Add(nameParam);

        // создаем параметр для возраста
        NpgsqlParameter ageParam = new NpgsqlParameter("@age", NpgsqlTypes.NpgsqlDbType.Integer);
        ageParam.Value = age;
        // добавляем параметр к команде
        command.Parameters.Add(ageParam);

        int number = command.ExecuteNonQuery();
        Console.WriteLine("Добавлено объектов: {0}", number); // 1
    }
}