using GestionVehiculos.Models;
using Microsoft.AspNetCore.Mvc;
using GestionVehiculos.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionVehiculos.Repository; // Asegúrate de que la ruta al repositorio esté correcta

namespace GestionVehiculos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IRepository<Vehiculo> _vehiculoRepository;

        // Inyección del repositorio
        public VehiculosController(IRepository<Vehiculo> vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        // GET ALL
        [HttpGet("GetVehiculos")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            var vehiculos = await _vehiculoRepository.GetAllAsync();
            return Ok(vehiculos);
        }

        // GET (id)
        [HttpGet("GetVehiculo/{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _vehiculoRepository.GetByIdAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        // POST
        [HttpPost("AddVehiculo")]
        public async Task<ActionResult<Vehiculo>> PostVehiculo([FromForm] Vehiculo vehiculo)
        {
            await _vehiculoRepository.AddAsync(vehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }

        // PUT (id)
        [HttpPut("UpdateVehiculo/{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }

            await _vehiculoRepository.UpdateAsync(vehiculo);
            return NoContent();
        }

        // DELETE (id)
        [HttpDelete("DeleteVehiculo/{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _vehiculoRepository.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            await _vehiculoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
