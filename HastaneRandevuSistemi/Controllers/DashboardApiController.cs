using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var query = from randevu in dashContext.Randevular.Where(r => r.KullaniciID == kullaniciID)
                        join brans in dashContext.Branslar on randevu.BransID equals brans.BransID
                        join poliklinik in dashContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                        join hastane in dashContext.Hastaneler on randevu.HastaneID equals hastane.HastaneID
                        join doktor in dashContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                        join durum in dashContext.Durumlar on randevu.DurumID equals durum.DurumID
                        join muayenetur in dashContext.MuayeneTurleri on randevu.MuayeneTurID equals muayenetur.MuayeneTurID
                        
                        select new
                        {
                            randevu.RandevuID,
                            randevu.RandevuTarihSaat,
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
        public void Put(int id)
        {
            // LINQ sorgusu ile veriyi getir
            var entityToUpdate = dashContext.Randevular.SingleOrDefault(e => e.RandevuID == id);

            // Veriyi güncelle
            if (entityToUpdate != null)
            {
                entityToUpdate.DurumID = 3;
            }

            // Veritabanını güncelle
            dashContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

