

using api.Dtos.Comment;
using api.Models;

namespace api.Mappers{
    public static class CommentMapper{
        public static CommentDto ToCommentDto(this Comment commentModel){
            return new CommentDto{
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt
            };
        }
        public static Comment ToCommentFromCommentDto(this CreateCommentDto commentDto, int stockId){
            return new Comment{
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto){
            return new Comment{
                Title = commentDto.Title,
                Content = commentDto.Content
            };
        }
    }
}