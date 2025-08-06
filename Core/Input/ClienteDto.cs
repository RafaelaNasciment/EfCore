using Core.Entity;

namespace Core.Input
{
    public class ClienteDto
    {
        public ClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            DataCriacao = cliente.DataCriacao;
            DataNascimento = cliente.DataNascimento;
            Nome = cliente.Nome;
            Cpf = cliente.Cpf;
        }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public  ICollection<PedidoDto> PedidoDto { get; set; }
    }
}
