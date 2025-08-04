using System;
using System.Collections.Generic;

namespace Infraestruture.Scaffold;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int LivroId { get; set; }

    public DateTime DataCriacao { get; set; }

    public virtual Livro Id1 { get; set; } = null!;

    public virtual Cliente IdNavigation { get; set; } = null!;
}
