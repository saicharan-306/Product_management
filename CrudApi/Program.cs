using CrudApi.Data;
using CrudApi.NewFolder.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Allow all origins for dev
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!dbContext.Products.Any())
    {
        dbContext.Products.AddRange(
            new Product { Name = "Apple", Category = "Fruits", Price = 0.99M },
            new Product { Name = "Banana", Category = "Fruits", Price = 0.59M },
            new Product { Name = "Carrot", Category = "Vegetables", Price = 0.39M }
        );
        dbContext.SaveChanges();
    }
}

app.Run();
