using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class AlbumController : Controller
{
    public IActionResult VerAlbum()
    {
        List<Jugador> jugadores = BD.ObtenerJugadores();
        List<Figuritas> coleccion = BD.ObtenerFiguritas();

        foreach (var jugador in jugadores)
        {
            jugador.TieneFigurita = coleccion.Any(f => f.IdJugador == jugador.IdJugador);
        }

        ViewBag.Jugadores = jugadores;
        ViewBag.Selecciones = BD.ObtenerSelecciones();

        return View();
    }

    public IActionResult Coleccion()
    {
        List<Jugador> jugadores = BD.ObtenerJugadores();
        List<Figuritas> coleccion = BD.ObtenerFiguritas();

        foreach (var jugador in jugadores)
        {
            jugador.TieneFigurita = coleccion.Any(f => f.IdJugador == jugador.IdJugador);
        }

        ViewBag.Jugadores = jugadores;
        ViewBag.Coleccion = coleccion;

        return View();
    }
}