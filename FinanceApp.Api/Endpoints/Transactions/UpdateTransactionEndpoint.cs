using System.Transactions;
using FinanceApp.Api.Common.Api;
using FinanceApp.Core.Handlers;
using FinanceApp.Core.Requests.Transactions;
using FinanceApp.Core.Responses;

namespace FinanceApp.Api.Endpoints;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Transactions: Update")
            .WithSummary("Atualizar uma transação")
            .WithDescription("Atualiza uma transação")
            .WithOrder(2)
            .Produces<Response<Transaction>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        UpdateTransactionRequest request,
        long id)
    {
        request.Id = id;
        request.UserId = ApiConfiguration.UserId;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}