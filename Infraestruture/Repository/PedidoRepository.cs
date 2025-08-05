using Core.Entity;

namespace Infraestruture.Repository
{
    public class PedidoRepository : EfRepository<Pedido>, Core.Repository.IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
