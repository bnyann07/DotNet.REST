using api.Dtos.Stock;
using api.Models;


namespace api.Interfaces
{
    public interface IStockRepository{
        Task<List<Stock>> GetAllStocksAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id) ;
    }
}