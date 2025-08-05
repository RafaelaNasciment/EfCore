using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestruture.Repository.Configuration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(c => c.Nome).HasColumnType("VARCHAR").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Editora).HasColumnType("VARCHAR").IsRequired().HasMaxLength(100);
        }
    }
}
