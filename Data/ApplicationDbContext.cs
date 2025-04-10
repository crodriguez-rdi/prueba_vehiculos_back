using Microsoft.EntityFrameworkCore;
using GestionVehiculos.Models;

namespace GestionVehiculos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}
