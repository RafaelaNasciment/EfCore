using Core.Entity;

namespace Core.Input
{
    public class PedidoDto
    {
        public PedidoDto(int clientId, int livroId, LivroDto livro, int id, DateTime dataCriacao)
        {
            ClientId = clientId;
            LivroId = livroId;
            Livro = livro;
            Id = id;
            DataCriacao = dataCriacao;
        }

        public int ClientId { get; set; }
        public int LivroId { get; set; }
        public LivroDto Livro { get; set; }
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
