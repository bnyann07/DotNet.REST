

using System;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers{
        public static StockDto ToStockDto(this Stock stockModel){
            
            return new StockDto{
                Id = stockModel.Id,
                Purchase = stockModel.Purchase,
                Ticker = stockModel.Ticker,
                CompanyName = stockModel.CompanyName,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(x => x.ToCommentDto()).ToList()
            };
        }
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto){
            return new Stock{
                Purchase = stockDto.Purchase,
                CompanyName = stockDto.CompanyName,
                Ticker = stockDto.Ticker,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}