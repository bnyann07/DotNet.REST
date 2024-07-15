


namespace api.Dtos.Stock{
    public class StockDto{
        public int Id { get; set; }
        public int Purchase { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        // public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}