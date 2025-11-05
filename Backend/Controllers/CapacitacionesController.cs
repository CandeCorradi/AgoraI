using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionesController : ControllerBase
    {
        private readonly AgoraContext _context;

        public CapacitacionesController(AgoraContext context)
        {
            _context = context;
        }

        // GET: api/Capacitaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetCapacitaciones([FromQuery] string? filter="")
        {
            return await _context.Capacitaciones
                .AsNoTracking().Include(c=> c.TiposDeInscripciones).ThenInclude(t=>t.TipoInscripcion)
                .Where(c => c.Nombre.Contains(filter, StringComparison.OrdinalIgnoreCase)
                        || c.Detalle.Contains(filter, StringComparison.OrdinalIgnoreCase)
                        || c.Ponente.Contains(filter, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }


        [HttpGet("abiertas/")]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetCapacitacionesAbiertas ([FromQuery] string? filter = "")
        {
            return await _context.Capacitaciones
                .AsNoTracking().Include(c => c.TiposDeInscripciones).ThenInclude(t => t.TipoInscripcion)
                .Where(c => !c.InscripcionAbierta &&(c.Nombre.Contains(filter) 
                    || c.Detalle.Contains(filter) 
                    || c.Ponente.Contains(filter)))
                .ToListAsync();
        }

        [HttpGet("futuras/")]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetCapacitacionesFuturas([FromQuery] string? filter = "")
        {
            return await _context.Capacitaciones
                .AsNoTracking().Include(c => c.TiposDeInscripciones).ThenInclude(t => t.TipoInscripcion)
                .Where(c => !c.InscripcionAbierta 
                          && c.FechaHora.Date > DateTime.Now.Date 
                         && (c.Nombre.Contains(filter) 
                              || c.Detalle.Contains(filter) 
                              || c.Ponente.Contains(filter)))
                .ToListAsync();
        }

        // GET: api/Capacitaciones
        [HttpGet("deleteds/")]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetCapacitacionesDeleteds()
        {
            return await _context.Capacitaciones.
                IgnoreQueryFilters().Where(c=>c.IsDeleted).ToListAsync();
        }

        // GET: api/Capacitaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacitacion>> GetCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);

            if (capacitacion == null)
            {
                return NotFound();
            }

            return capacitacion;
        }

        // PUT: api/Capacitaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacitacion(int id, Capacitacion capacitacion)
        {
            if (id != capacitacion.Id)
            {
                return BadRequest();
            }
            //attach = atachamos las entidades de tipo inscripcion para que no intente crearlas de nuevo
            foreach (var tipoInscripcionCapacitacion in capacitacion.TiposDeInscripciones)
            {
                _context.Attach(tipoInscripcionCapacitacion.TipoInscripcion);
            }

            var capacitacionExistente = await _context.Capacitaciones
                                                      .AsNoTracking() //para NO almacenar datos en el contexto
                                                      .Include(c => c.TiposDeInscripciones)
                                                      .FirstOrDefaultAsync(c => c.Id == capacitacion.Id);
            if (capacitacionExistente == null)
            {
                return NotFound("No se encontro la capacitación que se intenta modificar.");
            }

            var tipoInscripcionesAEliminar = capacitacionExistente.TiposDeInscripciones
                                                                  .Where(t => !capacitacion.TiposDeInscripciones
                                                                  .Any(ti => ti.Id == t.Id))
                                                                  .ToList();
            
            foreach (var tipoInscripcionCapacitacion in tipoInscripcionesAEliminar)
            {
                _context.TiposInscripcionesCapacitaciones.Remove(tipoInscripcionCapacitacion);
            }

            var tipoInscripcionAgregar = capacitacion.TiposDeInscripciones
                                                            .Where(ti => !capacitacionExistente.TiposDeInscripciones
                                                            .Any(t => t.Id == ti.Id))
                                                            .ToList();
            foreach (var tipoInscripcionCapacitacion in tipoInscripcionAgregar)
            {
                _context.Attach(tipoInscripcionCapacitacion.TipoInscripcion);
                _context.TiposInscripcionesCapacitaciones.Add(tipoInscripcionCapacitacion);
            }


                _context.Entry(capacitacion).State = EntityState.Modified;
            //entry = le dice al contexto que la entidad capacitacion fue modificada 
            //context tiene una copia gigante de copia de datos

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!CapacitacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }

            return NoContent();
        }

        // POST: api/Capacitaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Capacitacion>> PostCapacitacion(Capacitacion capacitacion)
        {
            foreach (var tipoInscripcionCapacitacion in capacitacion.TiposDeInscripciones)
            {
                _context.Attach(tipoInscripcionCapacitacion.TipoInscripcion);
                //attach es para decir que no se cree un nuevo registro de TipoInscripcion porque ya existe
            }


            _context.Capacitaciones.Add(capacitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacitacion", new { id = capacitacion.Id }, capacitacion);
        }

        // DELETE: api/Capacitaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }
            capacitacion.IsDeleted = true; // Soft delete
            _context.Capacitaciones.Update(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Capacitaciones/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitaciones.IgnoreQueryFilters().FirstOrDefaultAsync(c=>c.Id.Equals(id));
            if (capacitacion == null)
            {
                return NotFound();
            }
            capacitacion.IsDeleted = false; // Soft restore
            _context.Capacitaciones.Update(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CapacitacionExists(int id)
        {
            return _context.Capacitaciones.Any(e => e.Id == id);
        }
    }
}
