using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_ecommerce_db
{
    [Table("order")]
    internal class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }


        public List<Customer> Customers { get; set; }
        public int ProductOrderQuantityId { get; set; }
        public ProductOrderQuantity ProductOrderQuantity { get; set; }
    }
}
