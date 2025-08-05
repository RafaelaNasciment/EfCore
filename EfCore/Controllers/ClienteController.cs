using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
            => _clienteRepository = clienteRepository;

        [HttpGet("pedidos-seis-meses")]
        public async Task<IActionResult> GetClientesComPedidosUltimosSeisMeses(int id)
        {
            try
            {
                var clientes = _clienteRepository.GetClientesComPedidosUltimosSeisMeses(id);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
