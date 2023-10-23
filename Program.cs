using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("Users"));
builder.Services.AddDbContext<OrderDb>(opt => opt.UseInMemoryDatabase("Orders"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
IoC.AddDependency(builder.Services);
var app = builder.Build();
app.AddRoutes();

app.Run();
