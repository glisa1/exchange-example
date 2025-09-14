using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.GetAllStocks;

public class GetAllStocksService(AppDbContext appDbContext) : IGetAllStocksService
{
    public async Task<List<Stock>> GetAllStocks(CancellationToken cancellationToken = default)
    {
        return await appDbContext.Stocks.ToListAsync(cancellationToken);
    }
}
