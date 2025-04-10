using GestionVehiculos.Data;
using GestionVehiculos.Models;
using GestionVehiculos.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuraci�n de CORS (si es necesario)
builder.Services.AddScoped<IRepository<Vehiculo>, VehiculoRepository>();

// Configuraci�n de DbContext y conexi�n a la base de datos (Npgsql para PostgreSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configuraci�n de Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Esto solo habilitar� Swagger en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; // Esto hace que Swagger se cargue en la ra�z: http://localhost:5000
    });
}

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseHttpsRedirection();  // Aseg�rate de que la redirecci�n a HTTPS funcione

app.UseAuthorization();

app.MapControllers();

app.Run();
