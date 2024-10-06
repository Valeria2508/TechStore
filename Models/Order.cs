using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public required int Id { get; set; }

        [Column("state_order")]
        [Required]
        public required string StateOrder { get; set; }
        
        [Column("date_order")]
        [Required]
        public DateTime DateOrder { get; set; }

        [ForeignKey("customer")]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }

    }
}