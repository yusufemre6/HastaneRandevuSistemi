using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using System.Reflection;


namespace HastaneRandevuSistemi.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(Kullanici kullanici){
            if (ModelState.IsValid)
            {
                return RedirectToAction("Dashboard", kullanici);
            }
            else {
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
    }
}

