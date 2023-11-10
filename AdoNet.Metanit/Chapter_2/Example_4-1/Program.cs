using Npgsql;
using System;

class Program
{
    static void Main()
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
        string connectionString2 = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=OtherDatabase";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine(connection.ProcessID); 
        }

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open(); 
            Console.WriteLine(connection.ProcessID);
        }

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString2))
        {
            connection.Open(); 
            Console.WriteLine(connection.ProcessID);
        }
    }
}