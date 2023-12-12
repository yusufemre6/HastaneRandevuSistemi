using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using Newtonsoft.Json;


namespace HastaneRandevuSistemi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    Uri baseAddress = new Uri("https://localhost:7178/Api");
    HttpClient _client;

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
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;

        List<Doktor> doktorlar = new List<Doktor>();
        HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress+"/HomeApi").Result;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
            doktorlar = JsonConvert.DeserializeObject<List<Doktor>>(data);
        }

        foreach (var item in doktorlar)
        {
            Console.WriteLine(item.DoktorAdi);
        }


        ViewBag.Doktorlar = doktorlar;
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

