using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.BuyStocks;

public class BuyStocksService(AppDbContext dbContext) : IBuyStocksService
{
    public async Task BuyStocks(BuyStocksCommand command, Stock stock, CancellationToken cancellationToken = default)
    {
        var existingStocksForUser = await dbContext.UserStocks
            .Where(us => us.UserId == command.UserId && us.StockId == command.StockId)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingStocksForUser != null)
        {
            // Switch to execute update async method
            existingStocksForUser.Quantity += command.Quantity;
            dbContext.UserStocks.Update(existingStocksForUser);
        }
        else
        {
            var newUserStocks = new UserStocks
            {
                UserId = command.UserId,
                StockId = command.StockId,
                Stock = stock,
                Quantity = command.Quantity
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
