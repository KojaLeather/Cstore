namespace CStoreAPI.Data.Services.ProductService
{
    public interface IProductService
    {
        public Task<int> GetProductCount();
    }
}
