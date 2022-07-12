using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_ecommerce_db
{
    [Table("product")]
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Order> Orders { get; set; }

    }
}
