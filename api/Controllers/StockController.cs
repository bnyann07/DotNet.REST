using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers{

    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase{
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context =context;
        }
        [HttpGet]
        public async Task<IActionResult> Getall(){
            var stocks =  await _context.Stocks.ToListAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);   
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var stock = _context.Stocks.Find(id);
            if(stock == null){
                return NotFound(stock);
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult CreateStock([FromBody] CreateStockRequestDto stockDto){
            var stockModel = stockDto.ToStockFromCreateDto();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if(stockModel == null){
                return NotFound();
            }
            stockModel.Ticker = updateDto.Ticker;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;
            
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStock([FromRoute] int id)  {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id ==id);
            if(stockModel == null){
                return NotFound();
            }
            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return NoContent();
        }
    }

}