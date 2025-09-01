using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.BuyStocks;

public class BuyStocksService(AppDbContext dbContext) : IBuyStocksService
{
    public async Task BuyStocks(BuyStocksModel model)
    {
        var existingStocksForUser = await dbContext.UserStocks
            .Where(us => us.UserId == model.UserId && us.StockId == model.StockId)
            .FirstOrDefaultAsync();

        if (existingStocksForUser != null)
        {
            var updatedStocks = existingStocksForUser with
            {
                Quantity = existingStocksForUser.Quantity + model.Quantity
            };
            dbContext.UserStocks.Update(updatedStocks);
        }
        else
        {
            var newUserStocks = new UserStocks(
                0,
                model.UserId,
                model.StockId,
                model.Quantity
            );
            await dbContext.UserStocks.AddAsync(newUserStocks);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> StockExists(int stockId)
    {
        return await dbContext.Stocks.AnyAsync(s => s.Id == stockId);
    }
}
