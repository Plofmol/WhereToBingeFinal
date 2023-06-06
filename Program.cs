using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WhereToBingeFinal.Data;

var builder = WebApplication.CreateBuilder(args);

// Set up your database connection string
var connectionString = "Data Source=fontysgroopyswoopy.database.windows.net;Initial Catalog=WTB;Persist Security Info=True;User ID=beheerder;Password=Testtest!";

// Add services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Add Swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WhereToBingeFinal", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhereToBingeFinal V1");
    });
}
else
{
    // Add any necessary production middleware here
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
