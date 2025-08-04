using System;
using System.Collections.Generic;

namespace Infraestruture.Scaffold;

public partial class Cliente
{
    public int Id { get; set; }

    public DateTime? DataNascimento { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public virtual Pedido? Pedido { get; set; }
}
