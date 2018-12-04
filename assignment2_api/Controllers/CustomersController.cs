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
    public class CustomersController : ControllerBase
    {
        //db connection
        private BoostTaskModel db;

        public CustomersController(BoostTaskModel db)
        {
            this.db = db;
        }

        // GET: api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return this.db.Customers.OrderBy(c => c.FullName).ToList();
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Customer customer = this.db.Customers.Find(id);

            if (customer == null)
            {
                return this.NotFound();
            }
            return this.Ok(customer);
        }

        // POST: api/albums
        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Customers.Add(customer);
            this.db.SaveChanges();
            return this.CreatedAtAction("Post", customer);
        }

        // PUT: api/albums/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            if (this.db.Customers.Find(id) == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.db.SaveChanges();
            return this.NoContent();
        }

        // DELETE: api/albums/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = this.db.Customers.Find(id);

            if (customer == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Customers.Remove(customer);
            this.db.SaveChanges();
            return this.Ok();
        }
    }
}