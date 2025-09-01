using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.GetAllStocks;

public interface IGetAllStocksService
{
    Task<List<Stock>> GetAllStocks();
}
