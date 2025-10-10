using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetUserBalance;

public class GetUserBalanceHandler(IGetUserBalanceService getUserBalanceService) : IQueryRequestHandler<GetUserBalanceQuery, double>
{
    public async Task<double> Handle(GetUserBalanceQuery query, CancellationToken cancellationToken = default)
    {
        return await getUserBalanceService.GetBalanceAsync(query.UserId, cancellationToken);
    }
}
