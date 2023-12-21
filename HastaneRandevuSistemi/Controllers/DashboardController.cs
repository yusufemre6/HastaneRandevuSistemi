using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace HastaneRandevuSistemi.Controllers
{
    class RandevuTemsili
    {
        public DateTime RandevuTarihSaat { get; set; }
        public string BransAdi { get; set; }
        public string PoliklinikAdi { get; set; }
        public string HastaneAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public string DurumAdi { get; set; }
        public string MuayeneTurAdi { get; set; }
     
    }

    [Authorize(Roles ="2")]
    public class DashboardController : Controller
    {
        ApplicationDbContext dashContext = new ApplicationDbContext();

        Uri baseAddress = new Uri("https://localhost:7178/Api");
        HttpClient _client;

        public IActionResult HesapBilgileri()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RandevuBilgileri()
        {
            ViewData["Role"] = "2";
            string kEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;


            var kullanici = dashContext.Kullanicilar.SingleOrDefault(k => k.KullaniciEmail == kEmail);
            
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            List<RandevuTemsili> randevularlar = new List<RandevuTemsili>();
            HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress + "/DashboardApi?&kullaniciID=" + kullanici.KullaniciID).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                randevularlar = JsonConvert.DeserializeObject<List<RandevuTemsili>>(data);
            }

            ViewBag.KullaniciAdi= dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciAdi;
            ViewBag.KullaniciSoyadi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciSoyadi;
            ViewBag.Randevular = randevularlar;
            return View();
        }

        public IActionResult HastaneRandevuAl()
        {
            ViewData["Role"] = "2";
            return View();
        }
        public IActionResult AileHekimiRandevuAl()
        {
            ViewData["Role"] = "2";
            return View();
        }
    }
}

