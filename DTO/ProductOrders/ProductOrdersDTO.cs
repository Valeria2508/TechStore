using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTO.ProductOrders
{
    public class ProductOrdersDTO
    {
        public required int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required decimal ProductPrice { get; set; }
        public required int ProductQuantity { get; set; }
    }
}