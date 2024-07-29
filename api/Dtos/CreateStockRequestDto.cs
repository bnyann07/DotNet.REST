

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace api.Dtos.Stock{

    public class CreateStockRequestDto{
        [Required]
        [Range(1, 1000000)]
        public decimal Purchase { get; set; } = 0.00m;
        [Required]
        [MaxLength(15, ErrorMessage = "Longer than 15")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Longer than 10")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "Longer than 15")]
        public string Ticker { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}