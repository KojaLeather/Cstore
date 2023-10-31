namespace CStoreAPI.Data.Models.DTO
{
    public class PaginationParams
    {
        //dont have time to make dinamic design, so max is 10
        private const int _maxItemsPerPage = 10;
        private int itemsPerPage;
        public int Page { get; set; } = 1;
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
    }
}
