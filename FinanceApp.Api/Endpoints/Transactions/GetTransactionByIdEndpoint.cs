using System.Transactions;
using FinanceApp.Api.Common.Api;
using FinanceApp.Core.Handlers;
using FinanceApp.Core.Requests.Transactions;
using FinanceApp.Core.Responses;

namespace FinanceApp.Api.Endpoints;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Transactions: GetById")
            .WithSummary("Obter uma transação pelo Id")
            .WithDescription("Obtém uma transação pelo Id")
            .WithOrder(4)
            .Produces<Response<Transaction>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        long id)
    {
        var request = new GetTransactionByIdRequest
        {
            Id = id,
            UserId = ApiConfiguration.UserId
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}