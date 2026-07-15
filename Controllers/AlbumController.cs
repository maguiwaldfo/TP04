using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class AlbumController : Controller
{
    // Página principal del álbum: muestra todos los jugadores,
    // marcando cuáles ya tiene el usuario en su colección.
    public IActionResult Index()
    {
        List<Jugador> jugadores = BD.ObtenerJugadores();
        List<Figuritas> coleccion = BD.ObtenerFiguritas();

        foreach (var jugador in jugadores)
        {
            jugador.TieneFigurita = coleccion.Any(f => f.IdJugador == jugador.IdJugador);
        }

        return View(jugadores);
    }

    // Muestra las 5 figuritas del sobre recién abierto.
    // Si el jugador ya está en la colección, se muestra su foto real;
    // si es nueva, se muestra FiguritaFalta.jpg hasta que se confirme.
    public IActionResult AbrirSobre()
    {
        List<Jugador> sobre = BD.AbrirSobre();
        List<Figuritas> coleccion = BD.ObtenerFiguritas();

        foreach (var jugador in sobre)
        {
            jugador.TieneFigurita = coleccion.Any(f => f.IdJugador == jugador.IdJugador);
        }

        return View(sobre);
    }

    // Recibe los IDs de los jugadores que salieron en el sobre y los guarda
    // definitivamente en la colección del usuario.
    [HttpPost]
    public IActionResult ConfirmarSobre(List<int> idsJugadores)
    {
        BD.ConfirmarSobre(idsJugadores);
        return RedirectToAction("Index");
    }
}