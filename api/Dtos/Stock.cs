using api.Dtos.Comment;


namespace api.Dtos.Stock{
    public class StockDto{
        public int Id { get; set; }
        public decimal Purchase { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}