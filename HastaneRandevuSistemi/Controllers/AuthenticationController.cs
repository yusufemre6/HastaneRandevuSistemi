using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<IActionResult> GirisYap(Kullanici kullanici){

            var userCheck = authContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kullanici.KullaniciEmail && u.KullaniciSifre == kullanici.KullaniciSifre);

            if (userCheck!=null)
            {
                int rolId= authContext.Roller.SingleOrDefault(u => u.KullaniciID == userCheck.KullaniciID).KisiTipiID;
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email,kullanici.KullaniciEmail),
                    new Claim(ClaimTypes.Role,"2")
                };

                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                
                return RedirectToAction("RandevuBilgileri", "Dashboard");
            }
            else
            {
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

            bool emailVarMi= authContext.Kullanicilar.Any(u => u.KullaniciEmail == kullanici.KullaniciEmail);
            bool telNoVarMi = authContext.Kullanicilar.Any(u => u.KullaniciTelNo == kullanici.KullaniciTelNo);
            bool sifreVarMi = authContext.Kullanicilar.Any(u => u.KullaniciSifre == kullanici.KullaniciSifre);
            if (emailVarMi)
            {
                ViewBag.HataMsg = "Kayıtlı Email Bulunmaktadır !!!";
                return View("KayitOl");

            } else if (telNoVarMi) {
                ViewBag.HataMsg = "Kayıtlı Telefon Numarası Bulunmaktadır !!!";
                return View("KayitOl");

            } else if (sifreVarMi){
                ViewBag.HataMsg = "Şifrenizi Değiştiriniz !!!";
                return View("KayitOl");
            }
            else{
                kullanici.KullaniciDt = kullanici.KullaniciDt.ToUniversalTime();
                authContext.Kullanicilar.Add(kullanici);
                authContext.SaveChanges();
                int kId = authContext.Kullanicilar.Where(u => u.KullaniciEmail == kullanici.KullaniciEmail).Select(u => u.KullaniciID).FirstOrDefault(); ;
                
                Rol r = new Rol()
                {
                    KisiTipiID = 2,
                    KullaniciID = kId
                };
                authContext.Roller.Add(r);
                authContext.SaveChanges();
                return RedirectToAction("BasariliKayit", kullanici);
            }
        }

        public IActionResult BasariliKayit(Kullanici kullanici)
        {
            return View(kullanici);
        }

        public IActionResult CikisYap()
        {
            HttpContext.Session.Remove("email");
            return View();
        }
    }
}