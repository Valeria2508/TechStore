using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTO.ProductOrders;
using TechStore.Models;

namespace TechStore.DTO.Orders
{
    public class OrderDTO
    {
        public required string StateOrder { get; set; }
        public required DateTime DateOrder { get; set; }
        public required int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public required List<ProductOrdersDTO> ProductOrders { get; set; }
    }
}