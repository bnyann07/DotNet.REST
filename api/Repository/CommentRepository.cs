using api.Data;
using api.Models;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.Dtos;

namespace api.Repository
{
    public class CommentRepository: ICommentRepository{
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<Comment?> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == id);
            if (comment == null) return null;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync(){
            return await _context.Comments.ToListAsync();
        }
        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if(existingComment == null) return null;
            
            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;
            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}