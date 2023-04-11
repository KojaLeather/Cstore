using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CStoreAPI.Data.Models
{
    public class Image
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        [NotMapped]
        public string? Base64 { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
