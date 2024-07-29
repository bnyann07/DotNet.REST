



namespace api.Helpers{
    public class QueryObject{
        public string? Ticker {get; set;} = null;
        public string? CompanyName {get; set;} = null;
        public string? SortBy {get; set;} = null;
        public bool IsDescending {get; set;} = false;
    }
}