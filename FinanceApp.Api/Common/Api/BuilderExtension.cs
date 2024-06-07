using FinanceApp.Api.Data;
using FinanceApp.Api.Handlers;
using FinanceApp.Core;
using FinanceApp.Core.Handlers;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddDataContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(ApiConfiguration.ConnectionString);
            });

            // builder.Services
            //     .AddIdentityCore<User>()
            //     .AddRoles<IdentityRole<long>>()
            //     .AddEntityFrameworkStores<AppDbContext>()
            //     .AddApiEndpoints();
        }

        public static void AddCorsOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(ApiConfiguration.CorsPolicyName, 
                    policy => policy.WithOrigins([
                                    Configuration.BackendUrl,
                                    Configuration.FrontendUrl])
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
            });
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
            builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
        }
    }
}