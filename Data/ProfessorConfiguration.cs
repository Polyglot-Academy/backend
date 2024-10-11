using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolyglotAPI.Entities;

namespace PolyglotAPI.Data
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Especializacao)
                .HasMaxLength(150);

            builder.Property(p => p.Experiencia)
                .IsRequired();

            builder.ToTable("Professor");
        }
    }
}