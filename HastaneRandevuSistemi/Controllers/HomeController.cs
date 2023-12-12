using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;

namespace HastaneRandevuSistemi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //Uri baseAddress = new Uri("https://localhost:7178/Api");
    //private readonly HttpClient _client;

    //public HomeController() {
    //    _client = new HttpClient();
    //    _client.BaseAddress = baseAddress;
    //}

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult AnaSayfa()
    {
        return View();
    }

    public IActionResult Kadro()
    {
        
        return View();
    }

    public IActionResult Hakkimizda()
    {
        
        return View();
    }

    public IActionResult Iletisim()
    {
        
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

