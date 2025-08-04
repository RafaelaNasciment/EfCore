namespace Core.Entity
{
    public class Pedido : EntityBase
    {
        public int ClientId { get; set; }
        public int LivroId { get; set; }
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }
    }
}
