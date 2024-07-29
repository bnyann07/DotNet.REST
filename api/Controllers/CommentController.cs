using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Mappers;
using api.Repository;
using api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase{
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comments = await _commentRepository.GetAllAsync();
            var commmentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(commmentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var commment = await _commentRepository.GetByIdAsync(id);
            if(commment == null){
                return NotFound();
            }
            return Ok(commment.ToCommentDto());
        }
        [HttpPost("{id:int}")]
        public async Task<IActionResult> CreateComment([FromRoute] int id, [FromBody] CreateCommentDto commentDto){
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(!await _stockRepository.StockExists(id)){
                return BadRequest("Stock does not exist");
            }
            var commment = commentDto.ToCommentFromCommentDto(id);
            await _commentRepository.CreateAsync(commment);
            return CreatedAtAction(nameof(GetById), new { id = commment.Id}, commment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto){
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var commment = await _commentRepository.UpdateAsync(id, updateDto.ToCommentFromUpdate());
            if(commment == null){
                return NotFound("Comment Not Found");
            }
            return Ok(commment.ToCommentDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var commment = await _commentRepository.DeleteAsync(id);
            if(commment == null) return NotFound("Comment Not Found");
            return Ok(commment.ToCommentDto());
        }
    }
}