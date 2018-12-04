using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2_api.Controllers
{
    using assignment2_api.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class BoostersController : ControllerBase
    {
        //db connection
        private BoostTaskModel db;

        public BoostersController(BoostTaskModel db)
        {
            this.db = db;
        }

        // GET: api/boosters
        [HttpGet]
        public IEnumerable<Booster> Get()
        {
            return this.db.Boosters.OrderBy(b => b.FullName).ToList();
        }

        //GET: api/boosters/1
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var booster = this.db.Boosters.Find(id);

            if (booster != null)
            {
                return this.Ok(booster);
            }
            return this.NotFound();
        }


    }
}