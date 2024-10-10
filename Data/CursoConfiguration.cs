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

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Descricao)
                .HasMaxLength(500);

            builder.Property(c => c.Nivel)
                .IsRequired();

            builder.Property(c => c.Duracao)
                .IsRequired();

            builder.Property(c => c.ProfessorId)
                .IsRequired();

            builder.Property(c => c.DataInicio)
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasPrecision(18, 2);

            builder.ToTable("Curso");
        }
    }
}