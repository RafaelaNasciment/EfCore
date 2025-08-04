using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestruture.Repository.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(c => c.DataCriacao).HasColumnName("DataCriacao").HasColumnType("INT").IsRequired();
            builder.Property(c => c.Nome).HasColumnType("VARCHAR").IsRequired().HasMaxLength(100);
            builder.Property(c => c.DataNascimento).HasColumnType("DATETIME").IsRequired(false);
        }
    }
}
