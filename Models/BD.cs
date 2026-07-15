using Microsoft.Data.SqlClient;
using Dapper;

namespace TP04.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost;Database=Album;Integrated Security=True;TrustServerCertificate=True;";

    // Devuelve TODOS los jugadores existentes en la base (el "catálogo" completo)
    public static List<Jugador> ObtenerJugadores()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Jugadores";
            return db.Query<Jugador>(sql).ToList();
        }
    }

    // Devuelve las figuritas que el usuario ya tiene (su colección)
    public static List<Figuritas> ObtenerFiguritas()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Figuritas";
            return db.Query<Figuritas>(sql).ToList();
        }
    }

    // Solo las repetidas (Cantidad > 1), por si la usás en alguna otra pantalla
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

    // Elige 5 jugadores al azar de la tabla Jugadores y los devuelve (sin tocar la BD)
    public static List<Jugador> AbrirSobre()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT TOP 5 * FROM Jugadores ORDER BY NEWID()";
            return db.Query<Jugador>(sql).ToList();
        }
    }

    // Recibe los IDs de los jugadores que salieron en el sobre (pueden venir repetidos
    // si tocaron 2 figuritas del mismo jugador en el mismo sobre) y confirma la carga
    // en Figuritas: si ya la tenía, suma la cantidad correspondiente; si no, la inserta.
    public static void ConfirmarSobre(List<int> idsJugadores)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            // Agrupamos por si el mismo jugador salió más de una vez en el sobre
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