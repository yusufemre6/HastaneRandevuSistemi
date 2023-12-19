using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace HastaneRandevuSistemi.Controllers
{
    public class AuthenticationController : Controller
    {
        ApplicationDbContext authContext = new ApplicationDbContext();

        [HttpGet]
        public IActionResult GirisYap()
        {
            ViewBag.HataMsg="";
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(Kullanici kullanici){


            if (ModelState.IsValid)
            {
                bool userCheck = authContext.Kullanicilar.Any(u => u.KullaniciEmail == kullanici.KullaniciEmail && u.KullaniciSifre == kullanici.KullaniciSifre);

                if (userCheck)
                {
                    HttpContext.Session.SetString("userEmail", kullanici.KullaniciEmail);
                    return RedirectToAction("Dashboard", kullanici);
                }
                else
                {
                    ViewBag.HataMsg = "Giriş Yapılamadı !!!";
                    return View("GirisYap");
                }
                   
            }
            else {
                ViewBag.HataMsg = "Giriş Yapılamadı !!!";
                return View("GirisYap");
            }
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(Kullanici kullanici) {
            
            if (ModelState.IsValid) {
                return View("BasariliKayit", kullanici);
            }
            else
            {
                return View("KayitOl");
            }
        }

        public IActionResult CikisYap()
        {
            HttpContext.Session.Remove("email");
            return View();
        }
    }
}

