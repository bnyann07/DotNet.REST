using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Dtos.Stock
{    
        public class UpdateStockRequestDto{
            public int Purchase { get; set; }
            public string CompanyName { get; set; } = string.Empty;
            public string Industry { get; set; } = string.Empty;
            public string Ticker { get; set; } = string.Empty;
            public long MarketCap { get; set; }
        }
}