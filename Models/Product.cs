using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Column("description")]
        [Required]
        [StringLength(500)]
        public required string Description { get; set; }

        [Column("price")]
        [Required]
        public required decimal Price { get; set; }

        [Column("quantity")]
        [Required]
        public required int Quantity { get; set; }

        [ForeignKey("productCategory")]
        [Column("categoryId")]
        public required int ProductCategoryId { get; set; }
        public ProductCategory ProductCategories { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}