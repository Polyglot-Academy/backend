using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolyglotAPI.Data;
using PolyglotAPI.Entities;
using System.Threading.Tasks;

namespace PolyglotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly PolyDBContext _context;

        public MatriculaController(PolyDBContext context)
        {
            _context = context;
        }

        // GET: api/Matricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
        {
            return await _context.Matricula.ToListAsync();
        }

        // GET: api/Matricula/{AlunoId}/{CursoId}
        [HttpGet("{AlunoId}/{CursoId}")]
        public async Task<ActionResult<Matricula>> GetMatricula(int AlunoId, int CursoId)
        {
            var matricula = await _context.Matricula.FindAsync(AlunoId, CursoId);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // POST: api/Matricula
        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatricula), new { AlunoId = matricula.AlunoId, CursoId = matricula.CursoId }, matricula);
        }

        // DELETE: api/Matricula/{AlunoId}/{CursoId}
        [HttpDelete("{AlunoId}/{CursoId}")]
        public async Task<IActionResult> DeleteMatricula(int AlunoId, int CursoId)
        {
            var matricula = await _context.Matricula.FindAsync(AlunoId, CursoId);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
