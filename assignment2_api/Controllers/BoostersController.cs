namespace assignment2_api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using assignment2_api.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class BoostersController : ControllerBase
    {
        //db connection
        private readonly BoostTaskModel db;

        public BoostersController(BoostTaskModel db)
        {
            this.db = db;
        }

        // GET: api/boosters
        [HttpGet]
        public async Task<IEnumerable<Booster>> Get()
        {
            return await this.db.Boosters.OrderBy(b => b.FullName).ToListAsync();
        }

        // GET: api/boosters/1
        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var booster = await this.db.Boosters.SingleOrDefaultAsync(b => b.BoosterId == id);

            if (booster != null)
            {
                return this.Ok(booster);
            }

            return this.NotFound();
        }

        // POST: api/boosters
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Booster booster)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Boosters.Add(booster);
            await this.db.SaveChangesAsync();

            return this.CreatedAtAction("Post", booster);
        }

        // PUT: api/boosters
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Booster booster)
        {
            var _booster = await this.db.Boosters.SingleOrDefaultAsync(b => b.BoosterId == id);

            if (_booster == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Entry(booster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this.db.SaveChangesAsync();
            return this.NoContent();
        }

        // DELETE: api/boosters
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var booster = await this.db.Boosters.SingleOrDefaultAsync(b => b.BoosterId == id);

            if (booster == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Boosters.Remove(booster);
            await this.db.SaveChangesAsync();

            return this.Ok();
        }
    }
}