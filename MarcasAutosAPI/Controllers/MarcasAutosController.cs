using MarcasAutosAPI.Data;
using MarcasAutosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController : ControllerBase
    {
        private readonly MarcasAutosContext _context;

        public MarcasAutosController(MarcasAutosContext context)
        {
            _context = context;
        }

        // GET: api/MarcasAutos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcasAutos()
        {   
            try
            {
                var marcas = await _context.MarcasAutos.ToListAsync();

                if (marcas.Count == 0)
                {
                    return NotFound();
                }

                return Ok(marcas);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al acceder a la base de datos.");
            }
            catch (InvalidOperationException invalidOpEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Operación inválida.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}