using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers{

    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase{
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _context =context;
            _stockRepository =stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Getall(){
            var stocks =  await _stockRepository.GetAllStocksAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);   
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _stockRepository.GetByIdAsync(id);
            if(stock == null){
                return NotFound(stock);
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto stockDto){
            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var stockModel = await _stockRepository.UpdateAsync(id, updateDto);
            if(stockModel == null){
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)  {
            var stockModel = await _stockRepository.DeleteAsync(id);
            if(stockModel == null){
                return NotFound();
            }
            return NoContent();
        }
    }

}