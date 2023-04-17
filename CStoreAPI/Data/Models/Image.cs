using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CStoreAPI.Data.Models
{
    public class Image
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FilePath { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public virtual int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
