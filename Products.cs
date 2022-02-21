namespace StockPriceUpdateAPI
{
    public class Products
    {
        public int Id { get; set; }     
        public string SKU { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Brand { get; set; } = String.Empty;
        public int Capacity{ get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
