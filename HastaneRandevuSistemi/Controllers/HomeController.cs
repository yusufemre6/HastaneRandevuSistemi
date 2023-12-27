using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Localization;
using HastaneRandevuSistemi.Services;


namespace HastaneRandevuSistemi.Controllers;

class DoktorTemsili
{
    public int doktorId { get; set; }
    public string doktorAdi { get; set; }
    public string doktorSoyadi { get; set; }
    public string cinsiyetAdi { get; set; }
    public DateTime doktorDt { get; set; }
    public string doktorEmail { get; set; }
    public string doktorTel { get; set; }
    public string bransAdi { get; set; }
    public string dereceAdi { get; set; }
}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private  LanguageService _localization;

	

	Uri baseAddress = new Uri("https://localhost:7178/Api");
    HttpClient _client;



	public HomeController(ILogger<HomeController> logger, LanguageService localization = null)
	{
		_logger = logger;
		_localization = localization;
	}

	public IActionResult AnaSayfa()
    {
		ViewBag.Welcome = _localization.Getkey("Welcome").Value;
        var currentCulture =Thread.CurrentThread.CurrentCulture.Name;
        return View();
    }

	public IActionResult ChangeLanguage(string culture)
	{
		Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue
            (new RequestCulture(culture)), new CookieOptions()
		{
			Expires = DateTimeOffset.UtcNow.AddYears(2)

		});

		return Redirect(Request.Headers["Referer"].ToString());

	}

	public IActionResult Kadro()
    {
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;

        List<DoktorTemsili> doktorlar = new List<DoktorTemsili>();
        HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress+"/HomeApi").Result;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            doktorlar = JsonConvert.DeserializeObject<List<DoktorTemsili>>(data);
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

