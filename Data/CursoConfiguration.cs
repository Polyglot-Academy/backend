using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolyglotAPI.Entities;

namespace PolyglotAPI.Data
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            // Primary Key
            builder.HasKey(c => c.Id);

            // Property configurations
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.descricao)
                .HasMaxLength(500);

            builder.Property(c => c.Nivel)
                .IsRequired();

            builder.Property(c => c.duracao)
                .IsRequired();

            builder.Property(c => c.ProfessorID)
                .IsRequired();

            builder.Property(c => c.DataInicio)
                .IsRequired();

            builder.Property(c => c.valor)
                .HasPrecision(18, 2);

            // Table name (optional)
            builder.ToTable("Curso");
        }
    }
}