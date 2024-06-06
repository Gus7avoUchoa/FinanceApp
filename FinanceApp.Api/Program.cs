using Microsoft.EntityFrameworkCore;
using FinanceApp.Api.Data;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = 
    "Server=localhost,1433;Database=FinanceApp;User ID=sa;Password=S3nh4Sup3rDificil;Trusted_Connection=False; TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();