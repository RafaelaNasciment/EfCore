using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Repository
{
    public class ClienteRepository : EfRepository<Core.Entity.Cliente>, Core.Repository.IClienteRepository
    {
        private ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Cliente GetClientesComPedidosUltimosSeisMeses(int id)
        {
            var cliente = _context.Cliente
                .Include(e => e.Pedidos)
                    .ThenInclude(p => p.Livro)
                .FirstOrDefault(c => c.Id == id);

            cliente.Pedidos = cliente.Pedidos
                .Where(p => p.DataCriacao >= DateTime.Now.AddMonths(-6))
                .Select(p => 
                {
                    p.Cliente = null;
                    p.Livro.Pedidos = null;
                    return p;
                })
                .ToList();

            return cliente ?? throw new Exception("Cliente não encontrado!");
        }
    }
}
