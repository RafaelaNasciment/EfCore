namespace Core.Input
{
    public class LivroDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Editora { get; set; }
        public required string Nome { get; set; }
        public virtual ICollection<PedidoDto> Pedidos { get; set; }
    }
}
