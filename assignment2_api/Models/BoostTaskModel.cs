namespace assignment2_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The boost task model.
    /// </summary>
    public class BoostTaskModel : DbContext
    {
        public BoostTaskModel(DbContextOptions<BoostTaskModel>options)
            : base(options)
        {
            
        }

        // reference the Customer model for CRUD
        public DbSet<Customer> Customers { get; set; }

        // reference the Booster model for CRUD
        public DbSet<Booster> Boosters { get; set; }
    }
}
