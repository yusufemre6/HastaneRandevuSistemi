using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HastaneRandevuSistemi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HastaneRandevuSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : Controller
    {
        ApplicationDbContext homeContext = new ApplicationDbContext();

        [HttpGet]
        public List<Doktor>  Get()
        {
            return homeContext.Doktorlar.ToList();
        }

        // POST api/values
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

