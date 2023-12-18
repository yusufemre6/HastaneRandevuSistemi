using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HastaneRandevuSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardApiController : Controller
    {
        ApplicationDbContext dashContext = new ApplicationDbContext();

        
        [HttpGet]
        public IQueryable Get(int kullaniciID)
        {
            Console.WriteLine(kullaniciID);
            var query = from randevu in dashContext.Randevular.Where(r => r.KullaniciID == kullaniciID)
                        join brans in dashContext.Branslar on randevu.BransID equals brans.BransID
                        join poliklinik in dashContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                        join hastane in dashContext.Hastaneler on randevu.HastaneID equals hastane.HastaneID
                        join doktor in dashContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                        join durum in dashContext.Durumlar on randevu.DurumID equals durum.DurumID
                        join muayenetur in dashContext.MuayeneTurleri on randevu.MuayeneTurID equals muayenetur.MuayeneTurID
                        
                        select new
                        {
                            randevu.RandevuGun,
                            randevu.RandevuAy,
                            randevu.RandevuYil,
                            randevu.Saat,
                            randevu.Dakika,
                            brans.BransAdi,
                            poliklinik.PoliklinikAdi,
                            hastane.HastaneAdi,
                            doktor.DoktorAdi,
                            doktor.DoktorSoyadi,
                            durum.DurumAdi,
                            muayenetur.MuayeneTurAdi
                        };
            return query;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

