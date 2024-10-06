using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("User")]
    public class User
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Column("password")]
        [Required]
        public required string Password { get; set; }

        [ForeignKey("Role")]
        public required int RoleId { get; set; }
        public Role Roles { get; set; }
    }
}