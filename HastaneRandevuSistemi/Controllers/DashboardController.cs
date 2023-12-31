﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HastaneRandevuSistemi.Controllers
{
    class RandevuTemsili
    {
        public int RandevuID { get; set; }
        public DateTime RandevuTarihSaat { get; set; }
        public string? HastaAdi { get; set; }
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

        [HttpGet]
        public IActionResult HesapBilgileri()
        {
            ViewData["Role"] = "2";

            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var kullanici = dashContext.Kullanicilar.SingleOrDefault(x => x.KullaniciEmail == email);

            ViewBag.KullaniciAdi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;

            ViewBag.Kullanici = kullanici;
            return View();
        }

        [HttpPost]
        public IActionResult HesapBilgileri(Kullanici kullanici)
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var kullaniciCookie = dashContext.Kullanicilar.SingleOrDefault(x => x.KullaniciEmail == email);

            var entityToUpdate = dashContext.Kullanicilar.SingleOrDefault(e => e.KullaniciID == kullaniciCookie.KullaniciID);

            // Veriyi güncelle
            if (entityToUpdate != null)
            {
                entityToUpdate.KullaniciTelNo = kullanici.KullaniciTelNo;
                entityToUpdate.KullaniciEmail = kullanici.KullaniciEmail;
                entityToUpdate.KullaniciSifre = kullanici.KullaniciSifre;
            }

            // Veritabanını güncelle
            dashContext.SaveChanges();

            ViewData["Role"] = "2";
            return RedirectToAction("HesapBilgileri");
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

        [HttpGet]
        public IActionResult HastaneRandevuAl()
        {
            ViewData["Role"] = "2";
            
            List<Brans> branslar = new List<Brans>();
            branslar= dashContext.Branslar.ToList();

            ViewBag.Branslar = new List<SelectListItem>();

            foreach (var item in branslar)
            {
                ViewBag.Branslar.Add(new SelectListItem { Value = item.BransAdi, Text=item.BransAdi });
            }

            string kEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciAdi;
            ViewBag.KullaniciSoyadi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciSoyadi;

            return View();
        }

        [HttpPost]
        public IActionResult HastaneRandevuAl(int id)
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var kullanici = dashContext.Kullanicilar.SingleOrDefault(x => x.KullaniciEmail == email);

            var entityToUpdate = dashContext.Randevular.SingleOrDefault(e => e.RandevuID == id);

            // Veriyi güncelle
            if (entityToUpdate != null)
            {
                entityToUpdate.DurumID=1;
                entityToUpdate.KullaniciID = kullanici.KullaniciID;
            }

            // Veritabanını güncelle
            dashContext.SaveChanges();

            return RedirectToAction("RandevuBilgileri");
        }

        [HttpPost]
        public IActionResult HastaneRandevuListele(Brans bransmodel)
        {
            ViewData["Role"] = "2";

            var Brans = dashContext.Branslar.SingleOrDefault(x=>x.BransAdi== bransmodel.BransAdi);
            int bransId = Brans.BransID;

            List<Randevu> randevular = new List<Randevu>();
            randevular = dashContext.Randevular.ToList();

            var query = from randevu in dashContext.Randevular.Where(x => x.BransID == bransId && (x.DurumID == 3 || x.DurumID == 4))
                        join brans in dashContext.Branslar on randevu.BransID equals brans.BransID
                        join poliklinik in dashContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                        join hastane in dashContext.Hastaneler on randevu.HastaneID equals hastane.HastaneID
                        join doktor in dashContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                        join durum in dashContext.Durumlar on randevu.DurumID equals durum.DurumID
                        join muayenetur in dashContext.MuayeneTurleri on randevu.MuayeneTurID equals muayenetur.MuayeneTurID

                        select new RandevuTemsili
                        {
                            RandevuID = randevu.RandevuID,
                            RandevuTarihSaat = randevu.RandevuTarihSaat.ToLocalTime(),
                            BransAdi = brans.BransAdi,
                            PoliklinikAdi = poliklinik.PoliklinikAdi,
                            HastaneAdi = hastane.HastaneAdi,
                            DoktorAdi = doktor.DoktorAdi,
                            DoktorSoyadi = doktor.DoktorSoyadi,
                            DurumAdi = durum.DurumAdi,
                            MuayeneTurAdi = muayenetur.MuayeneTurAdi
                        };

            List<RandevuTemsili> randevus = query.ToList<RandevuTemsili>();

            ViewBag.Randevular = randevus;

            string kEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciAdi;
            ViewBag.KullaniciSoyadi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciSoyadi;

            return View("HastaneRandevuListele");
        }

        public IActionResult AileHekimiRandevuAl()
        {
            ViewData["Role"] = "2";

            int bransId =11;

            List<Randevu> randevular = new List<Randevu>();
            randevular = dashContext.Randevular.ToList();

            var query = from randevu in dashContext.Randevular.Where(x => x.BransID == bransId && (x.DurumID == 3 || x.DurumID == 4))
                        join brans in dashContext.Branslar on randevu.BransID equals brans.BransID
                        join poliklinik in dashContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                        join hastane in dashContext.Hastaneler on randevu.HastaneID equals hastane.HastaneID
                        join doktor in dashContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                        join durum in dashContext.Durumlar on randevu.DurumID equals durum.DurumID
                        join muayenetur in dashContext.MuayeneTurleri on randevu.MuayeneTurID equals muayenetur.MuayeneTurID

                        select new RandevuTemsili
                        {
                            RandevuID = randevu.RandevuID,
                            RandevuTarihSaat = randevu.RandevuTarihSaat.ToLocalTime(),
                            BransAdi = brans.BransAdi,
                            PoliklinikAdi = poliklinik.PoliklinikAdi,
                            HastaneAdi = hastane.HastaneAdi,
                            DoktorAdi = doktor.DoktorAdi,
                            DoktorSoyadi = doktor.DoktorSoyadi,
                            DurumAdi = durum.DurumAdi,
                            MuayeneTurAdi = muayenetur.MuayeneTurAdi
                        };

            List<RandevuTemsili> randevus = query.ToList<RandevuTemsili>();

            ViewBag.Randevular = randevus;

            string kEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.KullaniciAdi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciAdi;
            ViewBag.KullaniciSoyadi = dashContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kEmail).KullaniciSoyadi;

            return View("HastaneRandevuListele");

        }

        [HttpPost]
        public async Task<IActionResult> HastaneRandevuSil(int id)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            HttpResponseMessage httpResponseMessage = _client.PutAsync(_client.BaseAddress + "/DashboardApi/" + id,null).Result;
            
            return RedirectToAction("RandevuBilgileri");                   
                  
        }
    }
}

