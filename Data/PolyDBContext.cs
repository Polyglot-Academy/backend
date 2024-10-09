using Microsoft.EntityFrameworkCore;
using PolyglotAPI.Entities;

namespace PolyglotAPI.Data
{
    public class PolyDBContext : DbContext
    {
        public PolyDBContext(DbContextOptions<PolyDBContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new MatriculaConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}