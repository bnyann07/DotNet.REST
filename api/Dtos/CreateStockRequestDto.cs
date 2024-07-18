

using System;
using System.Threading.Tasks;

namespace api.Dtos.Stock{

    public class CreateStockRequestDto{
        public decimal Purchase { get; set; } = 0.00m;
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}