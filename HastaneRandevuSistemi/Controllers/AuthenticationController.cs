using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace HastaneRandevuSistemi.Controllers
{
    public class AuthenticationController : Controller
    {
        
        public IActionResult GirisYap()
        {
            ViewData["Title"] = "Giriş Yap";
            ViewData["Css"] = "~/css/GirisYap.css";
            return View();
        }

        public IActionResult KayitOl()
        {
            ViewData["Title"] = "Kayıt Ol";
            return View();
        }
    }
}

