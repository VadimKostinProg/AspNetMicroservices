namespace Shopping.Aggregator.Models
{
    public class CatalogModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageFile { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
