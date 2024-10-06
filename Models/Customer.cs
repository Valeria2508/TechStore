using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public required int Id { get; set; } //poner required en todo

        [Required]
        [MaxLength(50)]
        [Column("name")]
        public required string Name { get; set; }   

        [Required]
        [MaxLength(100)]
        [Column("address")]
        public required string address { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("phone_number")]
        public required string Phone_Number { get; set;}

        [Required]
        [MaxLength(50)]
        [Column("email")]
        public required string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}