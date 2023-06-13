using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CStoreAPI.Data.Models
{
    public class ImageBase64
    {
        [Key]
        [Required]
        public string Base64 { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}
