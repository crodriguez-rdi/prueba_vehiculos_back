using GestionVehiculos.Data;
using GestionVehiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVehiculos.Repository
{
    public class VehiculoRepository : IRepository<Vehiculo>
    {
        private readonly ApplicationDbContext _context;

        public VehiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos.ToListAsync(); // Recupera todos los vehículos
        }

        public async Task<Vehiculo> GetByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id); // Recupera un vehículo por id
        }

        public async Task AddAsync(Vehiculo entity)
        {
            await _context.Vehiculos.AddAsync(entity); // Añade un nuevo vehículo
            await _context.SaveChangesAsync(); // Guarda los cambios
        }

        public async Task UpdateAsync(Vehiculo entity)
        {
            _context.Entry(entity).State = EntityState.Modified; // Marca el vehículo como modificado
            await _context.SaveChangesAsync(); // Guarda los cambios
        }

        public async Task DeleteAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id); // Busca el vehículo
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo); // Elimina el vehículo
                await _context.SaveChangesAsync(); // Guarda los cambios
            }
        }
    }
}