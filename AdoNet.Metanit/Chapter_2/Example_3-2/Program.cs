using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        ConnectWithDB().GetAwaiter();
    }
 
    private static async Task ConnectWithDB()
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=F5nKP62cR;Database=Massage salon";
 
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();
            Console.WriteLine("Подключение открыто");
        }
        Console.WriteLine("Подключение закрыто...");
    }
}