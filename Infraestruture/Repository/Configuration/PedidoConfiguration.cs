using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestruture.Repository.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.ClientId).HasColumnType("INT").IsRequired();
            builder.Property(p => p.LivroId).HasColumnType("INT").IsRequired();
            builder.HasOne(p => p.Cliente).WithMany(c => c.Pedidos).HasForeignKey(p => p.ClientId);
            builder.HasOne(p => p.Livro).WithMany(c => c.Pedidos).HasForeignKey(p => p.LivroId);

        }
    }
}
