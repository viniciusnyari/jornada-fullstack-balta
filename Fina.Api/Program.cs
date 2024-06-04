using Fina.Api;
using Fina.Api.Common.Api;
using Fina.Api.Data.Mappings;
using Fina.Api.Endpoints;
using Fina.Api.Handlers;
using Fina.Shared.Handler;
using Fina.Shared.Requests.Categories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();