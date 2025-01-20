using Microsoft.EntityFrameworkCore;
using VinylStore.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VinylStoreContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseBlazorFrameworkFiles();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
