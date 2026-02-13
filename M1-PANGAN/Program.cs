using Microsoft.EntityFrameworkCore;
using M1_PANGAN.Data;
using M1_PANGAN.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Items.Any())
    {
        db.Items.AddRange(
            new Item { Name = "Nike Air Max 270", Code = "NK-AM270", Brand = "Nike", UnitPrice = 6500 },
            new Item { Name = "Adidas Ultraboost 23", Code = "AD-UB23", Brand = "Adidas", UnitPrice = 7800 }
        );
        db.SaveChanges();
    }
}

app.Run();
