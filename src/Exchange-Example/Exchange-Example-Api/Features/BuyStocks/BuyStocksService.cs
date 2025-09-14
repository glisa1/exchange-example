using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.BuyStocks;

public class BuyStocksService(AppDbContext dbContext) : IBuyStocksService
{
    public async Task BuyStocks(BuyStocksCommand model, Stock stock, CancellationToken cancellationToken = default)
    {
        var existingStocksForUser = await dbContext.UserStocks
            .Where(us => us.UserId == model.UserId && us.StockId == model.StockId)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingStocksForUser != null)
        {
            // Switch to execute update async method
            existingStocksForUser.Quantity += model.Quantity;
            dbContext.UserStocks.Update(existingStocksForUser);
        }
        else
        {
            var newUserStocks = new UserStocks
            {
                UserId = model.UserId,
                StockId = model.StockId,
                Stock = stock,
                Quantity = model.Quantity
            };
            await dbContext.UserStocks.AddAsync(newUserStocks, cancellationToken);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Stock?> GetStockById(int stockId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Stocks.FindAsync(stockId, cancellationToken);
    }
}
