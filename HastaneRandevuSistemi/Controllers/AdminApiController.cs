using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HastaneRandevuSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : Controller
    {
        ApplicationDbContext adminContext = new ApplicationDbContext();
        [HttpGet]
        public IQueryable Get()
        {
            var query = from doktor in adminContext.Doktorlar
                        join cinsiyet in adminContext.Cinsiyetler on doktor.CinsiyetID equals cinsiyet.CinsiyetID
                        join derece in adminContext.Dereceler on doktor.DereceID equals derece.DereceID
                        join brans in adminContext.Branslar on doktor.BransID equals brans.BransID
                        select new 
                        {
                            doktor.DoktorID,
                            doktor.DoktorAdi,
                            doktor.DoktorSoyadi,
                            cinsiyet.CinsiyetAdi,
                            doktor.DoktorDt,
                            doktor.DoktorEmail,
                            doktor.DoktorTelNo,
                            brans.BransAdi,
                            derece.DereceAdi
                        };
            return query;
        }

        
        [HttpPost]
        public void Post()
        {
          
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // LINQ sorgusu ile veriyi getir
            var entityToDelete = adminContext.Doktorlar.SingleOrDefault(e => e.DoktorID == id);
            List<Poliklinik> polikliniks = adminContext.Poliklinikler.Where(x => x.DoktorID == entityToDelete.DoktorID).ToList();
            List<Randevu> randevus= adminContext.Randevular.Where(x => x.DoktorID == entityToDelete.DoktorID).ToList();
            // Veriyi güncelle
            if (entityToDelete != null)
            {
                foreach (var item in polikliniks)
                {
                    adminContext.Poliklinikler.Remove(item);
                }
                foreach (var item in randevus)
                {
                    adminContext.Randevular.Remove(item);
                }
                adminContext.Doktorlar.Remove(entityToDelete);
            }
            adminContext.SaveChanges();
        }
    }
}

