namespace ECommerce.Domain.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int AvailableStock { get; set; }
        public string? CategoryName { get; set; }
    }
}
