using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class AlbumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Coleccion()
    {
        List<Figuritas> coleccion = BD.ObtenerColeccion();

        return View(coleccion);
    }

    public IActionResult Repetidas()
    {
        ViewBag.Coleccion = BD.ObtenerRepetidas();
        return View("Coleccion");
    }
    
    public IActionResult VerAlbum()
    {
        ViewBag.Jugadores = BD.ObtenerJugadores();
        ViewBag.Selecciones = BD.ObtenerSelecciones();
        return View();
    }
}

