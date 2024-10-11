using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolyglotAPI.Entities;

namespace PolyglotAPI.Data
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            // Primary Key
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.DataNascimento)
                .IsRequired();

            builder.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Senha)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Telefone)
                .HasMaxLength(15);

            builder.ToTable("Aluno");
        }
    }
}