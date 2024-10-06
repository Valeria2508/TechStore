using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTO.Customers
{
    public class CustomerDTO
    {
        public required string Name { get; set; }   
        public required string address { get; set; }
        public required string Phone_Number { get; set;}
        public required string Email { get; set; }
    }
}