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
    public class CustomersController : ControllerBase
    {
        //db connection
        private readonly BoostTaskModel db;

        public CustomersController(BoostTaskModel db)
        {
            this.db = db;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await this.db.Customers.OrderBy(c => c.FullName).ToListAsync();
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            Customer customer = await this.db.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return this.NotFound();
            }
            return this.Ok(customer);
        }

        // POST: api/albums
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Customers.Add(customer);
            await this.db.SaveChangesAsync();
            return this.CreatedAtAction("Post", customer);
        }

        // PUT: api/albums/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer customer)
        {
            Customer _customer = await this.db.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);

            if (_customer == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this.db.SaveChangesAsync();

            return this.NoContent();
        }

        // DELETE: api/albums/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Customer customer = await this.db.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Customers.Remove(customer);
            await this.db.SaveChangesAsync();

            return this.Ok();
        }
    }
}