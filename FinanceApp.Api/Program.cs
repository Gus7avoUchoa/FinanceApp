using FinanceApp.Api.Common.Api;
using FinanceApp.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
// builder.AddSecurity();
builder.AddDataContext();
builder.AddCorsOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
// app.UseSecurity();
app.MapEndpoints();

app.Run();