using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.DepositCash;

public class DepositCashCommandHandler(IDepositCashService depositCashService) : ICommandRequestHandler<DepositCashCommand, DepositCashResult>
{
    public async Task<DepositCashResult> Handle(DepositCashCommand command, CancellationToken cancellationToken = default)
    {
        return await depositCashService.DepositCashAsync(command.UserId, command.Amount, cancellationToken);
    }
}
