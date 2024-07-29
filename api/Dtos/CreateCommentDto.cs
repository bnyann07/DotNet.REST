using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment{

    public class CreateCommentDto{
        [Required]
        [MinLength(5,ErrorMessage ="Title must be min. 5 characters long")]
        [MaxLength(10, ErrorMessage ="Title cannot be longer than 150 characters.")]
        public string Title { get; set;} = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage ="Content must be min. 5 characters long")]
        [MaxLength(10, ErrorMessage ="Content cannot be longer than 150 characters.")]
        public string Content { get; set;} = string.Empty;
    }
}