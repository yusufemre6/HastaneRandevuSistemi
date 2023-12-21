using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Controllers
{
    [Authorize(Roles = "1")]
    public class AdminController : Controller
	{
		public IActionResult AdminBaslangic()
		{
            ViewData["Role"] = "1";
            return View();
		}

        public IActionResult DoktorListele()
        {
            ViewData["Role"] = "1";
            return View();
        }

        public IActionResult HastaneListele()
        {
            ViewData["Role"] = "1";
            return View();
        }

        public IActionResult PoliklinikListele()
        {
            ViewData["Role"] = "1";
            return View();
        }

        [HttpGet]
        public IActionResult GetDoktorEkle()
        {
            ViewData["Role"] = "1";
            return View();
        }

        [HttpPost]
        public IActionResult PostDoktorEkle()
        {
            return View();
        }

        public IActionResult DoktorSil()
        {
            ViewData["Role"] = "1";
            return View();
        }

        [HttpGet]
        public IActionResult GetHastaneEkle()
        {
            ViewData["Role"] = "1";
            return View();
        }

        [HttpPost]
        public IActionResult PostHastaneEkle()
        {
            return View();
        }

       
        public IActionResult HastaneSil()
        {
            ViewData["Role"] = "1";
            return View();
        }

        [HttpGet]
        public IActionResult GetPoliklinikEkle()
        {
            ViewData["Role"] = "1";
            return View();
        }

        [HttpPost]
        public IActionResult PostPoliklinikEkle()
        {

            return View();
        }

        public IActionResult PoliklinikSil()
        {
            ViewData["Role"] = "1";
            return View();
        }

    }
}
