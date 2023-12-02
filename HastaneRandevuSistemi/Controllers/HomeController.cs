using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;

namespace HastaneRandevuSistemi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult AnaSayfa()
    {
        ViewData["Title"] = "Ana Sayfa";
        return View();
    }

    public IActionResult Kadro()
    {
        ViewData["Title"] = "Doktor Kadrosu";
        return View();
    }

    public IActionResult Hakkimizda()
    {
        ViewData["Title"] = "Hakkımızda";
        return View();
    }

    public IActionResult Iletisim()
    {
        ViewData["Title"] = "İletişim";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

