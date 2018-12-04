namespace assignment2_api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using assignment2_api.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

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

        // GET: api/boosters/1
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

        // POST: api/boosters
        [HttpPost]
        public ActionResult Post([FromBody] Booster booster)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Boosters.Add(booster);
            this.db.SaveChanges();
            return this.CreatedAtAction("Post", booster);
        }

        // PUT: api/boosters
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Booster booster)
        {
            if (this.db.Boosters.Find(id) == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Entry(booster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.db.SaveChanges();
            return this.NoContent();
        }

        // DELETE: api/boosters
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var booster = this.db.Boosters.Find(id);

            if (booster == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Boosters.Remove(booster);
            this.db.SaveChanges();
            return this.Ok();
        }
    }
}