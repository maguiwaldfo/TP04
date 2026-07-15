using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class SobreController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

  public IActionResult AbrirSobre()
    {
        ViewBag.Sobre = BD.AbrirSobre();
        return View();
    }
}
