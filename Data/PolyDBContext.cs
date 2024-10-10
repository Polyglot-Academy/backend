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

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Professor> Professor { get; set; }

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