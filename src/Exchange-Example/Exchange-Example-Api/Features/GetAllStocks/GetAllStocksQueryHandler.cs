using Exchange_Example_Api.Data.Models;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetAllStocks;

public class GetAllStocksQueryHandler(IGetAllStocksService getAllStocksService) : IQueryRequestHandler<GetAllStocksQuery, List<Stock>>
{
    public async Task<List<Stock>> Handle(GetAllStocksQuery query, CancellationToken cancellationToken = default)
    {
        return await getAllStocksService.GetAllStocks(cancellationToken);
    }
}
