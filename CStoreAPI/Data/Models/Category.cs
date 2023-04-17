using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CStoreAPI.Data.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public virtual ICollection<Product>? Product { get; set; }
    }
}
