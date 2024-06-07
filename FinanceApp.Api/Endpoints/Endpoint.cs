using FinanceApp.Api.Common.Api;
using FinanceApp.Api.Data;
using FinanceApp.Api.Endpoints.Categories;

namespace FinanceApp.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoint = app.MapGroup("");

            endpoint.MapGroup("/")
                .WithTags("Check")
                .MapGet("/", () => new { Status = "FinanceApp API - [ 👍🏼 ]" });

            endpoint.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("health", (AppDbContext dbContext)
                    => new { Status = dbContext.Database.CanConnect() ?  "Database - [ 👍🏼 ] " : "Database - [ 👎🏼 ]" });

            endpoint.MapGroup("v1/categories")
                .WithTags("Categories")
                .MapEndpoint<CreateCategoryEndpoint>()
                .MapEndpoint<DeleteCategoryEndpoint>()
                .MapEndpoint<GetAllCategoryEndpoint>()
                .MapEndpoint<GetCategoryByIdEndpoint>()
                .MapEndpoint<UpdateCategoryEndpoint>();

            endpoint.MapGroup("v1/transactions")
                .WithTags("Transactions")
                .MapEndpoint<CreateTransactionEndpoint>()
                .MapEndpoint<DeleteTransactionEndpoint>()
                .MapEndpoint<GetTransactionByIdEndpoint>()
                .MapEndpoint<GetTransactionByPeriodEndpoint>()
                .MapEndpoint<UpdateTransactionEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}