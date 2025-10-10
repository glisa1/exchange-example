using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.WithdrawCash;

public class WithdrawCashCommandHandler(IWithdrawCashService withdrawCashService) : ICommandRequestHandler<WithdrawCashCommand, WithdrawCashResult>
{
    public async Task<WithdrawCashResult> Handle(WithdrawCashCommand command, CancellationToken cancellationToken = default)
    {
        return await withdrawCashService.Withdraw(command.UserId, command.Amount, cancellationToken);
    }
}
