using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }

        [ForeignKey("product")]
        public required int ProductoId { get; set; }
        public Product Products { get; set; }

        [ForeignKey("order")]
        public required int OrderId { get; set; }
        public Order Orders { get; set; }
    }
}