using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models{

        public class Comment {
            [Key]
            public int Id { get; set; }
            public int? StockId { get; set;}
            public string Title { get; set; } = string.Empty;
            public Stock? Stock { get; set; }
            public string Summary { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public DateTime CreateAt { get; set; } = DateTime.Now;
    }

}