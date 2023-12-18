using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;


namespace HastaneRandevuSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : Controller
    {
        ApplicationDbContext homeContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable Get()
        {
            var query = from doktor in homeContext.Doktorlar
                        join cinsiyet in homeContext.Cinsiyetler on doktor.CinsiyetID equals cinsiyet.CinsiyetID
                        join derece in homeContext.Dereceler on doktor.DereceID equals derece.DereceID
                        join brans in homeContext.Branslar on doktor.BransID equals brans.BransID
                        select new
                        {
                            doktor.DoktorAdi,
                            doktor.DoktorSoyadi,
                            cinsiyet.CinsiyetAdi,
                            doktor.DoktorEmail,
                            brans.BransAdi,
                            derece.DereceAdi
                        };
            return query;
        }

        
        [HttpPost]
        public void Post([FromBody]string value)
        {
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

