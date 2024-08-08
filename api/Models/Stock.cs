using System;
// using System.Collection.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models{

    public class Stock{

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Purchase { get; set; }
        [MaxLength(12, ErrorMessage = "Longer than 15")]
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
