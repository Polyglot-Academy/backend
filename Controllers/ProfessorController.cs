using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolyglotAPI.Data;
using PolyglotAPI.Entities;
using System.Threading.Tasks;

namespace PolyglotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly PolyDBContext _context;

        public ProfessorController(PolyDBContext context)
        {
            _context = context;
        }

        // GET: api/Professor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
        {
            return await _context.Professor.ToListAsync();
        }

        // GET: api/Professor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _context.Professor.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }
        // POST: api/Professor
        [HttpPost("Login")]
        public async Task<IActionResult> verificaEmail(string email, string senha)
        {

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return BadRequest("O email e a senha são campos obrigatórios.");
            }

            var ProfessorEmail = await _context.Professor.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            if (ProfessorEmail == null ||  ProfessorEmail.Senha != senha)
            {
                return Unauthorized("Email ou senha invalídos.");
            }

            return Ok("Login efetuado com sucesso.");
        }

        // POST: api/Professor
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {

            foreach (Professor p in _context.Professor)
            {
                if (professor.Email == p.Email)
                {
                    return BadRequest("Esse e-mail ja está sendo ultilizado");
                }
            }

            _context.Professor.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
        }

        // PUT: api/Professor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Professor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.Id == id);
        }
    }
}

