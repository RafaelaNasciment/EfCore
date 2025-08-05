using Core.Entity;

namespace Core.Repository
{
    public interface IClienteRepository : IRepository<Entity.Cliente>
    {
        public Cliente GetClientesComPedidosUltimosSeisMeses(int id);
    }
}
