namespace Core.Entity
{
    public class Cliente : EntityBase
    {
        public DateTime? DataNascimento { get; set; }
        public required string Nome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
