namespace CStoreAPI.Data.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public string Base64String { get; set; } = null!;
        public string ImageName { get; set; } = null!;
    }
}
