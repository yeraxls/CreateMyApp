using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
IoC.AddDBContexts(builder.Services);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
IoC.AddDependency(builder.Services);
var app = builder.Build();
app.AddRoutes();

app.Run();
