using Microsoft.Data.Sqlite;

public static class Database
{
    private static string connectionString = "Data Source=paises.db";

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(connectionString);
    }

    public static void CriarBancoETabela()
    {
        using var conn = GetConnection();
        conn.Open();

        string sql = @"
    CREATE TABLE IF NOT EXISTS paises (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nome TEXT NOT NULL,
        populacao INTEGER NOT NULL,
        area INTEGER NOT NULL
    );
";


        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}
