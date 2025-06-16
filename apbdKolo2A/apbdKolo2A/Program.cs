using apbdKolo2A.Database;
using apbdKolo2A.Services;
using Microsoft.EntityFrameworkCore;

using apbdKolo2A.Database;
using apbdKolo2A.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("Default");
Console.WriteLine($"CONNECTION: {connectionString}");
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DatabaseContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    }
);
builder.Services.AddScoped<IDbService, DbService>();
//builder.Services.AddScoped<>()


builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    try
    {
        Console.WriteLine("⏳ Sprawdzam połączenie z bazą...");
        var ok = context.Database.CanConnect();
        Console.WriteLine(ok ? "✅ Połączenie z bazą działa." : "❌ Nie udało się połączyć z bazą.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Błąd połączenia: {ex.Message}");
    }
}

app.Run();