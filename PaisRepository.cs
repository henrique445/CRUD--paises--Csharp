using Microsoft.Data.Sqlite;
using System.Collections.Generic;

public static class PaisRepository
{
    public static void Inserir(Pais pais)
    {
        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText =
            "INSERT INTO paises (nome, populacao, area) VALUES ($nome, $populacao, $area)";
        cmd.Parameters.AddWithValue("$nome", pais.Nome);
        cmd.Parameters.AddWithValue("$populacao", pais.Populacao);
        cmd.Parameters.AddWithValue("$area", pais.AreaTotal);

        cmd.ExecuteNonQuery();
    }
public static List<Pais> Listar()
{
    var lista = new List<Pais>();

    using var conn = Database.GetConnection();
    conn.Open();

    string sql = "SELECT id, nome, populacao, area FROM paises";

    using var cmd = new SqliteCommand(sql, conn);
    using var reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        lista.Add(new Pais
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Populacao = reader.GetDouble(2),
            AreaTotal = reader.GetDouble(3)
        });
    }

    return lista;
}

    public static void Deletar(int id)
    {
        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM paises WHERE id = $id";
        cmd.Parameters.AddWithValue("$id", id);

        cmd.ExecuteNonQuery();
    }
    public static void Atualizar(Pais pais)
{
    using var conn = Database.GetConnection();
    conn.Open();

    string sql = @"
        UPDATE paises 
        SET nome = @nome, populacao = @populacao, area = @area
        WHERE id = @id";

    using var cmd = new SqliteCommand(sql, conn);

    cmd.Parameters.AddWithValue("@nome", pais.Nome);
    cmd.Parameters.AddWithValue("@populacao", pais.Populacao);
    cmd.Parameters.AddWithValue("@area", pais.AreaTotal);
    cmd.Parameters.AddWithValue("@id", pais.Id);

    cmd.ExecuteNonQuery();
}

}
