using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("Users"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
app.AddRoutes();

app.Run();
