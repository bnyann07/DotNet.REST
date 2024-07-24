using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Stock;

namespace api.Repository
{
    public class StockRepository : IStockRepository{
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext dBContext){
            _context = dBContext;
        }
        public async Task<List<Stock>> GetAllStocksAsync(){
            return await _context.Stocks.ToListAsync();
        }
        public async Task<Stock?> GetByIdAsync(int id) {
            return await _context.Stocks.FindAsync(id);
        }
        public async Task<Stock> CreateAsync(Stock stock) {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
        public async Task<Stock?> DeleteAsync(int id) {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null) {
                return null;
            }
            _context.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto) {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stock == null) {
                return null;
            }
            stock.Ticker = stockDto.Ticker;
            stock.Purchase = stockDto.Purchase;
            stock.CompanyName = stockDto.CompanyName;
            stock.Industry = stockDto.Industry;
            stock.MarketCap = stockDto.MarketCap;
            
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}