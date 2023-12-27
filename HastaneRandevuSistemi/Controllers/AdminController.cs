using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Json;
using System.Text;

namespace HastaneRandevuSistemi.Controllers
{
   
    [Authorize(Roles = "1")]
    public class AdminController : Controller
	{
        ApplicationDbContext adminContext = new ApplicationDbContext();
        Uri baseAddress = new Uri("https://localhost:7178/Api");
        HttpClient _client;

        public class HastaneTemsili
        {
            public int HastaneId { get; set; }
            public string HastaneAdi{ get; set; }
            public string HastaneTurAdi { get; set; }
            public string HastaneAdresi { get; set; }
        }

        public class PoliklinikTemsili
        {
            public int PoliklinikId { get; set; }
            public string PoliklinikAdi { get; set; }
            public string BransAdi { get; set; }
            public string HastaneAdi { get; set; }
            public string DoktorAdi { get; set; }
        }

        public IActionResult AdminBaslangic()
		{
            ViewData["Role"] = "1";
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            return View();
		}

        public IActionResult DoktorListele()
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            List<DoktorTemsili> doktorlar = new List<DoktorTemsili>();
            HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress + "/AdminApi").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;

                doktorlar = JsonConvert.DeserializeObject<List<DoktorTemsili>>(data);
            }

            ViewBag.Doktorlar = doktorlar;

            ViewData["Role"] = "1";
            return View();
        }

        public IActionResult HastaneListele()
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            var query = from hastane in adminContext.Hastaneler
                        join hastanetur in adminContext.HastaneTurleri on hastane.HastaneTurID equals hastanetur.HastaneTurID
                        select new HastaneTemsili
                        {
                            HastaneId = hastane.HastaneID,
                            HastaneAdi= hastane.HastaneAdi,
                            HastaneTurAdi = hastanetur.HastaneTurAdi,
                            HastaneAdresi = hastane.HastaneAdresi
                        };
            ViewBag.Hastaneler = query.ToList();

            ViewData["Role"] = "1";
            return View();
        }

        public IActionResult PoliklinikListele()
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            var query = from poliklinik in adminContext.Poliklinikler
                        join doktor in adminContext.Doktorlar on poliklinik.DoktorID equals doktor.DoktorID
                        join brans in adminContext.Branslar on poliklinik.BransID equals brans.BransID
                        join hastane in adminContext.Hastaneler on poliklinik.HastaneID equals hastane.HastaneID
                        select new PoliklinikTemsili
                        {
                            PoliklinikId = poliklinik.PoliklinikID,
                            PoliklinikAdi = poliklinik.PoliklinikAdi,
                            HastaneAdi= hastane.HastaneAdi,
                            BransAdi = brans.BransAdi,
                            DoktorAdi = doktor.DoktorAdi
                        };

            ViewBag.Poliklinikler = query.ToList();

            ViewData["Role"] = "1";
            return View();
        }

        [HttpGet]
        public IActionResult DoktorEkle()
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            if (TempData.ContainsKey("HataMsg"))
            {
                ViewBag.HataMsg = TempData["HataMsg"];
            }

            List<Hastane> hastaneler = new List<Hastane>();
            hastaneler = adminContext.Hastaneler.ToList();

            ViewBag.Hastaneler = new List<SelectListItem>();

            foreach (var item in hastaneler)
            {
                ViewBag.Hastaneler.Add(new SelectListItem { Value = item.HastaneID.ToString(), Text = item.HastaneAdi });
            }

            List<Derece> dereceler = new List<Derece>();
            dereceler = adminContext.Dereceler.ToList();

            ViewBag.Dereceler = new List<SelectListItem>();

            foreach (var item in dereceler)
            {
                ViewBag.Dereceler.Add(new SelectListItem { Value = item.DereceID.ToString(), Text = item.DereceAdi });
            }

            List<Brans> branslar = new List<Brans>();
            branslar = adminContext.Branslar.ToList();

            ViewBag.Branslar = new List<SelectListItem>();

            foreach (var item in branslar)
            {
                ViewBag.Branslar.Add(new SelectListItem { Value = item.BransID.ToString(), Text = item.BransAdi });
            }

            ViewData["Role"] = "1";
            return View();
        }

        [HttpPost]
        public IActionResult DoktorEkle(DoktorModel doktor)
        {
            bool check = adminContext.Doktorlar.Any(d =>(d.DoktorAdi==doktor.DoktorAdi&&d.DoktorSoyadi==doktor.DoktorSoyadi)||d.DoktorEmail==doktor.DoktorEmail||d.DoktorTelNo==doktor.DoktorTelNo);

            if (check)
            {
                TempData["HataMsg"] = "Girdiğiniz Doktor Sistemde Bulunmaktadır !!!";
                return RedirectToAction("HastaneEkle", ViewBag.HataMsg);
            }

            Doktor newDoktor = new Doktor()
            {
                DoktorAdi = doktor.DoktorAdi,
                DoktorSoyadi = doktor.DoktorSoyadi,
                DoktorEmail = doktor.DoktorEmail,
                DoktorTelNo = doktor.DoktorTelNo,
                DoktorDt = doktor.DoktorDt.ToUniversalTime(),
                CinsiyetID = doktor.CinsiyetID,
                DereceID = doktor.DereceID,
                BransID = doktor.BransID
            };

            adminContext.Doktorlar.Add(newDoktor);
            adminContext.SaveChanges();

            Poliklinik newPoliklinik = new Poliklinik()
            {
                PoliklinikAdi = "Poliklinik " + (adminContext.Poliklinikler.OrderByDescending(p => p.PoliklinikID).Select(p => p.PoliklinikID).FirstOrDefault()+1).ToString(),
                BransID = doktor.BransID,
                DoktorID = adminContext.Doktorlar.SingleOrDefault(d => d.DoktorEmail == doktor.DoktorEmail).DoktorID,
                HastaneID = doktor.HastaneID
            };

            adminContext.Poliklinikler.Add(newPoliklinik);
            adminContext.SaveChanges();

            return RedirectToAction("DoktorListele");
        }

        [HttpPost]
        public IActionResult DoktorSil(int id)
        {
            ViewData["Role"] = "1";
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            HttpResponseMessage httpResponseMessage = _client.DeleteAsync(_client.BaseAddress + "/AdminApi/" + id).Result;
            return RedirectToAction("DoktorListele");
        }

        [HttpGet]
        public IActionResult HastaneEkle()
        {
            if (TempData.ContainsKey("HataMsg"))
            {
                ViewBag.HataMsg = TempData["HataMsg"];
            }

            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = adminContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            List<HastaneTur> hastaneTurleri = new List<HastaneTur>();
            hastaneTurleri = adminContext.HastaneTurleri.ToList();

            ViewBag.HastaneTurleri = new List<SelectListItem>();

            foreach (var item in hastaneTurleri)
            {
                ViewBag.HastaneTurleri.Add(new SelectListItem { Value = item.HastaneTurID.ToString(), Text = item.HastaneTurAdi });
            }

            ViewData["Role"] = "1";
            return View();
        }

        [HttpPost]
        public IActionResult HastaneEkle(Hastane hastane)
        {
            bool check = adminContext.Hastaneler.Any(h => h.HastaneAdi == hastane.HastaneAdi);

            if (check)
            {
                TempData["HataMsg"] = "Girdiğin Hastane Sistemde Eklidir !!!";
                
                return RedirectToAction("HastaneEkle", ViewBag.HataMsg);
            }

            adminContext.Hastaneler.Add(hastane);
            adminContext.SaveChanges();



            return RedirectToAction("HastaneListele");
        }

        [HttpPost]
        public IActionResult HastaneSil(int id)
        {
            ViewData["Role"] = "1";
            // LINQ sorgusu ile veriyi getir
            var entityToDelete = adminContext.Hastaneler.SingleOrDefault(e => e.HastaneID == id);
           
            // Veriyi güncelle
            if (entityToDelete != null)
            {
                adminContext.Hastaneler.Remove(entityToDelete);
            }
            adminContext.SaveChanges();
            return RedirectToAction("HastaneListele");
        }
    }
}
