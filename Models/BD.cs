using Microsoft.Data.SqlClient;
using Dapper;

namespace TP04.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost;Database=Album;Integrated Security=True;TrustServerCertificate=True;";


    public static List<Jugador> ObtenerJugadores()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Jugadores";
            return db.Query<Jugador>(sql).ToList();
        }
    }


    public static List<Figuritas> ObtenerFiguritas()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Figuritas";
            return db.Query<Figuritas>(sql).ToList();
        }
    }


    public static List<Figuritas> ObtenerRepetidas()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = @"SELECT *
                           FROM Figuritas
                           WHERE Cantidad > 1";

            return db.Query<Figuritas>(sql).ToList();
        }
    }

    public static List<Seleccion> ObtenerSelecciones()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Selecciones";
            return db.Query<Seleccion>(sql).ToList();
        }
    }


    public static List<Jugador> AbrirSobre()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT TOP 5 * FROM Jugadores ORDER BY NEWID()";
            return db.Query<Jugador>(sql).ToList();
        }
    }

  
    public static void ConfirmarSobre(List<int> idsJugadores)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
 
            var agrupados = idsJugadores
                .GroupBy(id => id)
                .Select(g => new { IdJugador = g.Key, Repeticiones = g.Count() });

            foreach (var item in agrupados)
            {
                Figuritas f = BuscarFigurita(item.IdJugador);

                if (f != null)
                {
                    string sqlUpdate = @"UPDATE Figuritas
                                          SET Cantidad = Cantidad + @Repeticiones
                                          WHERE IdJugador = @IdJugador";

                    db.Execute(sqlUpdate, new { IdJugador = item.IdJugador, item.Repeticiones });
                }
                else
                {
                    string sqlInsert = @"INSERT INTO Figuritas
                                          (IdJugador, Cantidad, Pegada)
                                          VALUES
                                          (@IdJugador, @Repeticiones, 0)";

                    db.Execute(sqlInsert, new { IdJugador = item.IdJugador, item.Repeticiones });
                }
            }
        }
    }

    public static Figuritas BuscarFigurita(int idJugador)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = @"SELECT *
                           FROM Figuritas
                           WHERE IdJugador = @IdJugador";

            return db.QueryFirstOrDefault<Figuritas>(sql, new { IdJugador = idJugador });
        }
    }
}