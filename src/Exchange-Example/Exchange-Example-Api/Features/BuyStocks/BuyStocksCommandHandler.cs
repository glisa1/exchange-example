using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.BuyStocks;

public class BuyStocksCommandHandler(IBuyStocksService buyStocksService) : ICommandRequestHandler<BuyStocksCommand, bool>
{
    public async Task<bool> Handle(BuyStocksCommand command, CancellationToken cancellationToken = default)
    {
        var stock = await buyStocksService.GetStockById(command.StockId, cancellationToken);

        if (stock == null)
        {
            // Use when switch to Options result
            // return Results.NotFound(new { Message = $"Stock with ID {stocks.StockId} not found." });
            return false;
        }

        // Additional check if the user has money to buy the stocks. But that could also be handled in another api call.

        await buyStocksService.BuyStocks(command, stock, cancellationToken);
        return true;
    }
}
