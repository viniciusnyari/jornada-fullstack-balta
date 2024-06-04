using Fina.Api.Data.Mappings;
using Fina.Api.Handlers;
using Fina.Shared.Handler;
using Fina.Shared.Requests.Categories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = "Server=localhost,1433;Database=fina;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.MapGet("/", (GetCategoryByIdRequest request, ICategoryHandler handler) => handler.GetByIdAsync(request));

app.Run();
