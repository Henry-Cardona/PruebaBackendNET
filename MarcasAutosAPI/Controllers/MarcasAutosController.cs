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
            var marcas = await _context.MarcasAutos.ToListAsync();

            if (marcas == null || marcas.Count == 0)
            {
                return NotFound();
            }

            return Ok(marcas);
        }

        private bool MarcaAutoExists(int id)
        {
            return _context.MarcasAutos.Any(e => e.Id == id);
        }
    }
}
