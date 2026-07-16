using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class SobreController : Controller
{
   
    public IActionResult Index()
    {
        List<Jugador> sobre = BD.AbrirSobre();
        List<Figuritas> coleccion = BD.ObtenerFiguritas();

        foreach (var jugador in sobre)
        {
            jugador.TieneFigurita = coleccion.Any(f => f.IdJugador == jugador.IdJugador);
        }

        ViewBag.Jugadores = sobre;
        return View();
    }

   
    [HttpPost]
    public IActionResult ConfirmarSobre(List<int> idsJugadores)
    {
        BD.ConfirmarSobre(idsJugadores);
        return RedirectToAction("VerAlbum", "Album");
    }
}