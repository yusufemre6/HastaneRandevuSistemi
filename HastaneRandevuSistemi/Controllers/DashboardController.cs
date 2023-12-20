using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace HastaneRandevuSistemi.Controllers
{
    class RandevuTemsili
    {
        public int RandevuGun { get; set; }
        public int RandevuAy { get; set; }
        public int RandevuYil { get; set; }
        public int Saat { get; set; }
        public int Dakika { get; set; }
        public string BransAdi { get; set; }
        public string PoliklinikAdi { get; set; }
        public string HastaneAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public string DurumAdi { get; set; }
        public string MuayeneTurAdi { get; set; }
    }

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
            Console.WriteLine("Buradayız");

            string kEmail = HttpContext.Session.GetString("userEmail");
            Console.WriteLine(kEmail);
            var kullanici = dashContext.Kullanicilar.SingleOrDefault(k => k.KullaniciEmail == kEmail);
            
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            List<RandevuTemsili> randevularlar = new List<RandevuTemsili>();
            HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress + "/DashboardApi?&kullaniciID=" + 1).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                randevularlar = JsonConvert.DeserializeObject<List<RandevuTemsili>>(data);
            }

            ViewBag.Randevular = randevularlar;
            return View();
        }

        public IActionResult HastaneRandevuAl()
        {
            return View();
        }
        public IActionResult AileHekimiRandevuAl()
        {
            return View();
        }
    }
}

