using Core.Entity;
using Core.Input;

namespace Core.Repository
{
    public interface IClienteRepository : IRepository<Entity.Cliente>
    {
        public ClienteDto GetClientesComPedidosUltimosSeisMeses(int id);
    }
}
