using Microsoft.EntityFrameworkCore;
using ProyectoFactura.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FacturasContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cadena"));
});

//Serializacion de los controladores con Json 
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Facturas API v1.0");
            //c.RoutePrefix = String.Empty;
        }
        );
}


app.UseAuthorization();

app.MapControllers();

app.Run();
