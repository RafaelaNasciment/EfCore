using Core.Entity;
using Core.Input;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Repository
{
    public class ClienteRepository : EfRepository<Core.Entity.Cliente>, Core.Repository.IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public ClienteDto GetClientesComPedidosUltimosSeisMeses(int id)
        {
            var cliente = _context.Cliente
                .FirstOrDefault(c => c.Id == id) ?? throw new Exception();

            return new ClienteDto(cliente)
            {
                PedidoDto = cliente.Pedidos
                    .Where(p => p.DataCriacao >= DateTime.Now.AddMonths(-6))
                    .Select(p => new PedidoDto(
                        clientId: p.ClientId,
                        livroId: p.LivroId,
                        livro: new LivroDto() { 
                            Editora = p.Livro.Editora, 
                            Nome = p.Livro.Nome
                        },
                        id: p.Id,
                        dataCriacao: p.DataCriacao))
                    .ToList()
            };
        }
    }
}
