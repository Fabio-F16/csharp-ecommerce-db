using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_ecommerce_db
{
    [Table("product_order_quantity")]
    internal class ProductOrderQuantity
    {
        [Key]
        public int ProductOrderQuantityId { get; set; }

        public int Quantity { get; set; }
        public List<Product> products { get; set; }
        public List<Order> orders { get; set; }
    }
}
