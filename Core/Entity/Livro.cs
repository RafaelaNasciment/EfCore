namespace Core.Entity
{
    public class Livro : EntityBase
    {
        public Livro()
        {
            DataCriacao = DateTime.Now;
        }
        public required string Editora { get; set; }
        public required string Nome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
