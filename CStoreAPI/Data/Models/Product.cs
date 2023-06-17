using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CStoreAPI.Data.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; } =  null!;
        public string Description { get; set; } = null!;
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public virtual Image? Images { get; set; }
        [ForeignKey(nameof(Category))]
        public virtual int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
