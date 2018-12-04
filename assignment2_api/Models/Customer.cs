using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2_api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("Booster")]
        public int BoosterId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLogon { get; set; }
    }
}
