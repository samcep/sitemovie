using Microsoft.EntityFrameworkCore;
using sitemovie.ApplicationContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer("name=DefaultConnection"));
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
