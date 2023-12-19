using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult AdminBaslangic()
		{

			return View();
		}

        public IActionResult DoktorListele()
        {
            return View();
        }

        public IActionResult HastaneListele()
        {
            return View();
        }

        public IActionResult PoliklinikListele()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDoktorEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostDoktorEkle()
        {
            return View();
        }

        public IActionResult DoktorSil()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetHastaneEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostHastaneEkle()
        {
            return View();
        }

       
        public IActionResult HastaneSil()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPoliklinikEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostPoliklinikEkle()
        {
            return View();
        }

        public IActionResult PoliklinikSil()
        {
            return View();
        }

    }
}
