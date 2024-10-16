using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolyglotAPI.Data;
using PolyglotAPI.Entities;

namespace PolyglotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly PolyDBContext _context;

        public AlunoController(PolyDBContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> Getaluno()
        {

            var aluno = await _context.Aluno.ToListAsync();

            foreach (Aluno a in aluno)
            {
                Console.WriteLine(a.Nome);
            }

            var alunos = await _context.Aluno.ToListAsync();

            return Ok(aluno);
        }


        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }
        
        // POST: api/Aluno
        [HttpPost("Login")]
        public async Task<IActionResult> verificaEmail(string email, string senha)
        {

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return BadRequest("O email e a senha são campos obrigatórios.");
            }

            var AlunoEmail = await _context.Aluno.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            if (AlunoEmail == null || AlunoEmail.Senha != senha)
            {
                return Unauthorized("Email ou senha invalídos.");
            }

            return Ok("Login efetuado com sucesso.");
        }

        // POST: api/Aluno
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {

            foreach (Aluno a in _context.Aluno)
            {
                if (aluno.Email == a.Email)
                {
                    return BadRequest("Esse e-mail ja está sendo ultilizado");
                }
            }

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }
}
