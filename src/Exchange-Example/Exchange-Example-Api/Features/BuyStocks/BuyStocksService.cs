using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.BuyStocks;

public class BuyStocksService(AppDbContext dbContext) : IBuyStocksService
{
    public async Task BuyStocks(BuyStocksModel model, Stock stock)
    {
        var existingStocksForUser = await dbContext.UserStocks
            .Where(us => us.UserId == model.UserId && us.StockId == model.StockId)
            .FirstOrDefaultAsync();

        if (existingStocksForUser != null)
        {
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
            await dbContext.UserStocks.AddAsync(newUserStocks);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task<Stock?> GetStockById(int stockId)
    {
        return await dbContext.Stocks.FindAsync(stockId);
    }
}
