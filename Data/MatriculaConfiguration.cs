using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolyglotAPI.Entities;

namespace PolyglotAPI.Data
{

    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            // Composite key
            builder.HasKey(m => new { m.AlunoId, m.CursoId });

            // Property configurations
            builder.Property(m => m.DataMatricula)
                .IsRequired();

            // Table name (optional)
            builder.ToTable("Matricula");
        }
    }
}