using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CStoreAPI.Data.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Phone { get; set; } = null!;
        public string EMail { get; set; } = null!;
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
