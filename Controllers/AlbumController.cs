namespace TP04.Controllers;

public class AlbumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Coleccion()
    {
        List<Figurita> coleccion = BD.ObtenerColeccion();

        return View(coleccion);
    }

    public IActionResult Repetidas()
    {
        List<Figurita> repetidas = BD.ObtenerRepetidas();

        return View(repetidas);
    }
}

