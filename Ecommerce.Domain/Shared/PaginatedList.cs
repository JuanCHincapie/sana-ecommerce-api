namespace ECommerce.Domain.Shared
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public int TotalRows { get; set; }
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(TotalRows / Convert.ToDecimal(PageSize)) : 0;
        public List<T> Data { get; set; }

    }
}
