using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace api.Dtos.Stock
{    
        public class UpdateStockRequestDto{
            [Required]
            [MinLength(5,ErrorMessage ="Title must be min. 5 characters long")]
            [Range(1, 1000000)]
            public int Purchase { get; set; }
            [Required]
            [MinLength(5,ErrorMessage ="Title must be min. 5 characters long")]
            [MaxLength(10, ErrorMessage ="Title cannot be longer than 150 characters.")]
            public string CompanyName { get; set; } = string.Empty;
             [Required]
            [MinLength(5,ErrorMessage ="Title must be min. 5 characters long")]
            [MaxLength(10, ErrorMessage ="Title cannot be longer than 150 characters.")]
            public string Industry { get; set; } = string.Empty;
            [Required]
            [MinLength(5,ErrorMessage ="Title must be min. 5 characters long")]
            [MaxLength(10, ErrorMessage ="Title cannot be longer than 150 characters.")]
            public string Ticker { get; set; } = string.Empty;
            public long MarketCap { get; set; }
        }
}