using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoFactura.Context;
using ProyectoFactura.Services;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCors",
        builder =>
        {
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        }
);
});

builder.Services.AddDbContext<FacturasContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cadena"));
});

//Serializacion de los controladores con Json 
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    option.JsonSerializerOptions.Encoder = JavaScriptEncoder.Default;
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

app.UseRouting();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
