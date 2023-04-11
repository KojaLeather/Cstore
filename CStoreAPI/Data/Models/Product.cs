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
        public Image? Images { get; set; }
    }
}
