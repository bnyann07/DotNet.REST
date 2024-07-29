using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Stock;
using api.Helpers;
using Microsoft.Identity.Client;

namespace api.Repository
{
    public class StockRepository : IStockRepository{
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext dBContext){
            _context = dBContext;
        }
        public async Task<List<Stock>> GetAllStocksAsync(QueryObject query){
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.CompanyName)){
                stocks = stocks.Where(c => c.CompanyName.Contains(query.CompanyName));
            }
            if(!string.IsNullOrWhiteSpace(query.Ticker)){
                stocks = stocks.Where(s => s.Ticker.Contains(query.Ticker));
            }
            return await stocks.ToListAsync();
        }
        public async Task<Stock?> GetByIdAsync(int id) {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
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

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s=> s.Id == id);
        }
    }
}